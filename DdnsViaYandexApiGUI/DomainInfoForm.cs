using System;
using System.Windows.Forms;
using DdnsViaYandexApi.Services;

namespace DdnsViaYandexApiGUI
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
                    textBoxToken.Text = GlobalClass.Dt.Rows[_rowId.Value]["Token"].ToString();
                    textBoxSubDomain.Text = GlobalClass.Dt.Rows[_rowId.Value]["SubDomain"].ToString();
                    textBoxDomain.Text = GlobalClass.Dt.Rows[_rowId.Value]["Domain"].ToString();
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

            var query = string.Format("INSERT INTO DomainInfo Values ('{0}','{1}','{2}', null)", 
                textBoxToken.Text, textBoxSubDomain.Text, textBoxDomain.Text);
            DatabaseService.ExecuteSql(Application.ExecutablePath, query);
            _parentForm.GridFill();

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

                var query = string.Format("UPDATE DomainInfo " +
                                          "Set Domain = '{0}', Subdomain = '{1}', Token = '{2}' " +
                                          "where Id = '{3}'",
                 textBoxDomain.Text, textBoxSubDomain.Text, textBoxToken.Text, _domainId.Value);
                DatabaseService.ExecuteSql(Application.ExecutablePath, query);
                _parentForm.GridFill();
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
