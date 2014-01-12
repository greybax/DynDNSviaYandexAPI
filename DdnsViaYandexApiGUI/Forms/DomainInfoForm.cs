using System;
using System.Windows.Forms;
using Core.Services;

namespace GUI.Forms
{
    public partial class DomainInfoForm : Form
    {
        readonly int? _domainId;
        readonly int? _rowId;
        private readonly MainForm _parentForm;

        public DomainInfoForm(int? id, int? i, MainForm parentForm)
        {
            InitializeComponent();
            _domainId = id;
            _rowId = i;
            _parentForm = parentForm;
        }

        private void DomainInfoForm_Load(object sender, EventArgs e)
        {
            if (!_domainId.HasValue)
            {
                buttonUpdate.Visible = false;
                buttonInsert.Visible = true;
                buttonDelete.Enabled = false;
            }
            else if (_rowId.HasValue)
            {
                buttonUpdate.Visible = true;
                buttonInsert.Visible = false;
                buttonDelete.Enabled = true;
                try
                {
                    textBoxToken.Text = DatabaseService.DataTable.Rows[_rowId.Value]["Token"].ToString();
                    textBoxSubDomain.Text = DatabaseService.DataTable.Rows[_rowId.Value]["SubDomain"].ToString();
                    textBoxDomain.Text = DatabaseService.DataTable.Rows[_rowId.Value]["Domain"].ToString();
                    textBoxTtl.Text = DatabaseService.DataTable.Rows[_rowId.Value]["Ttl"].ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void buttonInsert_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxToken.Text))
            {
                MessageBox.Show("Поле 'Токен' обязательно для заполнения");
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxDomain.Text))
            {
                MessageBox.Show("Поле 'Домен' обязательно для заполнения");
                return;
            }

            int ttl;
            if (int.TryParse(textBoxTtl.Text, out ttl) && ttl > 0)
            {
                var query =
                    string.Format(
                        "INSERT INTO DomainInfo (Id, Token, SubDomain, Domain, Ttl) Values (null, '{0}','{1}','{2}', '{3}')",
                        textBoxToken.Text, textBoxDomain.Text, textBoxSubDomain.Text, ttl);
                DatabaseService.ExecuteSql(Application.ExecutablePath, query);
                _parentForm.GridFill();
            }
            else
            {
                MessageBox.Show("Поле 'TTL' должно быть положительным числом");
                return;
            }

            Close();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBoxToken.Text))
                {
                    MessageBox.Show("Поле 'Токен' обязательно для заполнения");
                    return;
                }

                if (string.IsNullOrWhiteSpace(textBoxDomain.Text))
                {
                    MessageBox.Show("Поле 'Домен' обязательно для заполнения");
                    return;
                }

                int ttl;
                if (int.TryParse(textBoxTtl.Text, out ttl) && ttl > 0)
                {
                    var query = string.Format("UPDATE DomainInfo " +
                                              "Set Domain = '{0}', Subdomain = '{1}', Token = '{2}', Ttl = '{3}'" +
                                              "where Id = '{4}'",
                                              textBoxDomain.Text, textBoxSubDomain.Text, textBoxToken.Text, ttl,
                                              _domainId.Value);
                    DatabaseService.ExecuteSql(Application.ExecutablePath, query);
                    _parentForm.GridFill();
                }
                else
                {
                    MessageBox.Show("Поле 'TTL' должно быть положительным числом");
                    return;
                }
                
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var query = string.Format("DELETE FROM DomainInfo " +
                                         "WHERE Id = '{0}'", _domainId.Value);
                DatabaseService.ExecuteSql(Application.ExecutablePath, query);
                _parentForm.GridFill();

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
