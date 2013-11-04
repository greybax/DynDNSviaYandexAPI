namespace DdnsViaYandexApiGUI
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.groupBoxARecord = new System.Windows.Forms.GroupBox();
            this.dataGridViewDomainInfo = new System.Windows.Forms.DataGridView();
            this.tokenDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subDomainDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.domainDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.domainInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dbDomainInfoDataSet = new DdnsViaYandexApiGUI.DbDomainInfoDataSet();
            this.labelCurrentIp = new System.Windows.Forms.Label();
            this.textBoxCurrentIp = new System.Windows.Forms.TextBox();
            this.buttonStart = new System.Windows.Forms.Button();
            this.lblRefresh = new System.Windows.Forms.Label();
            this.btnChangeRefreshRate = new System.Windows.Forms.Button();
            this.lblRefreshRate = new System.Windows.Forms.Label();
            this.tbRefreshRate = new System.Windows.Forms.TextBox();
            this.domainInfoTableAdapter = new DdnsViaYandexApiGUI.DbDomainInfoDataSetTableAdapters.DomainInfoTableAdapter();
            this.buttonLog = new System.Windows.Forms.Button();
            this.btnImportFromCsv = new System.Windows.Forms.Button();
            this.btnExportToCsv = new System.Windows.Forms.Button();
            this.groupBoxARecord.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDomainInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.domainInfoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbDomainInfoDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "DDNS через Яндекс API";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseClick);
            // 
            // groupBoxARecord
            // 
            this.groupBoxARecord.Controls.Add(this.dataGridViewDomainInfo);
            this.groupBoxARecord.Location = new System.Drawing.Point(15, 71);
            this.groupBoxARecord.Name = "groupBoxARecord";
            this.groupBoxARecord.Size = new System.Drawing.Size(505, 209);
            this.groupBoxARecord.TabIndex = 2;
            this.groupBoxARecord.TabStop = false;
            this.groupBoxARecord.Text = "А-запись";
            // 
            // dataGridViewDomainInfo
            // 
            this.dataGridViewDomainInfo.AutoGenerateColumns = false;
            this.dataGridViewDomainInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDomainInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tokenDataGridViewTextBoxColumn,
            this.Id,
            this.subDomainDataGridViewTextBoxColumn,
            this.domainDataGridViewTextBoxColumn});
            this.dataGridViewDomainInfo.DataSource = this.domainInfoBindingSource;
            this.dataGridViewDomainInfo.Location = new System.Drawing.Point(13, 19);
            this.dataGridViewDomainInfo.Name = "dataGridViewDomainInfo";
            this.dataGridViewDomainInfo.Size = new System.Drawing.Size(486, 177);
            this.dataGridViewDomainInfo.TabIndex = 2;
            this.dataGridViewDomainInfo.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDomainInfo_CellDoubleClick);
            // 
            // tokenDataGridViewTextBoxColumn
            // 
            this.tokenDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.tokenDataGridViewTextBoxColumn.DataPropertyName = "Token";
            this.tokenDataGridViewTextBoxColumn.FillWeight = 150F;
            this.tokenDataGridViewTextBoxColumn.HeaderText = "Token";
            this.tokenDataGridViewTextBoxColumn.Name = "tokenDataGridViewTextBoxColumn";
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.Visible = false;
            // 
            // subDomainDataGridViewTextBoxColumn
            // 
            this.subDomainDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.subDomainDataGridViewTextBoxColumn.DataPropertyName = "SubDomain";
            this.subDomainDataGridViewTextBoxColumn.HeaderText = "SubDomain";
            this.subDomainDataGridViewTextBoxColumn.Name = "subDomainDataGridViewTextBoxColumn";
            // 
            // domainDataGridViewTextBoxColumn
            // 
            this.domainDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.domainDataGridViewTextBoxColumn.DataPropertyName = "Domain";
            this.domainDataGridViewTextBoxColumn.HeaderText = "Domain";
            this.domainDataGridViewTextBoxColumn.Name = "domainDataGridViewTextBoxColumn";
            // 
            // domainInfoBindingSource
            // 
            this.domainInfoBindingSource.DataMember = "DomainInfo";
            this.domainInfoBindingSource.DataSource = this.dbDomainInfoDataSet;
            // 
            // dbDomainInfoDataSet
            // 
            this.dbDomainInfoDataSet.DataSetName = "DbDomainInfoDataSet";
            this.dbDomainInfoDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // labelCurrentIp
            // 
            this.labelCurrentIp.AutoSize = true;
            this.labelCurrentIp.Location = new System.Drawing.Point(19, 12);
            this.labelCurrentIp.Name = "labelCurrentIp";
            this.labelCurrentIp.Size = new System.Drawing.Size(101, 13);
            this.labelCurrentIp.TabIndex = 5;
            this.labelCurrentIp.Text = "Текущий IP адрес:";
            // 
            // textBoxCurrentIp
            // 
            this.textBoxCurrentIp.Location = new System.Drawing.Point(140, 12);
            this.textBoxCurrentIp.Name = "textBoxCurrentIp";
            this.textBoxCurrentIp.ReadOnly = true;
            this.textBoxCurrentIp.Size = new System.Drawing.Size(255, 20);
            this.textBoxCurrentIp.TabIndex = 6;
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(401, 12);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(113, 23);
            this.buttonStart.TabIndex = 7;
            this.buttonStart.Text = "Старт";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // lblRefresh
            // 
            this.lblRefresh.AutoSize = true;
            this.lblRefresh.Location = new System.Drawing.Point(19, 47);
            this.lblRefresh.Name = "lblRefresh";
            this.lblRefresh.Size = new System.Drawing.Size(148, 13);
            this.lblRefresh.TabIndex = 8;
            this.lblRefresh.Text = "Частота обновления: раз в ";
            // 
            // btnChangeRefreshRate
            // 
            this.btnChangeRefreshRate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnChangeRefreshRate.Location = new System.Drawing.Point(401, 42);
            this.btnChangeRefreshRate.Name = "btnChangeRefreshRate";
            this.btnChangeRefreshRate.Size = new System.Drawing.Size(113, 23);
            this.btnChangeRefreshRate.TabIndex = 11;
            this.btnChangeRefreshRate.Text = "Применить";
            this.btnChangeRefreshRate.UseVisualStyleBackColor = true;
            this.btnChangeRefreshRate.Click += new System.EventHandler(this.btnChangeRefreshRate_Click);
            // 
            // lblRefreshRate
            // 
            this.lblRefreshRate.AutoSize = true;
            this.lblRefreshRate.Location = new System.Drawing.Point(314, 47);
            this.lblRefreshRate.Name = "lblRefreshRate";
            this.lblRefreshRate.Size = new System.Drawing.Size(37, 13);
            this.lblRefreshRate.TabIndex = 12;
            this.lblRefreshRate.Text = "минут";
            // 
            // tbRefreshRate
            // 
            this.tbRefreshRate.Location = new System.Drawing.Point(173, 44);
            this.tbRefreshRate.Name = "tbRefreshRate";
            this.tbRefreshRate.Size = new System.Drawing.Size(135, 20);
            this.tbRefreshRate.TabIndex = 13;
            // 
            // domainInfoTableAdapter
            // 
            this.domainInfoTableAdapter.ClearBeforeFill = true;
            // 
            // buttonLog
            // 
            this.buttonLog.Location = new System.Drawing.Point(424, 286);
            this.buttonLog.Name = "buttonLog";
            this.buttonLog.Size = new System.Drawing.Size(96, 21);
            this.buttonLog.TabIndex = 14;
            this.buttonLog.Text = "Показать логи";
            this.buttonLog.UseVisualStyleBackColor = true;
            this.buttonLog.Visible = false;
            this.buttonLog.Click += new System.EventHandler(this.buttonLog_Click);
            // 
            // btnImportFromCsv
            // 
            this.btnImportFromCsv.Location = new System.Drawing.Point(12, 286);
            this.btnImportFromCsv.Name = "btnImportFromCsv";
            this.btnImportFromCsv.Size = new System.Drawing.Size(96, 21);
            this.btnImportFromCsv.TabIndex = 15;
            this.btnImportFromCsv.Text = "Импорт из csv";
            this.btnImportFromCsv.UseVisualStyleBackColor = true;
            this.btnImportFromCsv.Click += new System.EventHandler(this.btnImportFromCsv_Click);
            // 
            // btnExportToCsv
            // 
            this.btnExportToCsv.Location = new System.Drawing.Point(114, 286);
            this.btnExportToCsv.Name = "btnExportToCsv";
            this.btnExportToCsv.Size = new System.Drawing.Size(96, 21);
            this.btnExportToCsv.TabIndex = 16;
            this.btnExportToCsv.Text = "Экспорт в csv";
            this.btnExportToCsv.UseVisualStyleBackColor = true;
            this.btnExportToCsv.Click += new System.EventHandler(this.btnExportToCsv_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 312);
            this.Controls.Add(this.btnExportToCsv);
            this.Controls.Add(this.btnImportFromCsv);
            this.Controls.Add(this.buttonLog);
            this.Controls.Add(this.tbRefreshRate);
            this.Controls.Add(this.lblRefreshRate);
            this.Controls.Add(this.btnChangeRefreshRate);
            this.Controls.Add(this.lblRefresh);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.textBoxCurrentIp);
            this.Controls.Add(this.labelCurrentIp);
            this.Controls.Add(this.groupBoxARecord);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "DDNS через Яндекс API v 2.0";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.groupBoxARecord.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDomainInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.domainInfoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbDomainInfoDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.GroupBox groupBoxARecord;
        private System.Windows.Forms.Label labelCurrentIp;
        private System.Windows.Forms.TextBox textBoxCurrentIp;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.DataGridView dataGridViewDomainInfo;
        private DbDomainInfoDataSet dbDomainInfoDataSet;
        private System.Windows.Forms.BindingSource domainInfoBindingSource;
        private DbDomainInfoDataSetTableAdapters.DomainInfoTableAdapter domainInfoTableAdapter;
        private System.Windows.Forms.Label lblRefresh;
        private System.Windows.Forms.Button btnChangeRefreshRate;
        private System.Windows.Forms.Label lblRefreshRate;
        private System.Windows.Forms.TextBox tbRefreshRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn tokenDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn subDomainDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn domainDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button buttonLog;
        private System.Windows.Forms.Button btnImportFromCsv;
        private System.Windows.Forms.Button btnExportToCsv;
    }
}

