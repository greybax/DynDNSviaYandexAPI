namespace GUI.Forms
{
    partial class DomainInfoForm
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
            this.textBoxToken = new System.Windows.Forms.TextBox();
            this.textBoxSubDomain = new System.Windows.Forms.TextBox();
            this.textBoxDomain = new System.Windows.Forms.TextBox();
            this.buttonInsert = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelToken = new System.Windows.Forms.Label();
            this.labelSubDomain = new System.Windows.Forms.Label();
            this.labelDomain = new System.Windows.Forms.Label();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.labelTtl = new System.Windows.Forms.Label();
            this.textBoxTtl = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBoxToken
            // 
            this.textBoxToken.Location = new System.Drawing.Point(71, 14);
            this.textBoxToken.Name = "textBoxToken";
            this.textBoxToken.Size = new System.Drawing.Size(224, 20);
            this.textBoxToken.TabIndex = 0;
            // 
            // textBoxSubDomain
            // 
            this.textBoxSubDomain.Location = new System.Drawing.Point(71, 40);
            this.textBoxSubDomain.Name = "textBoxSubDomain";
            this.textBoxSubDomain.Size = new System.Drawing.Size(224, 20);
            this.textBoxSubDomain.TabIndex = 1;
            // 
            // textBoxDomain
            // 
            this.textBoxDomain.Location = new System.Drawing.Point(71, 66);
            this.textBoxDomain.Name = "textBoxDomain";
            this.textBoxDomain.Size = new System.Drawing.Size(224, 20);
            this.textBoxDomain.TabIndex = 2;
            // 
            // buttonInsert
            // 
            this.buttonInsert.Location = new System.Drawing.Point(12, 144);
            this.buttonInsert.Name = "buttonInsert";
            this.buttonInsert.Size = new System.Drawing.Size(84, 23);
            this.buttonInsert.TabIndex = 3;
            this.buttonInsert.Text = "Сохранить";
            this.buttonInsert.UseVisualStyleBackColor = true;
            this.buttonInsert.Click += new System.EventHandler(this.buttonInsert_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(202, 144);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(94, 23);
            this.buttonCancel.TabIndex = 6;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // labelToken
            // 
            this.labelToken.AutoSize = true;
            this.labelToken.Location = new System.Drawing.Point(12, 17);
            this.labelToken.Name = "labelToken";
            this.labelToken.Size = new System.Drawing.Size(38, 13);
            this.labelToken.TabIndex = 5;
            this.labelToken.Text = "Токен";
            // 
            // labelSubDomain
            // 
            this.labelSubDomain.AutoSize = true;
            this.labelSubDomain.Location = new System.Drawing.Point(12, 40);
            this.labelSubDomain.Name = "labelSubDomain";
            this.labelSubDomain.Size = new System.Drawing.Size(59, 13);
            this.labelSubDomain.TabIndex = 6;
            this.labelSubDomain.Text = "Поддомен";
            // 
            // labelDomain
            // 
            this.labelDomain.AutoSize = true;
            this.labelDomain.Location = new System.Drawing.Point(12, 69);
            this.labelDomain.Name = "labelDomain";
            this.labelDomain.Size = new System.Drawing.Size(42, 13);
            this.labelDomain.TabIndex = 7;
            this.labelDomain.Text = "Домен";
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(102, 144);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(94, 23);
            this.buttonDelete.TabIndex = 5;
            this.buttonDelete.Text = "Удалить";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(12, 144);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(84, 23);
            this.buttonUpdate.TabIndex = 4;
            this.buttonUpdate.Text = "Обновить";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Visible = false;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // labelTtl
            // 
            this.labelTtl.AutoSize = true;
            this.labelTtl.Location = new System.Drawing.Point(12, 98);
            this.labelTtl.Name = "labelTtl";
            this.labelTtl.Size = new System.Drawing.Size(27, 13);
            this.labelTtl.TabIndex = 10;
            this.labelTtl.Text = "TTL";
            // 
            // textBoxTtl
            // 
            this.textBoxTtl.Location = new System.Drawing.Point(71, 95);
            this.textBoxTtl.Name = "textBoxTtl";
            this.textBoxTtl.Size = new System.Drawing.Size(224, 20);
            this.textBoxTtl.TabIndex = 3;
            // 
            // DomainInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 187);
            this.Controls.Add(this.textBoxTtl);
            this.Controls.Add(this.labelTtl);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.labelDomain);
            this.Controls.Add(this.labelSubDomain);
            this.Controls.Add(this.labelToken);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonInsert);
            this.Controls.Add(this.textBoxDomain);
            this.Controls.Add(this.textBoxSubDomain);
            this.Controls.Add(this.textBoxToken);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DomainInfoForm";
            this.Text = "Информация";
            this.Load += new System.EventHandler(this.DomainInfoForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxToken;
        private System.Windows.Forms.TextBox textBoxSubDomain;
        private System.Windows.Forms.TextBox textBoxDomain;
        private System.Windows.Forms.Button buttonInsert;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelToken;
        private System.Windows.Forms.Label labelSubDomain;
        private System.Windows.Forms.Label labelDomain;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Label labelTtl;
        private System.Windows.Forms.TextBox textBoxTtl;
    }
}