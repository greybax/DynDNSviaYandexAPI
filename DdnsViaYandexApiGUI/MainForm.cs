﻿using System;
using System.Data;
using System.Data.SQLite;
using System.Threading;
using System.Windows.Forms;
using DdnsViaYandexApi.Services;
using System.Configuration;

namespace DdnsViaYandexApiGUI
{
    public partial class MainForm : Form
    {
        private const string _currentVersion = "2.1.0";
        private const string _refreshRateKey = "RefreshRate";
        private bool _isServiceStarted = true;
        private Thread _threadService;
        private readonly Thread _versionThread;
        delegate void SetTextCallback(string text);

        private static string AppPath
        {
            get { return Application.ExecutablePath; }
        }

        public SQLiteCommandBuilder Bui { get; set; }

        public MainForm()
        {
            InitializeComponent();

            notifyIcon.Visible = false;
            ShowInTaskbar = false;

            labelVersion.Text = "Версия. " + _currentVersion;

            StartService();

            _versionThread = new Thread(() =>
                {
                    string strLogs = string.Empty;
                    var version = DdnsViaYandexApi.DdnsViaYandexApi.GetLatestVersion(ref strLogs);
                    if (_currentVersion != version)
                        MessageBox.Show("Доступна новая версия программы: " + version + ". Для обновления зайдите на сайт http://dns-ip.ru/Home/DynDns.");

                	// проверяем обновление раз в сутки
                	Thread.Sleep(1000*60*60*24);
                }) {IsBackground = true};

        	_versionThread.Start();
        }

        private FormWindowState _oldFormState;

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized != WindowState)
                return;

            notifyIcon.Visible = true;
            ShowInTaskbar = true;
            Hide();
        }

        private SQLiteConnection _con;

        public void GridFill()
        {
            string cnString = ConfigurationManager.ConnectionStrings["DdnsViaYandexApiGUI.Properties.Settings.DbDomainInfoConnectionStringBin"].ConnectionString;
            _con = new SQLiteConnection(cnString);
            GlobalClass.Adap = new SQLiteDataAdapter("select * from DomainInfo", _con);
            Bui = new SQLiteCommandBuilder(GlobalClass.Adap);
            GlobalClass.Dt = new DataTable();
            GlobalClass.Adap.Fill(GlobalClass.Dt);
            dataGridViewDomainInfo.DataSource = GlobalClass.Dt;
            dataGridViewDomainInfo.ReadOnly = true;
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
                StopService();
                buttonStart.Text = "Старт";

                richTextBoxLogs.Text += DateTime.Now + ": " + "Stop application";
                richTextBoxLogs.Text += Environment.NewLine;
            }
            else
            {
                StartService();
                buttonStart.Text = "Стоп";
            }
            _isServiceStarted = !_isServiceStarted;
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
                    StopService();
                    StartService();
                }
            }
            else
                tbRefreshRate.Text = SettingsService.GetSetting(_refreshRateKey, AppPath);
        }

        private void StartService()
        {
            _threadService = new Thread(ServiceStart) {IsBackground = true};
            _threadService.Start();
        }

        private void StopService()
        {
            if (_threadService!= null)
                _threadService.Abort();
        }

        private void ServiceStart()
        {
            while (true)
            {
                var strLogs = string.Empty;
                SetTextBoxCurrentIp(DdnsViaYandexApi.DdnsViaYandexApi.Start(AppPath, out strLogs));
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

        private void btnImportFromCsv_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "Csv files (*.csv)|*.csv";
            dialog.ShowDialog();
            if (!string.IsNullOrWhiteSpace(dialog.FileName))
                CsvService.ImportFrom(dialog.FileName, AppPath);
            GridFill();
        }

        private void btnExportToCsv_Click(object sender, EventArgs e)
        {
            var dialog = new SaveFileDialog();
            dialog.Filter = "Csv files (*.csv)|*.csv";
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
    }

    class GlobalClass
    {
        public static SQLiteDataAdapter Adap;
        public static DataTable Dt;
    }
}
