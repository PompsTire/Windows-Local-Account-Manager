namespace WIN_Lam_Admin
{
    partial class frmAdmin
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtRole = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAccountID = new System.Windows.Forms.TextBox();
            this.txtKey2 = new System.Windows.Forms.TextBox();
            this.txtKey1 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtLength = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.optYes = new System.Windows.Forms.RadioButton();
            this.optNo = new System.Windows.Forms.RadioButton();
            this.lblLength = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPasswordDuration = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.dgWorkstations = new System.Windows.Forms.DataGridView();
            this.PKID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WorkstationName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AdminAcctName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AdminPwd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unencrypted = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastUpdatedDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NextUpdateDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgWorkstations)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtRole);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtAccountID);
            this.panel1.Controls.Add(this.txtKey2);
            this.panel1.Controls.Add(this.txtKey1);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtPasswordDuration);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Enabled = false;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(219, 390);
            this.panel1.TabIndex = 0;
            // 
            // txtRole
            // 
            this.txtRole.Location = new System.Drawing.Point(105, 141);
            this.txtRole.Name = "txtRole";
            this.txtRole.Size = new System.Drawing.Size(86, 20);
            this.txtRole.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(27, 144);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Account Role";
            // 
            // txtAccountID
            // 
            this.txtAccountID.Location = new System.Drawing.Point(105, 115);
            this.txtAccountID.Name = "txtAccountID";
            this.txtAccountID.Size = new System.Drawing.Size(86, 20);
            this.txtAccountID.TabIndex = 16;
            // 
            // txtKey2
            // 
            this.txtKey2.Location = new System.Drawing.Point(105, 88);
            this.txtKey2.Name = "txtKey2";
            this.txtKey2.Size = new System.Drawing.Size(86, 20);
            this.txtKey2.TabIndex = 14;
            // 
            // txtKey1
            // 
            this.txtKey1.Location = new System.Drawing.Point(105, 62);
            this.txtKey1.Name = "txtKey1";
            this.txtKey1.Size = new System.Drawing.Size(86, 20);
            this.txtKey1.TabIndex = 13;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblPassword);
            this.groupBox1.Controls.Add(this.txtLength);
            this.groupBox1.Controls.Add(this.txtPassword);
            this.groupBox1.Controls.Add(this.optYes);
            this.groupBox1.Controls.Add(this.optNo);
            this.groupBox1.Controls.Add(this.lblLength);
            this.groupBox1.Location = new System.Drawing.Point(15, 184);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(173, 102);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Generate Random Password";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(10, 72);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(56, 13);
            this.lblPassword.TabIndex = 12;
            this.lblPassword.Text = "Password:";
            // 
            // txtLength
            // 
            this.txtLength.Location = new System.Drawing.Point(100, 20);
            this.txtLength.Name = "txtLength";
            this.txtLength.Size = new System.Drawing.Size(56, 20);
            this.txtLength.TabIndex = 11;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(67, 68);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(100, 20);
            this.txtPassword.TabIndex = 9;
            // 
            // optYes
            // 
            this.optYes.AutoSize = true;
            this.optYes.Location = new System.Drawing.Point(5, 21);
            this.optYes.Name = "optYes";
            this.optYes.Size = new System.Drawing.Size(43, 17);
            this.optYes.TabIndex = 6;
            this.optYes.TabStop = true;
            this.optYes.Text = "Yes";
            this.optYes.UseVisualStyleBackColor = true;
            this.optYes.CheckedChanged += new System.EventHandler(this.optYes_CheckedChanged);
            // 
            // optNo
            // 
            this.optNo.AutoSize = true;
            this.optNo.Location = new System.Drawing.Point(5, 44);
            this.optNo.Name = "optNo";
            this.optNo.Size = new System.Drawing.Size(39, 17);
            this.optNo.TabIndex = 7;
            this.optNo.TabStop = true;
            this.optNo.Text = "No";
            this.optNo.UseVisualStyleBackColor = true;
            this.optNo.CheckedChanged += new System.EventHandler(this.rdoNo_CheckedChanged);
            // 
            // lblLength
            // 
            this.lblLength.AutoSize = true;
            this.lblLength.Location = new System.Drawing.Point(51, 23);
            this.lblLength.Name = "lblLength";
            this.lblLength.Size = new System.Drawing.Size(43, 13);
            this.lblLength.TabIndex = 10;
            this.lblLength.Text = "Length:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Admin Account ID";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Encryption Key 2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Encryption Key 1";
            // 
            // txtPasswordDuration
            // 
            this.txtPasswordDuration.Location = new System.Drawing.Point(105, 35);
            this.txtPasswordDuration.Name = "txtPasswordDuration";
            this.txtPasswordDuration.Size = new System.Drawing.Size(86, 20);
            this.txtPasswordDuration.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password Duration";
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(217, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Settings";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(362, 3);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(82, 29);
            this.btnRefresh.TabIndex = 19;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // dgWorkstations
            // 
            this.dgWorkstations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgWorkstations.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PKID,
            this.WorkstationName,
            this.AdminAcctName,
            this.AdminPwd,
            this.Unencrypted,
            this.LastUpdatedDateTime,
            this.NextUpdateDateTime});
            this.dgWorkstations.Location = new System.Drawing.Point(238, 18);
            this.dgWorkstations.Name = "dgWorkstations";
            this.dgWorkstations.Size = new System.Drawing.Size(402, 144);
            this.dgWorkstations.TabIndex = 2;
            // 
            // PKID
            // 
            this.PKID.DataPropertyName = "PKID";
            this.PKID.HeaderText = "PKID";
            this.PKID.Name = "PKID";
            this.PKID.Visible = false;
            // 
            // WorkstationName
            // 
            this.WorkstationName.DataPropertyName = "WorkstationName";
            this.WorkstationName.HeaderText = "PC";
            this.WorkstationName.Name = "WorkstationName";
            // 
            // AdminAcctName
            // 
            this.AdminAcctName.DataPropertyName = "AdminAcctName";
            this.AdminAcctName.HeaderText = "Account ID";
            this.AdminAcctName.Name = "AdminAcctName";
            // 
            // AdminPwd
            // 
            this.AdminPwd.DataPropertyName = "AdminPwd";
            this.AdminPwd.HeaderText = "Password (Encrypted)";
            this.AdminPwd.Name = "AdminPwd";
            // 
            // Unencrypted
            // 
            this.Unencrypted.DataPropertyName = "Unencrypted";
            this.Unencrypted.HeaderText = "Unencrypted Password";
            this.Unencrypted.Name = "Unencrypted";
            // 
            // LastUpdatedDateTime
            // 
            this.LastUpdatedDateTime.DataPropertyName = "LastUpdatedDateTime";
            this.LastUpdatedDateTime.HeaderText = "Last Updated";
            this.LastUpdatedDateTime.Name = "LastUpdatedDateTime";
            // 
            // NextUpdateDateTime
            // 
            this.NextUpdateDateTime.DataPropertyName = "NextUpdateDateTime";
            this.NextUpdateDateTime.HeaderText = "Next Update";
            this.NextUpdateDateTime.Name = "NextUpdateDateTime";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnRefresh);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 390);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(863, 60);
            this.panel2.TabIndex = 20;
            // 
            // frmAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 450);
            this.Controls.Add(this.dgWorkstations);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "frmAdmin";
            this.Load += new System.EventHandler(this.frmAdmin_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgWorkstations)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtAccountID;
        private System.Windows.Forms.TextBox txtKey2;
        private System.Windows.Forms.TextBox txtKey1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtLength;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.RadioButton optYes;
        private System.Windows.Forms.RadioButton optNo;
        private System.Windows.Forms.Label lblLength;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPasswordDuration;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRole;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgWorkstations;
        private System.Windows.Forms.DataGridViewTextBoxColumn PKID;
        private System.Windows.Forms.DataGridViewTextBoxColumn WorkstationName;
        private System.Windows.Forms.DataGridViewTextBoxColumn AdminAcctName;
        private System.Windows.Forms.DataGridViewTextBoxColumn AdminPwd;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unencrypted;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastUpdatedDateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn NextUpdateDateTime;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Panel panel2;
    }
}

