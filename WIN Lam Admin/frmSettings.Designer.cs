namespace WIN_Lam_Admin
{
    partial class frmSettings
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
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtRole
            // 
            this.txtRole.Location = new System.Drawing.Point(159, 135);
            this.txtRole.Name = "txtRole";
            this.txtRole.ReadOnly = true;
            this.txtRole.Size = new System.Drawing.Size(86, 20);
            this.txtRole.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(81, 139);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Account Role";
            // 
            // txtAccountID
            // 
            this.txtAccountID.Location = new System.Drawing.Point(159, 108);
            this.txtAccountID.Name = "txtAccountID";
            this.txtAccountID.ReadOnly = true;
            this.txtAccountID.Size = new System.Drawing.Size(86, 20);
            this.txtAccountID.TabIndex = 16;
            // 
            // txtKey2
            // 
            this.txtKey2.Location = new System.Drawing.Point(159, 81);
            this.txtKey2.Name = "txtKey2";
            this.txtKey2.ReadOnly = true;
            this.txtKey2.Size = new System.Drawing.Size(86, 20);
            this.txtKey2.TabIndex = 14;
            // 
            // txtKey1
            // 
            this.txtKey1.Location = new System.Drawing.Point(159, 54);
            this.txtKey1.Name = "txtKey1";
            this.txtKey1.ReadOnly = true;
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
            this.groupBox1.Location = new System.Drawing.Point(274, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(233, 90);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Generate Random Password";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(60, 55);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(56, 13);
            this.lblPassword.TabIndex = 12;
            this.lblPassword.Text = "Password:";
            // 
            // txtLength
            // 
            this.txtLength.Location = new System.Drawing.Point(117, 25);
            this.txtLength.Name = "txtLength";
            this.txtLength.ReadOnly = true;
            this.txtLength.Size = new System.Drawing.Size(56, 20);
            this.txtLength.TabIndex = 11;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(117, 51);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.ReadOnly = true;
            this.txtPassword.Size = new System.Drawing.Size(100, 20);
            this.txtPassword.TabIndex = 9;
            // 
            // optYes
            // 
            this.optYes.AutoSize = true;
            this.optYes.Enabled = false;
            this.optYes.Location = new System.Drawing.Point(22, 26);
            this.optYes.Name = "optYes";
            this.optYes.Size = new System.Drawing.Size(43, 17);
            this.optYes.TabIndex = 6;
            this.optYes.TabStop = true;
            this.optYes.Text = "Yes";
            this.optYes.UseVisualStyleBackColor = true;
            // 
            // optNo
            // 
            this.optNo.AutoSize = true;
            this.optNo.Enabled = false;
            this.optNo.Location = new System.Drawing.Point(22, 53);
            this.optNo.Name = "optNo";
            this.optNo.Size = new System.Drawing.Size(39, 17);
            this.optNo.TabIndex = 7;
            this.optNo.TabStop = true;
            this.optNo.Text = "No";
            this.optNo.UseVisualStyleBackColor = true;
            // 
            // lblLength
            // 
            this.lblLength.AutoSize = true;
            this.lblLength.Location = new System.Drawing.Point(68, 28);
            this.lblLength.Name = "lblLength";
            this.lblLength.Size = new System.Drawing.Size(43, 13);
            this.lblLength.TabIndex = 10;
            this.lblLength.Text = "Length:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(60, 112);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Admin Account ID";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(66, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Encryption Key 2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(66, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Encryption Key 1";
            // 
            // txtPasswordDuration
            // 
            this.txtPasswordDuration.Location = new System.Drawing.Point(159, 27);
            this.txtPasswordDuration.Name = "txtPasswordDuration";
            this.txtPasswordDuration.ReadOnly = true;
            this.txtPasswordDuration.Size = new System.Drawing.Size(86, 20);
            this.txtPasswordDuration.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password Duration (Days)";
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 202);
            this.Controls.Add(this.txtRole);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtAccountID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtKey2);
            this.Controls.Add(this.txtPasswordDuration);
            this.Controls.Add(this.txtKey1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label5);
            this.Name = "frmSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.frmSettings_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtRole;
        private System.Windows.Forms.Label label6;
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
    }
}