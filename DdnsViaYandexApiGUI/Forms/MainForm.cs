using System;
using System.Data;
using System.Data.SQLite;
using System.Threading;
using System.Windows.Forms;
using Core.Services;
using System.Configuration;

namespace GUI.Forms
{
    public partial class MainForm : Form
    {
        private const string _currentVersion = "2.1.1";
        private const string _refreshRateKey = "RefreshRate";
        private bool _isServiceStarted = true;
        private Thread _threadService;
        private readonly Thread _versionThread;
        delegate void SetTextCallback(string text);

        private static string AppPath
        {
            get { return Application.ExecutablePath; }
        }

        public MainForm()
        {
            InitializeComponent();

            notifyIcon.Visible = false;
            ShowInTaskbar = false;

            labelVersion.Text = "Версия. " + _currentVersion;

            var strLogs = string.Empty;
            var latestVersion = Core.DdnsViaYandexApi.GetLatestVersion(ref strLogs);

            if (_currentVersion != latestVersion)
            {
                var connectionString = ConfigurationManager.ConnectionStrings["DdnsViaYandexApiGUI.Properties.Settings.DbDomainInfoConnectionStringBin"].ConnectionString;
                var connection = new SQLiteConnection(connectionString);
                if (!DatabaseService.SqliteColumnExists(new SQLiteCommand(connection), "DomainInfo", "Ttl"))
                {
                    var query = "ALTER TABLE DomainInfo ADD COLUMN Ttl INT default(900)";
                    DatabaseService.ExecuteSqlNonQuery(AppPath, query);
                }
            }

            StartServiceThread();

            _versionThread = new Thread(() =>
                {
                    if (_currentVersion != latestVersion)
                        MessageBox.Show("Доступна новая версия программы: " + latestVersion + ". Для обновления зайдите на сайт http://dns-ip.ru/Home/DynDns.");

                	// проверяем обновление раз в сутки
                	Thread.Sleep(1000*60*60*24);
                }) {IsBackground = true};

        	_versionThread.Start();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                GridFill();
                tbRefreshRate.Text = SettingsService.GetSetting(_refreshRateKey, AppPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized != WindowState)
                return;

            notifyIcon.Visible = true;
            ShowInTaskbar = true;
            Hide();
        }

        private void dataGridViewDomainInfo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var id = dataGridViewDomainInfo.Rows[e.RowIndex].Cells["Id"].Value.ToString();
            int result;
            if (!string.IsNullOrEmpty(id) && int.TryParse(id, out result))
            {
                var i = dataGridViewDomainInfo.Rows[e.RowIndex].Index;
                var dif = new DomainInfoForm(result, i, this);
                dif.Show();
            }
            else
            {
            	var dif = new DomainInfoForm(null, null, this);
                dif.Show();
            }
        }

        private FormWindowState _oldFormState;
        private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (WindowState == FormWindowState.Normal || WindowState == FormWindowState.Maximized)
                {
                    _oldFormState = WindowState;
                    WindowState = FormWindowState.Minimized;
                }
                else
                {
                    Show();
                    WindowState = _oldFormState;
                }
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (_isServiceStarted)
            {
                StopServiceThread();
                buttonStart.Text = "Старт";

                richTextBoxLogs.Text += DateTime.Now + ": " + "Stop application";
                richTextBoxLogs.Text += Environment.NewLine;
            }
            else
            {
                StartServiceThread();
                buttonStart.Text = "Стоп";

                richTextBoxLogs.Text += DateTime.Now + ": " + "Start application";
                richTextBoxLogs.Text += Environment.NewLine;
            }
            _isServiceStarted = !_isServiceStarted;
        }

        private void btnChangeRefreshRate_Click(object sender, EventArgs e)
        {
            int result;
            if (int.TryParse(tbRefreshRate.Text, out result))
            {
                SettingsService.SetSetting(_refreshRateKey, tbRefreshRate.Text, AppPath);

                richTextBoxLogs.Text += DateTime.Now + ": " + "Refresh rate saved and it equals " + tbRefreshRate.Text;
                richTextBoxLogs.Text += Environment.NewLine;
                if (_isServiceStarted)
                {
                    StopServiceThread();
                    StartServiceThread();
                }
            }
            else
                tbRefreshRate.Text = SettingsService.GetSetting(_refreshRateKey, AppPath);
        }

        private void btnImportFromCsv_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog { Filter = "Csv files (*.csv)|*.csv" };
            dialog.ShowDialog();
            if (!string.IsNullOrWhiteSpace(dialog.FileName))
                CsvService.ImportFrom(dialog.FileName, AppPath);
            GridFill();
        }

        private void btnExportToCsv_Click(object sender, EventArgs e)
        {
            var dialog = new SaveFileDialog { Filter = "Csv files (*.csv)|*.csv" };
            dialog.ShowDialog();
            if (!string.IsNullOrWhiteSpace(dialog.FileName))
                CsvService.ExportTo(dialog.FileName, AppPath);
        }

        private void dataGridViewDomainInfo_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (dataGridViewDomainInfo.Rows.Count == 0)
                return;

            try
            {
                GridFill();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void StartServiceThread()
        {
            _threadService = new Thread(ServiceStart) {IsBackground = true};
            _threadService.Start();
        }

        private void StopServiceThread()
        {
            if (_threadService!= null)
                _threadService.Abort();
        }

        private void ServiceStart()
        {
            while (true)
            {
                string strLogs;
                SetTextBoxCurrentIp(Core.DdnsViaYandexApi.Start(AppPath, out strLogs));
                RichTextBoxCurrentIp(strLogs);

                var refreshRate = SettingsService.GetSetting(_refreshRateKey, AppPath);
                int result;
                if (int.TryParse(refreshRate, out result))
                    Thread.Sleep(result * 60 * 1000);
            }
        }

        private void SetTextBoxCurrentIp(string text)
        {
            if (textBoxCurrentIp.InvokeRequired)
            {
                SetTextCallback d = SetTextBoxCurrentIp;
                Invoke(d, new object[] { text });
            }
            else
            {
                textBoxCurrentIp.Text = text;
            }
        }

        private void RichTextBoxCurrentIp(string text)
        {
            if (richTextBoxLogs.InvokeRequired)
            {
                SetTextCallback d = RichTextBoxCurrentIp;
                Invoke(d, new object[] { text });
            }
            else
            {
                richTextBoxLogs.Text += text;
            }
        }

        public void GridFill()
        {
            var cnString = ConfigurationManager.ConnectionStrings["DdnsViaYandexApiGUI.Properties.Settings.DbDomainInfoConnectionStringBin"].ConnectionString;
            DatabaseService.SqLiteConnection = new SQLiteConnection(cnString);
            DatabaseService.SqLiteDataAdapter = new SQLiteDataAdapter("select * from DomainInfo", DatabaseService.SqLiteConnection);
            DatabaseService.SqLiteCommandBuilder = new SQLiteCommandBuilder(DatabaseService.SqLiteDataAdapter);
            DatabaseService.DataTable = new DataTable();
            DatabaseService.SqLiteDataAdapter.Fill(DatabaseService.DataTable);

            dataGridViewDomainInfo.DataSource = DatabaseService.DataTable;
            dataGridViewDomainInfo.ReadOnly = true;
        }
    }
}
