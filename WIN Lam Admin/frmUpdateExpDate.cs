using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WIN_Lam_Admin
{
    public partial class frmUpdateExpDate : Form
    {
        private DateTime m_expDate;
        private bool m_isCancelled;

        public frmUpdateExpDate()
        {
            InitializeComponent();
        }

        private void frmUpdateExpDate_Load(object sender, EventArgs e)
        {
            m_isCancelled = true;
            dtpEffectiveDate.Value = m_expDate;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            m_expDate = dtpEffectiveDate.Value;
            m_isCancelled = false;
            this.Hide();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            m_isCancelled = true;
            this.Hide();
        }

        public DateTime ExpDate { get => m_expDate; set => m_expDate = value; }

        public bool IsCancelled { get => m_isCancelled; }
    }
}
