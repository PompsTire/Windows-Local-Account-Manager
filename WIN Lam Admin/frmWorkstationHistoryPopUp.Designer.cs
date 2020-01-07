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
            this.dgvWorkstationHistory = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWorkstationHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvWorkstationHistory
            // 
            this.dgvWorkstationHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWorkstationHistory.Location = new System.Drawing.Point(56, 57);
            this.dgvWorkstationHistory.Name = "dgvWorkstationHistory";
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
            this.Text = "frmWorkstationHistoryPopUp";
            this.Load += new System.EventHandler(this.frmWorkstationHistoryPopUp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvWorkstationHistory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvWorkstationHistory;
    }
}