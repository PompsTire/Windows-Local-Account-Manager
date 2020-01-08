using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WIN_Lam_Admin
{
    public partial class frmClientCommands : Form
    {
        private string m_workstationName;
        private string m_command;
        private DataTable m_dtHistory;
        private string m_connStr;

        private string m_accountName;
        private string m_currentPassword;
        private string m_newPassword;
        private string m_updatedBy;
        private bool m_isDirty;

        public frmClientCommands()
        {
            InitializeComponent();
        }

        private void frmClientCommands_Load(object sender, EventArgs e)
        {
            lbl1.Visible = false;
            lbl2.Visible = false;
            txtPassword1.Visible = false;
            txtPassword2.Visible = false;
            m_command = "";
            this.Text = "Update Local Accounts For " + m_workstationName.ToUpper();

            txtAccountID.Focus();
            dgvWShistory.Dock = DockStyle.Fill;
            LoadHistComms();
            CreateEvents();
            txtAccountID.Enabled = false;
            m_isDirty = false;
        }

        private void CreateEvents()
        {
            rdoCreateNew.CheckedChanged += new EventHandler(rdo_SetComm);
            rdoDelete.CheckedChanged += new EventHandler(rdo_SetComm);
            rdoEnable.CheckedChanged += new EventHandler(rdo_SetComm);
            rdoDisable.CheckedChanged += new EventHandler(rdo_SetComm);
            rdoChangePassword.CheckedChanged += new EventHandler(rdo_SetComm);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateComm();
            resetAll();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rdo_SetComm(object sender, EventArgs e)
        {
            string sComm = "";
            RadioButton rdo = (RadioButton)sender;
            lbl1.Visible = false;
            lbl2.Visible = false;
            txtPassword1.Visible = false;
            txtPassword2.Visible = false;
            txtPassword1.Text = "";
            txtPassword2.Text = "";

            switch(rdo.Name)
            {
                case "rdoCreateNew":
                    {
                        lbl1.Text = "Password";
                        lbl1.Visible = true;
                        txtPassword1.Visible = true;
                        m_command = "NEW";
                        break;
                    }
                case "rdoEnable":
                    {
                        m_command = "ENABLE";
                        break;
                    }
                case "rdoDisable":
                    {
                        m_command = "DISABLE";
                        break;
                    }
                case "rdoDelete":
                    {
                        m_command = "DELETE";
                        break;
                    }
                case "rdoChangePassword":
                    {
                        lbl1.Text = "Old Password";
                        lbl2.Text = "New Password";
                        lbl1.Visible = true;
                        lbl2.Visible = true;
                        txtPassword1.Visible = true;
                        txtPassword2.Visible = true;
                        m_command = "CHANGEPASSWORD";
                        break;
                    }
            }
            txtAccountID.Enabled = true;
            txtAccountID.SelectAll();
            txtAccountID.Focus();
        }

        private void resetAll()
        {
            rdoChangePassword.Checked = false;
            rdoCreateNew.Checked = false;
            rdoDelete.Checked = false;
            rdoDisable.Checked = false;
            rdoEnable.Checked = false;
            txtAccountID.Text = "";
            txtPassword1.Text = "";
            txtPassword2.Text = "";
            lbl1.Visible = false;
            lbl2.Visible = false;
            txtPassword1.Visible = false;
            txtPassword2.Visible = false;
            rdoCreateNew.Focus();
            m_isDirty = false;
        }

        private void UpdateComm()
        {
            m_accountName = txtAccountID.Text;

            if (m_command == "NEW")
            {
                m_currentPassword = "";
                m_newPassword = txtPassword1.Text;
            }

            m_updatedBy = Environment.UserName;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                StringBuilder sb = new StringBuilder("Exec dbo.up_WS_Admin_InsertCustomCommand ");
                sb.Append("@WorkstationName = '" + m_workstationName + "', ");
                sb.Append("@AccountCommand = '" + m_command + "', ");
                sb.Append("@AccountName = '" + m_accountName + "', ");
                sb.Append("@CurrentPassword = '" + m_currentPassword + "', ");
                sb.Append("@NewPassword = '" + m_newPassword + "', ");
                sb.Append("@UpdatedBy = '" + m_updatedBy + "' ");

                SqlCommand objComm = new SqlCommand(sb.ToString(), new SqlConnection(m_connStr));
                objComm.Connection.Open();
                object objRtnVal = objComm.ExecuteScalar();
                objComm.Connection.Close();

                DataRow dr = m_dtHistory.NewRow();          
                dr["AccountCommand"] = m_command;
                dr["AccountName"] = m_accountName;
                dr["CurrentPassword"] = m_currentPassword;
                dr["NewPassword"] = m_newPassword;
                dr["CommandCompleted"] = false;
                dr["UpdatedBy"] = m_updatedBy;
                dr["UpdatedDateTime"] = System.DateTime.Now;
                m_dtHistory.Rows.Add(dr);
            }
            catch(Exception ex)
            { MessageBox.Show(ex.Message); }
            finally
            { this.Cursor = Cursors.Default; }
        }

        private void CustomizeGridAppearance()
        {
            DataGridViewCellStyle cs_Header = new DataGridViewCellStyle();
            cs_Header.Alignment = DataGridViewContentAlignment.MiddleCenter;
            cs_Header.BackColor = Color.Maroon;            
            cs_Header.ForeColor = Color.White;

            DataGridViewCellStyle cs_AltRows = new DataGridViewCellStyle();
            cs_AltRows.BackColor = Color.Silver;

            DataGridViewCellStyle cs_Cells = new DataGridViewCellStyle();
            dgvWShistory.RowHeadersWidth = 4;
            dgvWShistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvWShistory.AlternatingRowsDefaultCellStyle = cs_AltRows;
            dgvWShistory.Font = new Font("Tahoma", 8.0f, FontStyle.Regular);
            dgvWShistory.AllowUserToAddRows = false;
            dgvWShistory.AllowUserToDeleteRows = false;                
            dgvWShistory.ColumnHeadersDefaultCellStyle = cs_Header;
        }

        private void LoadHistComms()
        {
            StringBuilder sb = new StringBuilder("EXEC Pomps.dbo.up_WS_Admin_GetWorkstationCommHistory ");
            sb.Append("@WorkstationName = '" + m_workstationName + "' ");

            SqlDataAdapter objDA = new SqlDataAdapter(sb.ToString(), m_connStr);
            m_dtHistory = new DataTable();
            objDA.Fill(m_dtHistory);
            m_dtHistory.DefaultView.Sort = "CommandCompleted ASC,UpdatedDateTime DESC";
            dgvWShistory.DataSource = m_dtHistory;
            dgvWShistory.Show();
            CustomizeGridAppearance();

        }
        
        public string LAM_SelWorkstation { set => m_workstationName = value; }

        public string LAM_ConStr { set => m_connStr = value; }

        private void button1_Click(object sender, EventArgs e)
        {
            string usr = txtUser.Text;
            StringBuilder sb = new StringBuilder();
            if (usr.Length > 0)
            {
                cls_ADS objADS = new cls_ADS();
                List<string> userRoles = objADS.GetUserRoles(usr);
                
                foreach (String sX in userRoles)
                {
                    sb.Append(sX + "\r\n");
                }
            }
            else
            {
                sb.Append("Enter a User Name");
                txtUser.Focus();
            }
            MessageBox.Show(sb.ToString());

        }
    }
}
