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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgWorkstationsXX = new System.Windows.Forms.DataGrid();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.slblWhoAreYou = new System.Windows.Forms.ToolStripStatusLabel();
            this.dgvWorkstations = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgWorkstationsXX)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWorkstations)).BeginInit();
            this.SuspendLayout();
            // 
            // dgWorkstationsXX
            // 
            this.dgWorkstationsXX.AlternatingBackColor = System.Drawing.Color.Silver;
            this.dgWorkstationsXX.BackColor = System.Drawing.Color.White;
            this.dgWorkstationsXX.CaptionBackColor = System.Drawing.Color.Maroon;
            this.dgWorkstationsXX.CaptionFont = new System.Drawing.Font("Tahoma", 8F);
            this.dgWorkstationsXX.CaptionForeColor = System.Drawing.Color.White;
            this.dgWorkstationsXX.CaptionText = "Workstation Registered Local Accounts";
            this.dgWorkstationsXX.DataMember = "";
            this.dgWorkstationsXX.Font = new System.Drawing.Font("Tahoma", 8F);
            this.dgWorkstationsXX.ForeColor = System.Drawing.Color.Black;
            this.dgWorkstationsXX.GridLineColor = System.Drawing.Color.Silver;
            this.dgWorkstationsXX.HeaderBackColor = System.Drawing.Color.Silver;
            this.dgWorkstationsXX.HeaderFont = new System.Drawing.Font("Tahoma", 8F);
            this.dgWorkstationsXX.HeaderForeColor = System.Drawing.Color.Black;
            this.dgWorkstationsXX.LinkColor = System.Drawing.Color.Maroon;
            this.dgWorkstationsXX.Location = new System.Drawing.Point(43, 190);
            this.dgWorkstationsXX.Name = "dgWorkstationsXX";
            this.dgWorkstationsXX.ParentRowsBackColor = System.Drawing.Color.Silver;
            this.dgWorkstationsXX.ParentRowsForeColor = System.Drawing.Color.Black;
            this.dgWorkstationsXX.ReadOnly = true;
            this.dgWorkstationsXX.SelectionBackColor = System.Drawing.Color.Maroon;
            this.dgWorkstationsXX.SelectionForeColor = System.Drawing.Color.White;
            this.dgWorkstationsXX.Size = new System.Drawing.Size(399, 191);
            this.dgWorkstationsXX.TabIndex = 22;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.slblWhoAreYou});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(781, 22);
            this.statusStrip1.TabIndex = 23;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // slblWhoAreYou
            // 
            this.slblWhoAreYou.Name = "slblWhoAreYou";
            this.slblWhoAreYou.Size = new System.Drawing.Size(118, 17);
            this.slblWhoAreYou.Text = "toolStripStatusLabel1";
            // 
            // dgvWorkstations
            // 
            this.dgvWorkstations.AllowUserToAddRows = false;
            this.dgvWorkstations.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.dgvWorkstations.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvWorkstations.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvWorkstations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWorkstations.Location = new System.Drawing.Point(43, 30);
            this.dgvWorkstations.Name = "dgvWorkstations";
            this.dgvWorkstations.ReadOnly = true;
            this.dgvWorkstations.RowHeadersWidth = 10;
            this.dgvWorkstations.Size = new System.Drawing.Size(399, 135);
            this.dgvWorkstations.TabIndex = 24;
            // 
            // frmAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(781, 450);
            this.Controls.Add(this.dgvWorkstations);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.dgWorkstationsXX);
            this.Name = "frmAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Windows Local Account Manager Admin";
            this.Load += new System.EventHandler(this.frmAdmin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgWorkstationsXX)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWorkstations)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGrid dgWorkstationsXX;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel slblWhoAreYou;
        private System.Windows.Forms.DataGridView dgvWorkstations;
    }
}

