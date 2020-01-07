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
    public partial class frmSettings : Form
    {
        private DataTable m_settings = new DataTable();
        string sSql1 = "EXEC Pomps.dbo.up_WS_Admin_GetAppSettings";
        string m_conStr = "";
        string m_key1 = "";
        string m_key2 = "";
        string m_localUserID = "";
        string m_localRole = "";
        private int m_passDurationDays = 30;
        private bool m_generateRandomPwd = true;
        private int m_randomPwdLength = 10;
        private string m_localUserPwd = "";

        public frmSettings()
        {
            InitializeComponent();
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {
            LoadSettings();
            ShowSettings();
        }

        private void AddEvents()
        {
            optYes.CheckedChanged += new EventHandler(optYes_CheckedChanged);
            optNo.CheckedChanged += new EventHandler(rdoNo_CheckedChanged);
        }

        public void LoadSettings()
        {
            m_settings = new DataTable();
            SqlDataAdapter objDA = new SqlDataAdapter(sSql1, ConStr);
            objDA.Fill(m_settings);
            DataRow dr = m_settings.Rows[0];
            m_randomPwdLength = int.Parse(dr["randomPasswordLength"].ToString());
            m_passDurationDays = int.Parse(dr["PasswordDurationDays"].ToString());
            m_localUserID = dr["LocalUserID"].ToString();
            m_key1 = dr["Key1"].ToString();
            m_key2 = dr["Key2"].ToString();
            m_localRole = dr["localRole"].ToString();
            m_generateRandomPwd = bool.Parse(dr["generateRandomPassword"].ToString());            
        }

        private void ShowSettings()
        {
            txtPasswordDuration.Text = m_passDurationDays.ToString();
            txtAccountID.Text = m_localUserID;
            txtKey1.Text = m_key1;
            txtKey2.Text = m_key2;
            txtRole.Text = m_localRole;

            if (m_generateRandomPwd)
            {
                optYes.Checked = true;
                txtLength.Text = m_randomPwdLength.ToString();
            }
            else
            {
                optNo.Checked = true;
                txtPassword.Text = m_localUserPwd;
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

        public string ConStr
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

        public string Key1 { set => m_key1 = value; get => m_key1; }
        public string Key2 { set => m_key2 = value; get => m_key2; }
        public string LocalUserID { set => m_localUserID = value; get => m_localUserID; }
        public string LocalRole { set => m_localRole = value; get => m_localRole; }
        public int PasswordDurationDays { set => m_passDurationDays = value; get => m_passDurationDays; }
        public bool GenerateRandomPassword { set => m_generateRandomPwd = value; get => m_generateRandomPwd; }
        public int RandomPasswordLength { set => m_randomPwdLength = value; get => m_randomPwdLength; }
        public string LocalUserPassword { set => m_localUserPwd = value; get => m_localUserPwd; }

    }
}
