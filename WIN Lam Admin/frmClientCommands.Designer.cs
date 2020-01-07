namespace WIN_Lam_Admin
{
    partial class frmClientCommands
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtAccountID = new System.Windows.Forms.TextBox();
            this.lblAccountID = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.rdoChangePassword = new System.Windows.Forms.RadioButton();
            this.txtPassword2 = new System.Windows.Forms.TextBox();
            this.lbl2 = new System.Windows.Forms.Label();
            this.txtPassword1 = new System.Windows.Forms.TextBox();
            this.lbl1 = new System.Windows.Forms.Label();
            this.rdoDisable = new System.Windows.Forms.RadioButton();
            this.rdoEnable = new System.Windows.Forms.RadioButton();
            this.rdoDelete = new System.Windows.Forms.RadioButton();
            this.rdoCreateNew = new System.Windows.Forms.RadioButton();
            this.dgvWShistory = new System.Windows.Forms.DataGridView();
            this.AccountCommand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccountName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccountPassword = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NewPassword = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CommandStatus = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.CommandExecutedDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UpdatedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UpdatedDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWShistory)).BeginInit();
            this.SuspendLayout();
            // 
            // txtAccountID
            // 
            this.txtAccountID.Location = new System.Drawing.Point(193, 15);
            this.txtAccountID.Name = "txtAccountID";
            this.txtAccountID.Size = new System.Drawing.Size(175, 20);
            this.txtAccountID.TabIndex = 1;
            // 
            // lblAccountID
            // 
            this.lblAccountID.Location = new System.Drawing.Point(123, 18);
            this.lblAccountID.Name = "lblAccountID";
            this.lblAccountID.Size = new System.Drawing.Size(64, 15);
            this.lblAccountID.TabIndex = 8;
            this.lblAccountID.Text = "Account ID";
            this.lblAccountID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.txtUser);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnUpdate);
            this.panel1.Controls.Add(this.rdoChangePassword);
            this.panel1.Controls.Add(this.txtPassword2);
            this.panel1.Controls.Add(this.lbl2);
            this.panel1.Controls.Add(this.txtPassword1);
            this.panel1.Controls.Add(this.lbl1);
            this.panel1.Controls.Add(this.rdoDisable);
            this.panel1.Controls.Add(this.rdoEnable);
            this.panel1.Controls.Add(this.rdoDelete);
            this.panel1.Controls.Add(this.rdoCreateNew);
            this.panel1.Controls.Add(this.txtAccountID);
            this.panel1.Controls.Add(this.lblAccountID);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(879, 132);
            this.panel1.TabIndex = 11;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(397, 44);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(92, 25);
            this.btnCancel.TabIndex = 22;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(397, 13);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(92, 25);
            this.btnUpdate.TabIndex = 21;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // rdoChangePassword
            // 
            this.rdoChangePassword.AutoSize = true;
            this.rdoChangePassword.Location = new System.Drawing.Point(17, 102);
            this.rdoChangePassword.Name = "rdoChangePassword";
            this.rdoChangePassword.Size = new System.Drawing.Size(111, 17);
            this.rdoChangePassword.TabIndex = 18;
            this.rdoChangePassword.Text = "Change Password";
            this.rdoChangePassword.UseVisualStyleBackColor = true;
            // 
            // txtPassword2
            // 
            this.txtPassword2.Location = new System.Drawing.Point(193, 67);
            this.txtPassword2.Name = "txtPassword2";
            this.txtPassword2.Size = new System.Drawing.Size(175, 20);
            this.txtPassword2.TabIndex = 20;
            // 
            // lbl2
            // 
            this.lbl2.Location = new System.Drawing.Point(113, 69);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(74, 18);
            this.lbl2.TabIndex = 16;
            this.lbl2.Text = "lbl2";
            this.lbl2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPassword1
            // 
            this.txtPassword1.Location = new System.Drawing.Point(193, 41);
            this.txtPassword1.Name = "txtPassword1";
            this.txtPassword1.Size = new System.Drawing.Size(175, 20);
            this.txtPassword1.TabIndex = 10;
            // 
            // lbl1
            // 
            this.lbl1.Location = new System.Drawing.Point(110, 43);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(77, 18);
            this.lbl1.TabIndex = 14;
            this.lbl1.Text = "lbl1";
            this.lbl1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // rdoDisable
            // 
            this.rdoDisable.AutoSize = true;
            this.rdoDisable.Location = new System.Drawing.Point(17, 79);
            this.rdoDisable.Name = "rdoDisable";
            this.rdoDisable.Size = new System.Drawing.Size(60, 17);
            this.rdoDisable.TabIndex = 13;
            this.rdoDisable.Text = "Disable";
            this.rdoDisable.UseVisualStyleBackColor = true;
            // 
            // rdoEnable
            // 
            this.rdoEnable.AutoSize = true;
            this.rdoEnable.Location = new System.Drawing.Point(17, 56);
            this.rdoEnable.Name = "rdoEnable";
            this.rdoEnable.Size = new System.Drawing.Size(58, 17);
            this.rdoEnable.TabIndex = 12;
            this.rdoEnable.Text = "Enable";
            this.rdoEnable.UseVisualStyleBackColor = true;
            // 
            // rdoDelete
            // 
            this.rdoDelete.AutoSize = true;
            this.rdoDelete.Location = new System.Drawing.Point(17, 33);
            this.rdoDelete.Name = "rdoDelete";
            this.rdoDelete.Size = new System.Drawing.Size(59, 17);
            this.rdoDelete.TabIndex = 11;
            this.rdoDelete.Text = "Delete ";
            this.rdoDelete.UseVisualStyleBackColor = true;
            // 
            // rdoCreateNew
            // 
            this.rdoCreateNew.AutoSize = true;
            this.rdoCreateNew.Location = new System.Drawing.Point(17, 10);
            this.rdoCreateNew.Name = "rdoCreateNew";
            this.rdoCreateNew.Size = new System.Drawing.Size(81, 17);
            this.rdoCreateNew.TabIndex = 10;
            this.rdoCreateNew.Text = "Create New";
            this.rdoCreateNew.UseVisualStyleBackColor = true;
            // 
            // dgvWShistory
            // 
            this.dgvWShistory.AllowUserToAddRows = false;
            this.dgvWShistory.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.IndianRed;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvWShistory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvWShistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWShistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AccountCommand,
            this.AccountName,
            this.AccountPassword,
            this.NewPassword,
            this.CommandStatus,
            this.CommandExecutedDateTime,
            this.UpdatedBy,
            this.UpdatedDateTime});
            this.dgvWShistory.EnableHeadersVisualStyles = false;
            this.dgvWShistory.Location = new System.Drawing.Point(12, 147);
            this.dgvWShistory.Name = "dgvWShistory";
            this.dgvWShistory.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvWShistory.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvWShistory.Size = new System.Drawing.Size(510, 143);
            this.dgvWShistory.TabIndex = 12;
            this.dgvWShistory.TabStop = false;
            // 
            // AccountCommand
            // 
            this.AccountCommand.DataPropertyName = "AccountCommand";
            this.AccountCommand.HeaderText = "Action";
            this.AccountCommand.Name = "AccountCommand";
            this.AccountCommand.ReadOnly = true;
            this.AccountCommand.Width = 120;
            // 
            // AccountName
            // 
            this.AccountName.DataPropertyName = "AccountName";
            this.AccountName.HeaderText = "Account";
            this.AccountName.Name = "AccountName";
            this.AccountName.ReadOnly = true;
            // 
            // AccountPassword
            // 
            this.AccountPassword.DataPropertyName = "CurrentPassword";
            this.AccountPassword.HeaderText = "Current Password";
            this.AccountPassword.Name = "AccountPassword";
            this.AccountPassword.ReadOnly = true;
            // 
            // NewPassword
            // 
            this.NewPassword.DataPropertyName = "NewPassword";
            this.NewPassword.HeaderText = "New Password";
            this.NewPassword.Name = "NewPassword";
            this.NewPassword.ReadOnly = true;
            // 
            // CommandStatus
            // 
            this.CommandStatus.DataPropertyName = "CommandCompleted";
            this.CommandStatus.HeaderText = "Completed";
            this.CommandStatus.Name = "CommandStatus";
            this.CommandStatus.ReadOnly = true;
            this.CommandStatus.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CommandStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // CommandExecutedDateTime
            // 
            this.CommandExecutedDateTime.DataPropertyName = "CommandExecutedDateTime";
            this.CommandExecutedDateTime.HeaderText = "Completed On";
            this.CommandExecutedDateTime.Name = "CommandExecutedDateTime";
            this.CommandExecutedDateTime.ReadOnly = true;
            // 
            // UpdatedBy
            // 
            this.UpdatedBy.DataPropertyName = "UpdatedBy";
            this.UpdatedBy.HeaderText = "Updated By";
            this.UpdatedBy.Name = "UpdatedBy";
            this.UpdatedBy.ReadOnly = true;
            // 
            // UpdatedDateTime
            // 
            this.UpdatedDateTime.DataPropertyName = "UpdatedDateTime";
            this.UpdatedDateTime.HeaderText = "Last Updated";
            this.UpdatedDateTime.Name = "UpdatedDateTime";
            this.UpdatedDateTime.ReadOnly = true;
            this.UpdatedDateTime.Width = 130;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(596, 82);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(122, 36);
            this.button1.TabIndex = 23;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(596, 56);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(175, 20);
            this.txtUser.TabIndex = 24;
            // 
            // frmClientCommands
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 434);
            this.Controls.Add(this.dgvWShistory);
            this.Controls.Add(this.panel1);
            this.Name = "frmClientCommands";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmClientCommands";
            this.Load += new System.EventHandler(this.frmClientCommands_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWShistory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txtAccountID;
        private System.Windows.Forms.Label lblAccountID;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvWShistory;
        private System.Windows.Forms.TextBox txtPassword2;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.TextBox txtPassword1;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.RadioButton rdoDisable;
        private System.Windows.Forms.RadioButton rdoEnable;
        private System.Windows.Forms.RadioButton rdoDelete;
        private System.Windows.Forms.RadioButton rdoCreateNew;
        private System.Windows.Forms.RadioButton rdoChangePassword;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccountCommand;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccountName;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccountPassword;
        private System.Windows.Forms.DataGridViewTextBoxColumn NewPassword;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CommandStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn CommandExecutedDateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn UpdatedBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn UpdatedDateTime;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtUser;
    }
}