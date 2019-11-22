using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WIN_Lam_Admin
{
    public partial class frmAdmin : Form
    {
        private DataTable m_workStationActivities = new DataTable();
        private DataTable m_settings = new DataTable();
        private bool m_isError;
        private string m_errorMessage;

        public frmAdmin()
        {
            InitializeComponent();
        }

        private void frmAdmin_Load(object sender, EventArgs e)
        {
            LoadWorkstations();
            ClearError();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadWorkstations();
        }

        private void LoadWorkstations()
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                string sSql1 = "EXEC Pomps.dbo.up_WS_Admin_GetAppSettings";
                string sSql2 = SQL_Workstations;

                SqlDataAdapter objDA = new SqlDataAdapter(sSql1, ConStr);
                m_workStationActivities = new DataTable();
                m_settings = new DataTable();

                objDA.Fill(m_settings);
                ShowSettings();

                objDA.SelectCommand.CommandText = sSql2;
                objDA.Fill(m_workStationActivities);
                DecryptPasswords();

                dgWorkstations.DataSource = m_workStationActivities;
                dgWorkstations.Dock = DockStyle.Fill;
            }
            catch (Exception ex)
            { }
            finally
            { this.Cursor = Cursors.Default; }
        }

        private void DecryptPasswords()
        {
            string k1 = txtKey1.Text;
            string k2 = txtKey2.Text;
            string unEnc = "";
            string Enc = "";
            cls_AES objAes = new cls_AES();

            foreach (DataRow dr in m_workStationActivities.Rows)
            {
                unEnc = objAes.SimpleDecryptWithPassword(dr["AdminPwd"].ToString(), k1, k2.Length);
                dr["Unencrypted"] = unEnc;
            }
        }

        private void ShowSettings()
        {
            if (m_settings.Rows.Count > 0)
            {
                DataRow dr = m_settings.Rows[0];
                txtPasswordDuration.Text = dr["PasswordDurationDays"].ToString();
                txtAccountID.Text = dr["localUserID"].ToString();
                txtKey1.Text = dr["Key1"].ToString();
                txtKey2.Text = dr["Key2"].ToString();
                txtRole.Text = dr["localRole"].ToString();

                if (dr["generateRandomPassword"].ToString() == "True")
                {
                    optYes.Checked = true;
                    txtLength.Text = dr["randomPasswordLength"].ToString();
                }
                else
                {
                    optNo.Checked = true;
                    txtPassword.Text = dr["localPassword"].ToString();
                }
            }
        }

        private string SQL_Workstations
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("Select AL.PKID, AL.WorkstationName, AL.AdminAcctName, AL.AdminPwd, '' as Unencrypted, AL.LastUpdatedDateTime, AL.NextUpdateDateTime ");
                sb.Append("From [dbo].[tb_WS_Admin_ActionLog] AL INNER JOIN ");
                sb.Append("(Select WorkstationName, AdminAcctName, MAX(NextUpdateDateTime) as NextUpdateDateTime ");
                sb.Append("From [dbo].[tb_WS_Admin_ActionLog] ");
                sb.Append("Where NOT NextUpdateDateTime IS NULL ");
                sb.Append("Group By WorkstationName, AdminAcctName ");
                sb.Append(") A2 ON AL.WorkstationName = A2.WorkstationName AND AL.AdminAcctName = A2.AdminAcctName AND AL.NextUpdateDateTime = A2.NextUpdateDateTime ");
                sb.Append("Order By AL.WorkstationName ");
                return sb.ToString();
            }
        }

        private string ConStr
        {
            get
            {
                SqlConnectionStringBuilder sConStr = new SqlConnectionStringBuilder();
                sConStr.DataSource = "GBSQL01v2";
                sConStr.UserID = "ExternalSysUser";
                sConStr.Password = "aLg36R12!";
                sConStr.InitialCatalog = "Pomps";
                return sConStr.ConnectionString;
            }
        }

        private void optYes_CheckedChanged(object sender, EventArgs e)
        {
            ToggleAppearance(true);
        }

        private void rdoNo_CheckedChanged(object sender, EventArgs e)
        {
            ToggleAppearance(false);
        }

        private void ToggleAppearance(bool Yes)
        {
            lblPassword.Enabled = !Yes;
            txtPassword.Enabled = !Yes;
            lblLength.Enabled = Yes;
            txtLength.Enabled = Yes;
        }

        private void SetError(string msg)
        {
            m_isError = true;

            if (m_errorMessage.Length > 0)
                m_errorMessage += ";";

            m_errorMessage += msg;
        }

        private void ClearError()
        {
            m_errorMessage = "";
            m_isError = false;
        }
    }
}
