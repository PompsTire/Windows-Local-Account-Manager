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
    public partial class frmWorkstationHistoryPopUp : Form
    {
        public frmWorkstationHistoryPopUp()
        {
            InitializeComponent();
            WSHP_SelectedWorkstation = "";
        }

        private ContextMenu m_ctxGridMnu;
        private MenuItem mnuShowPassword;
        private DataRow m_selRow;
          
        private void frmWorkstationHistoryPopUp_Load(object sender, EventArgs e)
        {
            CreateCTXMenu();
            CustomizeGrid();
            LoadGrid();
            this.Text = "Account Update History For " + WSHP_SelectedWorkstation;
        }
        private void dgvWorkstationHistory_MouseDown(object sender, MouseEventArgs e)
        {
            int selRow = dgvWorkstationHistory.HitTest(e.X, e.Y).RowIndex;

            if(selRow > -1)
            {
                string selPKI = dgvWorkstationHistory.Rows[selRow].Cells[0].Value.ToString();
                string sFilter = "PKID=" + selPKI;
                DataRow[] drs;

                drs = WSHP_workStations.Select(sFilter);
                if(drs.Length > 0)
                {
                    m_selRow = drs[0];
                    m_ctxGridMnu.Show(dgvWorkstationHistory, new Point(e.X, e.Y));
                }
            }
        }

        private void mnu_ShowPassword(object sender, EventArgs e)
        {
            string encPwd = m_selRow["AdminPwd"].ToString();
            cls_AES objAes = new cls_AES();
            string unEnc = "";
            unEnc = objAes.SimpleDecryptWithPassword(encPwd, WSHP_Key1, WSHP_Key2.Length);
            m_selRow["MaskedPwd"] = unEnc;
        }

        private void CreateCTXMenu()
        {            
            dgvWorkstationHistory.MouseDown += new MouseEventHandler(dgvWorkstationHistory_MouseDown);
            m_ctxGridMnu = new ContextMenu();
            mnuShowPassword = new MenuItem("Show Password", mnu_ShowPassword);
            m_ctxGridMnu.MenuItems.Add(mnuShowPassword);
        }

        private void LoadGrid()
        {
            dgvWorkstationHistory.Dock = DockStyle.Fill;
            dgvWorkstationHistory.DataSource = WSHP_workStations;
        }

        private void CustomizeGrid()
        {
            DataGridViewTextBoxColumn[] dc = new DataGridViewTextBoxColumn[8];

            dc[0] = new DataGridViewTextBoxColumn();
            dc[0].DataPropertyName = "PKID";
            dc[0].Name = "PKID";
            dc[0].Visible = false;

            dc[1] = new DataGridViewTextBoxColumn();
            dc[1].DataPropertyName = "WorkstationName";
            dc[1].Name = "WorkstationName";
            dc[1].HeaderText = "Workstation";
            dc[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dc[1].Visible = false;
            dc[1].Width = 100;

            dc[2] = new DataGridViewTextBoxColumn();
            dc[2].DataPropertyName = "AdminAcctName";
            dc[2].Name = "AdminAcctName";
            dc[2].HeaderText = "Account ID";
            dc[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dc[2].Visible = true;
            dc[2].Width = 120;

            dc[3] = new DataGridViewTextBoxColumn();
            dc[3].DataPropertyName = "MaskedPwd";
            dc[3].Name = "MaskedPwd";
            dc[3].HeaderText = "Password";
            dc[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dc[3].Visible = true;
            dc[3].Width = 130;

            dc[4] = new DataGridViewTextBoxColumn();
            dc[4].DataPropertyName = "LastLoginDateTime";
            dc[4].Name = "LastLoginDateTime";
            dc[4].HeaderText = "Last Check-In";
            dc[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dc[4].Visible = true;
            dc[4].Width = 130;

            dc[5] = new DataGridViewTextBoxColumn();
            dc[5].DataPropertyName = "LastUpdatedDateTime";
            dc[5].Name = "LastUpdatedDateTime";
            dc[5].HeaderText = "Account Last Updated";
            dc[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dc[5].Visible = true;
            dc[5].Width = 130;

            dc[6] = new DataGridViewTextBoxColumn();
            dc[6].DataPropertyName = "NextUpdateDateTime";
            dc[6].Name = "NextUpdateDateTime";
            dc[6].HeaderText = "Next Account Update";
            dc[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dc[6].Visible = true;
            dc[6].Width = 130;

            dc[7] = new DataGridViewTextBoxColumn();
            dc[7].DataPropertyName = "AdminPwd";
            dc[7].Name = "AdminPwd";
            dc[7].HeaderText = "Encrypted Password";
            dc[7].Visible = false;
            dc[7].Width = 1;

            dgvWorkstationHistory.Columns.AddRange(dc);
        }
        
        public DataTable WSHP_workStations { get; set; }

        public string WSHP_Key1 { get; set; }
        public string WSHP_Key2 { get; set; }

        public string WSHP_SelectedWorkstation { set; get; }

    }
}
