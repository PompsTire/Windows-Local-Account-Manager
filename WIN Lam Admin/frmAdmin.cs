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
        private DataSet m_workStationActivities = new DataSet();
        private string m_errorMessage;
        private bool m_isError;
        private bool m_canSeePasswords;
        private string m_key1;
        private string m_key2;
        private string m_conStr;    
        private ContextMenu m_ctxGridMnu;
        private DataRow m_selRow;
        private MenuItem mnuRunCommand;
        private MenuItem mnuShowPassword;
        private MenuItem mnuShowWorkstationHistory;
        private MenuItem mnuChangeUpdateDate;

        public frmAdmin()
        {
            InitializeComponent();
        }

        private void frmAdmin_Load(object sender, EventArgs e)
        {
            GetUserAuthLevel();
            LoadSettings();
            CustomizeGrid();

            LoadWorkstations();
            ClearError();
        }

        private void LoadSettings()
        {
            frmSettings objFrm = new frmSettings();
            objFrm.LoadSettings();
            m_key1 = objFrm.Key1;
            m_key2 = objFrm.Key2;
            m_conStr = objFrm.ConStr;
            CreateCTXMenu();            
        }

        private void GetUserAuthLevel()
        {
            string user = Environment.UserName;

            slblWhoAreYou.Text = user;
            cls_ADS objAD = new cls_ADS();
            if(objAD.IsInGroup(user,"Tier 1 Admins") || user == "michael.joncas")
            {
                m_canSeePasswords = true;
            }
            else
            {
                m_canSeePasswords = false;
            }
        }

        private void CreateCTXMenu()
        {
            //dgWorkstations.MouseDown += new MouseEventHandler(dgWorkstations_MouseDown);
            dgvWorkstations.MouseDown += new MouseEventHandler(dgvWorkstations_MouseDown);

            m_ctxGridMnu = new ContextMenu();
            mnuRunCommand = new MenuItem("Update Local User Accounts...", mnu_RunCommand);
            mnuShowPassword = new MenuItem("Show Password", mnu_ShowPassword);
            mnuShowWorkstationHistory = new MenuItem("Show Workstation History", mnu_ShowHistory);
            mnuChangeUpdateDate = new MenuItem("Change Password Expiration Date...", mnu_ChangeUpdateDate);
            
            m_ctxGridMnu.MenuItems.Add(mnuShowPassword);
            m_ctxGridMnu.MenuItems.Add(mnuShowWorkstationHistory);
            m_ctxGridMnu.MenuItems.Add(mnuChangeUpdateDate);
            m_ctxGridMnu.MenuItems.Add(mnuRunCommand);            
        }

        private void mnu_ChangeUpdateDate(object sender, EventArgs e)
        {
            frmUpdateExpDate objFrm = new frmUpdateExpDate();            
            objFrm.ExpDate = DateTime.Parse(m_selRow["NextUpdateDateTime"].ToString());
            objFrm.ShowDialog();
            if(objFrm.IsCancelled == false)
            {
                this.Cursor = Cursors.WaitCursor;
                UpdateExpDate(objFrm.ExpDate);
                m_selRow["NextUpdateDateTime"] = objFrm.ExpDate;
                this.Cursor = Cursors.Default;
            }
        }

        private void mnu_ShowHistory(object sender, EventArgs e)
        {
            string selWorkstation = m_selRow["WorkstationName"].ToString();
            string sFilter = "WorkstationName='" + selWorkstation + "'";

            DataView dv = new DataView(m_workStationActivities.Tables[1], sFilter, "LastUpdatedDateTime DESC", DataViewRowState.CurrentRows);
            
            frmWorkstationHistoryPopUp objFrm = new frmWorkstationHistoryPopUp();
            objFrm.WSHP_workStations = dv.ToTable();
            objFrm.WSHP_Key1 = m_key1;
            objFrm.WSHP_Key2 = m_key2;
            objFrm.ShowDialog();

        }

        private void mnu_ShowPassword(object sender, EventArgs e)
        {
            string encPwd = m_selRow["AdminPwd"].ToString();
            cls_AES objAes = new cls_AES();
            string unEnc = "";
            unEnc = objAes.SimpleDecryptWithPassword(encPwd, m_key1, m_key2.Length);
            m_selRow["MaskedPwd"] = unEnc;
        }

        //private void DecryptPasswords_ALL()
        //{
        //    string k1 = m_key1;
        //    string k2 = m_key2;
        //    string unEnc = "";      
        //    cls_AES objAes = new cls_AES();

        //    foreach (DataRow dr in m_workStationActivities.Tables[0].Rows)
        //    {
        //        unEnc = objAes.SimpleDecryptWithPassword(dr["AdminPwd"].ToString(), k1, k2.Length);
        //        dr["DecryptedPwd"] = unEnc;
        //    }
        //}

        private void mnu_RunCommand(object sender, EventArgs e)
        {
            frmClientCommands objFrm = new frmClientCommands();
            objFrm.LAM_SelWorkstation = m_selRow["WorkstationName"].ToString();
            objFrm.LAM_ConStr = m_conStr;
            objFrm.ShowDialog();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadWorkstations();
            frmSettings objFrm = new frmSettings();
            objFrm.ShowDialog();
        }

        private void UnselectAllRows()
        { dgvWorkstations.ClearSelection(); }
        
        private void dgvWorkstations_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int selRow = dgvWorkstations.HitTest(e.X, e.Y).RowIndex;

                if (selRow > -1)
                {
                    UnselectAllRows();                   
                    dgvWorkstations.Rows[selRow].Selected = true;

                    if (selRow < dgvWorkstations.Rows.GetRowCount(DataGridViewElementStates.Visible))
                    {

                        string selPKI = dgvWorkstations.Rows[selRow].Cells[0].Value.ToString();
                        string sFilter = "PKID=" + selPKI;

                        DataRow[] drs;


                        if (m_canSeePasswords)
                        {
                            mnuShowPassword.Visible = true;
                            mnuRunCommand.Visible = true;
                        }
                        else
                        {
                            mnuShowPassword.Visible = false;
                            mnuRunCommand.Visible = false;
                        }

                        drs = m_workStationActivities.Tables[0].Select(sFilter);
                        if (drs.Length > 0)
                        {
                            if (m_canSeePasswords)
                                mnuRunCommand.Visible = true;
                            else
                                mnuRunCommand.Visible = false;
                            m_selRow = drs[0];
                        }
                        else
                        {          
                            mnuRunCommand.Visible = false;
                            drs = m_workStationActivities.Tables[1].Select(sFilter);
                            m_selRow = drs[0];
                        }
                        m_ctxGridMnu.Show(dgvWorkstations, new Point(e.X, e.Y));
                    }
                }
            }
        }

        private void UpdateExpDate(DateTime expDte)
        {
            StringBuilder sb = new StringBuilder("EXEC Pomps.dbo.up_WS_Admin_UpdateExpDate ");
            sb.Append("@NextUpdateDateTime = '" + expDte + "', ");
            sb.Append("@PKID = " + m_selRow["PKID"].ToString());

            try
            {
                SqlCommand objComm = new SqlCommand(sb.ToString(), new SqlConnection(m_conStr));
                objComm.Connection.Open();
                objComm.ExecuteNonQuery();
                objComm.Connection.Close();
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        private void LoadWorkstations()
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {                
                string sSql = SQL_Workstations;
                SqlDataAdapter objDA = new SqlDataAdapter(sSql, m_conStr);
                m_workStationActivities = new DataSet();

                objDA.SelectCommand.CommandText = sSql;
                objDA.Fill(m_workStationActivities);
                m_workStationActivities.Tables[0].TableName = "Workstations";
                m_workStationActivities.Tables[1].TableName = "History";
                                
                dgvWorkstations.DataSource = m_workStationActivities.Tables[0];
                dgvWorkstations.Dock = DockStyle.Fill;
            }
            catch (Exception ex)
            { }
            finally
            { this.Cursor = Cursors.Default; }
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
            dc[1].Visible = true;
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
            dc[4].HeaderText = "Last Login";
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

            dgvWorkstations.Columns.AddRange(dc);
        }

        private void CustomizeGrid_XX()
        {
            DataGridTableStyle ts1 = new DataGridTableStyle();
            DataGridTableStyle ts2 = new DataGridTableStyle();

            ts1.MappingName = "Workstations";
            ts1.AlternatingBackColor = Color.Silver;
            ts1.HeaderBackColor = Color.Maroon;
            ts1.HeaderForeColor = Color.White;
            ts1.HeaderFont = new Font("Tahoma", 8.5f, FontStyle.Regular);

            ts2.MappingName = "History";
            ts2.AlternatingBackColor = Color.LightSkyBlue;
            ts2.HeaderBackColor = Color.BlanchedAlmond;
            ts2.HeaderForeColor = Color.Black;
            ts2.HeaderFont = new Font("Tahoma", 8.5f, FontStyle.Regular);

            DataGridColumnStyle dgCol1 = new DataGridTextBoxColumn();
            dgCol1.MappingName = "PKID";
            dgCol1.HeaderText = "";
            dgCol1.Width = 1;
            ts1.GridColumnStyles.Add(dgCol1);

            DataGridColumnStyle dgCol2 = new DataGridTextBoxColumn();
            dgCol2.MappingName = "WorkstationName";
            dgCol2.HeaderText = "Workstation";
            dgCol2.Alignment = HorizontalAlignment.Center;
            dgCol2.Width = 100;
            ts1.GridColumnStyles.Add(dgCol2);

            DataGridColumnStyle dgCol3 = new DataGridTextBoxColumn();
            dgCol3.MappingName = "AdminAcctName";
            dgCol3.HeaderText = "Account ID";
            dgCol3.Alignment = HorizontalAlignment.Center;
            dgCol3.Width = 120;
            ts1.GridColumnStyles.Add(dgCol3);

            DataGridColumnStyle dgCol5 = new DataGridTextBoxColumn();
            dgCol5.MappingName = "MaskedPwd";
            dgCol5.HeaderText = "Password";
            dgCol5.Alignment = HorizontalAlignment.Center;
            dgCol5.Width = 130;
            ts1.GridColumnStyles.Add(dgCol5);

            DataGridColumnStyle dgCol6 = new DataGridTextBoxColumn();
            dgCol6.MappingName = "LastLoginDateTime";
            dgCol6.HeaderText = "Last Login";
            dgCol6.Alignment = HorizontalAlignment.Center;
            dgCol6.Width = 130;
            ts1.GridColumnStyles.Add(dgCol6);

            DataGridColumnStyle dgCol7 = new DataGridTextBoxColumn();
            dgCol7.MappingName = "LastUpdatedDateTime";
            dgCol7.HeaderText = "Account Last Updated";
            dgCol7.Alignment = HorizontalAlignment.Center;
            dgCol7.Width = 130;
            ts1.GridColumnStyles.Add(dgCol7);

            DataGridColumnStyle dgCol8 = new DataGridTextBoxColumn();
            dgCol8.MappingName = "NextUpdateDateTime";
            dgCol8.HeaderText = "Next Account Update";
            dgCol8.Alignment = HorizontalAlignment.Center;
            dgCol8.Width = 130;
            ts1.GridColumnStyles.Add(dgCol8);

            DataGridColumnStyle dgCol4 = new DataGridTextBoxColumn();
            dgCol4.MappingName = "AdminPwd";
            dgCol4.HeaderText = "Password (Encrypted)";            
            dgCol4.Width = 1;
            ts1.GridColumnStyles.Add(dgCol4);

            // Child rows ----------------------------------------------------------------------
            DataGridColumnStyle dgCol_1 = new DataGridTextBoxColumn();
            dgCol_1.MappingName = "PKID";
            dgCol_1.HeaderText = "";
            dgCol_1.Width = 1;
            ts2.GridColumnStyles.Add(dgCol_1);

            DataGridColumnStyle dgCol_2 = new DataGridTextBoxColumn();
            dgCol_2.MappingName = "WorkstationName";
            dgCol_2.HeaderText = "Workstation";
            dgCol_2.Alignment = HorizontalAlignment.Center;
            dgCol_2.Width = 100;
            ts2.GridColumnStyles.Add(dgCol_2);

            DataGridColumnStyle dgCol_3 = new DataGridTextBoxColumn();
            dgCol_3.MappingName = "AdminAcctName";
            dgCol_3.HeaderText = "Account ID";
            dgCol_3.Alignment = HorizontalAlignment.Center;
            dgCol_3.Width = 120;
            ts2.GridColumnStyles.Add(dgCol_3);

            DataGridColumnStyle dgCol_5 = new DataGridTextBoxColumn();
            dgCol_5.MappingName = "MaskedPwd";
            dgCol_5.HeaderText = "Password";
            dgCol_5.Alignment = HorizontalAlignment.Center;
            dgCol_5.Width = 130;
            ts2.GridColumnStyles.Add(dgCol_5);

            DataGridColumnStyle dgCol_6 = new DataGridTextBoxColumn();
            dgCol_6.MappingName = "LastLoginDateTime";
            dgCol_6.HeaderText = "Last Login";
            dgCol_6.Alignment = HorizontalAlignment.Center;
            dgCol_6.Width = 130;
            ts2.GridColumnStyles.Add(dgCol_6);

            DataGridColumnStyle dgCol_7 = new DataGridTextBoxColumn();
            dgCol_7.MappingName = "LastUpdatedDateTime";
            dgCol_7.HeaderText = "Account Last Updated";
            dgCol_7.Alignment = HorizontalAlignment.Center;
            dgCol_7.Width = 130;
            ts2.GridColumnStyles.Add(dgCol_7);

            DataGridColumnStyle dgCol_8 = new DataGridTextBoxColumn();
            dgCol_8.MappingName = "NextUpdateDateTime";
            dgCol_8.HeaderText = "Next Account Update";
            dgCol_8.Alignment = HorizontalAlignment.Center;
            dgCol_8.Width = 130;
            ts2.GridColumnStyles.Add(dgCol_8);

            DataGridColumnStyle dgCol_4 = new DataGridTextBoxColumn();
            dgCol_4.MappingName = "AdminPwd";
            dgCol_4.HeaderText = "Password (Encrypted)";
            dgCol_4.Width = 1;
            ts2.GridColumnStyles.Add(dgCol_4);

            dgWorkstationsXX.TableStyles.Add(ts1);
            dgWorkstationsXX.TableStyles.Add(ts2);   
        }

        private string SQL_Workstations => "EXEC Pomps.dbo.up_WS_Admin_GetActivityHistory ";

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
