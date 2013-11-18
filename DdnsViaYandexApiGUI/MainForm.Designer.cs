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
			this.domainInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.dbDomainInfoDataSet = new DdnsViaYandexApiGUI.DbDomainInfoDataSet();
			this.domainInfoTableAdapter = new DdnsViaYandexApiGUI.DbDomainInfoDataSetTableAdapters.DomainInfoTableAdapter();
			this.tabControl = new System.Windows.Forms.TabControl();
			this.tabPageSetting = new System.Windows.Forms.TabPage();
			this.btnExportToCsv = new System.Windows.Forms.Button();
			this.btnImportFromCsv = new System.Windows.Forms.Button();
			this.tbRefreshRate = new System.Windows.Forms.TextBox();
			this.lblRefreshRate = new System.Windows.Forms.Label();
			this.btnChangeRefreshRate = new System.Windows.Forms.Button();
			this.lblRefresh = new System.Windows.Forms.Label();
			this.buttonStart = new System.Windows.Forms.Button();
			this.textBoxCurrentIp = new System.Windows.Forms.TextBox();
			this.labelCurrentIp = new System.Windows.Forms.Label();
			this.groupBoxARecord = new System.Windows.Forms.GroupBox();
			this.dataGridViewDomainInfo = new System.Windows.Forms.DataGridView();
			this.tokenDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.subDomainDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.domainDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.tabPageLogs = new System.Windows.Forms.TabPage();
			this.labelVersion = new System.Windows.Forms.Label();
			this.richTextBoxLogs = new System.Windows.Forms.RichTextBox();
			((System.ComponentModel.ISupportInitialize)(this.domainInfoBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dbDomainInfoDataSet)).BeginInit();
			this.tabControl.SuspendLayout();
			this.tabPageSetting.SuspendLayout();
			this.groupBoxARecord.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewDomainInfo)).BeginInit();
			this.tabPageLogs.SuspendLayout();
			this.SuspendLayout();
			// 
			// notifyIcon
			// 
			this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
			this.notifyIcon.Text = "DDNS через Яндекс API";
			this.notifyIcon.Visible = true;
			this.notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseClick);
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
			// domainInfoTableAdapter
			// 
			this.domainInfoTableAdapter.ClearBeforeFill = true;
			// 
			// tabControl
			// 
			this.tabControl.Controls.Add(this.tabPageSetting);
			this.tabControl.Controls.Add(this.tabPageLogs);
			this.tabControl.Location = new System.Drawing.Point(12, 12);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(561, 338);
			this.tabControl.TabIndex = 0;
			// 
			// tabPageSetting
			// 
			this.tabPageSetting.Controls.Add(this.btnExportToCsv);
			this.tabPageSetting.Controls.Add(this.btnImportFromCsv);
			this.tabPageSetting.Controls.Add(this.tbRefreshRate);
			this.tabPageSetting.Controls.Add(this.lblRefreshRate);
			this.tabPageSetting.Controls.Add(this.btnChangeRefreshRate);
			this.tabPageSetting.Controls.Add(this.lblRefresh);
			this.tabPageSetting.Controls.Add(this.buttonStart);
			this.tabPageSetting.Controls.Add(this.textBoxCurrentIp);
			this.tabPageSetting.Controls.Add(this.labelCurrentIp);
			this.tabPageSetting.Controls.Add(this.groupBoxARecord);
			this.tabPageSetting.Location = new System.Drawing.Point(4, 22);
			this.tabPageSetting.Name = "tabPageSetting";
			this.tabPageSetting.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageSetting.Size = new System.Drawing.Size(553, 312);
			this.tabPageSetting.TabIndex = 0;
			this.tabPageSetting.Text = "Настройки";
			this.tabPageSetting.UseVisualStyleBackColor = true;
			// 
			// btnExportToCsv
			// 
			this.btnExportToCsv.Location = new System.Drawing.Point(104, 285);
			this.btnExportToCsv.Name = "btnExportToCsv";
			this.btnExportToCsv.Size = new System.Drawing.Size(78, 21);
			this.btnExportToCsv.TabIndex = 28;
			this.btnExportToCsv.Text = "Экспорт в csv";
			this.btnExportToCsv.UseVisualStyleBackColor = true;
			this.btnExportToCsv.Click += new System.EventHandler(this.btnExportToCsv_Click);
			// 
			// btnImportFromCsv
			// 
			this.btnImportFromCsv.Location = new System.Drawing.Point(20, 285);
			this.btnImportFromCsv.Name = "btnImportFromCsv";
			this.btnImportFromCsv.Size = new System.Drawing.Size(78, 21);
			this.btnImportFromCsv.TabIndex = 27;
			this.btnImportFromCsv.Text = "Импорт из csv";
			this.btnImportFromCsv.UseVisualStyleBackColor = true;
			this.btnImportFromCsv.Click += new System.EventHandler(this.btnImportFromCsv_Click);
			// 
			// tbRefreshRate
			// 
			this.tbRefreshRate.Location = new System.Drawing.Point(163, 52);
			this.tbRefreshRate.Name = "tbRefreshRate";
			this.tbRefreshRate.Size = new System.Drawing.Size(117, 20);
			this.tbRefreshRate.TabIndex = 25;
			// 
			// lblRefreshRate
			// 
			this.lblRefreshRate.AutoSize = true;
			this.lblRefreshRate.Location = new System.Drawing.Point(304, 55);
			this.lblRefreshRate.Name = "lblRefreshRate";
			this.lblRefreshRate.Size = new System.Drawing.Size(37, 13);
			this.lblRefreshRate.TabIndex = 24;
			this.lblRefreshRate.Text = "минут";
			// 
			// btnChangeRefreshRate
			// 
			this.btnChangeRefreshRate.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnChangeRefreshRate.Location = new System.Drawing.Point(391, 52);
			this.btnChangeRefreshRate.Name = "btnChangeRefreshRate";
			this.btnChangeRefreshRate.Size = new System.Drawing.Size(132, 20);
			this.btnChangeRefreshRate.TabIndex = 23;
			this.btnChangeRefreshRate.Text = "Применить";
			this.btnChangeRefreshRate.UseVisualStyleBackColor = true;
			this.btnChangeRefreshRate.Click += new System.EventHandler(this.btnChangeRefreshRate_Click);
			// 
			// lblRefresh
			// 
			this.lblRefresh.AutoSize = true;
			this.lblRefresh.Location = new System.Drawing.Point(9, 55);
			this.lblRefresh.Name = "lblRefresh";
			this.lblRefresh.Size = new System.Drawing.Size(148, 13);
			this.lblRefresh.TabIndex = 22;
			this.lblRefresh.Text = "Частота обновления: раз в ";
			// 
			// buttonStart
			// 
			this.buttonStart.Location = new System.Drawing.Point(391, 19);
			this.buttonStart.Name = "buttonStart";
			this.buttonStart.Size = new System.Drawing.Size(132, 21);
			this.buttonStart.TabIndex = 21;
			this.buttonStart.Text = "Стоп";
			this.buttonStart.UseVisualStyleBackColor = true;
			this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
			// 
			// textBoxCurrentIp
			// 
			this.textBoxCurrentIp.Location = new System.Drawing.Point(130, 20);
			this.textBoxCurrentIp.Name = "textBoxCurrentIp";
			this.textBoxCurrentIp.ReadOnly = true;
			this.textBoxCurrentIp.Size = new System.Drawing.Size(237, 20);
			this.textBoxCurrentIp.TabIndex = 20;
			// 
			// labelCurrentIp
			// 
			this.labelCurrentIp.AutoSize = true;
			this.labelCurrentIp.Location = new System.Drawing.Point(9, 20);
			this.labelCurrentIp.Name = "labelCurrentIp";
			this.labelCurrentIp.Size = new System.Drawing.Size(101, 13);
			this.labelCurrentIp.TabIndex = 19;
			this.labelCurrentIp.Text = "Текущий IP адрес:";
			// 
			// groupBoxARecord
			// 
			this.groupBoxARecord.Controls.Add(this.dataGridViewDomainInfo);
			this.groupBoxARecord.Location = new System.Drawing.Point(0, 78);
			this.groupBoxARecord.Name = "groupBoxARecord";
			this.groupBoxARecord.Size = new System.Drawing.Size(547, 201);
			this.groupBoxARecord.TabIndex = 18;
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
			this.dataGridViewDomainInfo.Location = new System.Drawing.Point(20, 18);
			this.dataGridViewDomainInfo.Name = "dataGridViewDomainInfo";
			this.dataGridViewDomainInfo.Size = new System.Drawing.Size(521, 177);
			this.dataGridViewDomainInfo.TabIndex = 2;
			this.dataGridViewDomainInfo.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDomainInfo_CellDoubleClick);
			this.dataGridViewDomainInfo.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dataGridViewDomainInfo_RowsRemoved);
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
			// tabPageLogs
			// 
			this.tabPageLogs.Controls.Add(this.richTextBoxLogs);
			this.tabPageLogs.Location = new System.Drawing.Point(4, 22);
			this.tabPageLogs.Name = "tabPageLogs";
			this.tabPageLogs.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageLogs.Size = new System.Drawing.Size(553, 312);
			this.tabPageLogs.TabIndex = 1;
			this.tabPageLogs.Text = "Логи";
			this.tabPageLogs.UseVisualStyleBackColor = true;
			// 
			// labelVersion
			// 
			this.labelVersion.AutoSize = true;
			this.labelVersion.Location = new System.Drawing.Point(505, 353);
			this.labelVersion.Name = "labelVersion";
			this.labelVersion.Size = new System.Drawing.Size(64, 13);
			this.labelVersion.TabIndex = 29;
			this.labelVersion.Text = "labelVersion";
			// 
			// richTextBoxLogs
			// 
			this.richTextBoxLogs.Dock = System.Windows.Forms.DockStyle.Fill;
			this.richTextBoxLogs.Location = new System.Drawing.Point(3, 3);
			this.richTextBoxLogs.Name = "richTextBoxLogs";
			this.richTextBoxLogs.Size = new System.Drawing.Size(547, 306);
			this.richTextBoxLogs.TabIndex = 0;
			this.richTextBoxLogs.Text = "";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(584, 373);
			this.Controls.Add(this.labelVersion);
			this.Controls.Add(this.tabControl);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.Text = "DDNS через Яндекс API";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.Resize += new System.EventHandler(this.MainForm_Resize);
			((System.ComponentModel.ISupportInitialize)(this.domainInfoBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dbDomainInfoDataSet)).EndInit();
			this.tabControl.ResumeLayout(false);
			this.tabPageSetting.ResumeLayout(false);
			this.tabPageSetting.PerformLayout();
			this.groupBoxARecord.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewDomainInfo)).EndInit();
			this.tabPageLogs.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

		private System.Windows.Forms.NotifyIcon notifyIcon;
        private DbDomainInfoDataSet dbDomainInfoDataSet;
        private System.Windows.Forms.BindingSource domainInfoBindingSource;
		private DbDomainInfoDataSetTableAdapters.DomainInfoTableAdapter domainInfoTableAdapter;
		private System.Windows.Forms.TabControl tabControl;
		private System.Windows.Forms.TabPage tabPageSetting;
		private System.Windows.Forms.Button btnExportToCsv;
		private System.Windows.Forms.Button btnImportFromCsv;
		private System.Windows.Forms.TextBox tbRefreshRate;
		private System.Windows.Forms.Label lblRefreshRate;
		private System.Windows.Forms.Button btnChangeRefreshRate;
		private System.Windows.Forms.Label lblRefresh;
		private System.Windows.Forms.Button buttonStart;
		private System.Windows.Forms.TextBox textBoxCurrentIp;
		private System.Windows.Forms.Label labelCurrentIp;
		private System.Windows.Forms.GroupBox groupBoxARecord;
		private System.Windows.Forms.DataGridView dataGridViewDomainInfo;
		private System.Windows.Forms.DataGridViewTextBoxColumn tokenDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn Id;
		private System.Windows.Forms.DataGridViewTextBoxColumn subDomainDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn domainDataGridViewTextBoxColumn;
		private System.Windows.Forms.TabPage tabPageLogs;
		private System.Windows.Forms.Label labelVersion;
		private System.Windows.Forms.RichTextBox richTextBoxLogs;
    }
}

