namespace WIN_Lam_Admin
{
    partial class frmWorkstationHistoryPopUp
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
            this.dgvWorkstationHistory = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWorkstationHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvWorkstationHistory
            // 
            this.dgvWorkstationHistory.AllowUserToAddRows = false;
            this.dgvWorkstationHistory.AllowUserToDeleteRows = false;
            this.dgvWorkstationHistory.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgvWorkstationHistory.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvWorkstationHistory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvWorkstationHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWorkstationHistory.EnableHeadersVisualStyles = false;
            this.dgvWorkstationHistory.Location = new System.Drawing.Point(56, 57);
            this.dgvWorkstationHistory.MultiSelect = false;
            this.dgvWorkstationHistory.Name = "dgvWorkstationHistory";
            this.dgvWorkstationHistory.RowHeadersWidth = 10;
            this.dgvWorkstationHistory.Size = new System.Drawing.Size(240, 150);
            this.dgvWorkstationHistory.TabIndex = 0;
            // 
            // frmWorkstationHistoryPopUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 383);
            this.Controls.Add(this.dgvWorkstationHistory);
            this.Name = "frmWorkstationHistoryPopUp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmWorkstationHistoryPopUp";
            this.Load += new System.EventHandler(this.frmWorkstationHistoryPopUp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvWorkstationHistory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvWorkstationHistory;
    }
}