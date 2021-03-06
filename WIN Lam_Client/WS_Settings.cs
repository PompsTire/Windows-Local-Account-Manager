﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace WIN_Lam_Client
{
    class WS_Settings
    {
        private bool m_isError;
        private string m_errorMessage;

        public WS_Settings()
        {
            ClearError();
        }

        public bool VerifyCanConnect(int connTimeout)
        {
            bool canConnect = false;
            SqlConnection objConn = null; 
            try
            {
                SqlConnectionStringBuilder objSQB = new SqlConnectionStringBuilder();
                objSQB.ConnectionString = ConStr;
                objSQB.ConnectTimeout = connTimeout;
                objConn = new SqlConnection(ConStr);
                objConn.Open();

                if (objConn.State == ConnectionState.Open)
                    canConnect = true;
                else
                    throw new ApplicationException("Failed to Open SQL Connection");

                objConn.Close();
            }
            catch(Exception ex)
            {
                SetError(ex.Message);
                canConnect = false;
            }
            finally
            {  }
            return canConnect;
        }

        public Dictionary<string, string> GetAppSettings()
        {
            Dictionary<string, string> dictSettings = new Dictionary<string, string>();
            String sSql = "EXEC Pomps.dbo.up_WS_Admin_GetAppSettings ";
            SqlDataAdapter objDA = new SqlDataAdapter(sSql, ConStr);
            DataTable dt = new DataTable();

            try
            {
                objDA.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    foreach (DataColumn dc in dt.Columns)
                    {
                        dictSettings.Add(dc.ColumnName, dr[dc.ColumnName].ToString());
                    }
                }
                else
                    throw new ApplicationException("Failed To Get App Settings");


            }
            catch (Exception ex)
            { SetError(ex.Message); }

            return dictSettings;
        }

        public DataTable GetQueuedComms(string localPC)
        {
            String sSql = "EXEC Pomps.dbo.up_WS_Admin_GetQueuedComms ";
            sSql += "@WorkstationName = '" + localPC + "' ";
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter objDA = new SqlDataAdapter(sSql, ConStr);
                objDA.Fill(dt);
            }
            catch(Exception ex)
            { SetError(ex.Message); }
            return dt;
        }

        public bool UpdateExecutedComm(string pkid, string errorMessages)
        {
            StringBuilder sb = new StringBuilder("EXEC Pomps.dbo.up_WS_Admin_ExecutedComm ");
            sb.Append("@PKID = " + pkid.ToString() + ", ");
            sb.Append("@ErrorMessages = '" + errorMessages + "' ");

            try
            {
                SqlCommand objComm = new SqlCommand(sb.ToString(), new SqlConnection(ConStr));
                objComm.Connection.Open();
                objComm.ExecuteNonQuery();
                objComm.Connection.Close();
            }
            catch(Exception ex)
            { SetError(ex.Message); }

            return !m_isError;
        }

        public void UpdateWorkstationAccountRecord(string localPC, string localAcctName, string localPwd, int nextUpdateDays, string errorMsgs)
        {
            StringBuilder sb = new StringBuilder("EXEC Pomps.dbo.up_WS_Admin_UpdateActivity ");
            sb.Append("@WorkstationName = '" + localPC + "', ");
            sb.Append("@AdminAcctName = '" + localAcctName + "', ");
            sb.Append("@AdminPwd = '" + localPwd + "', ");
            sb.Append("@NextUpdateDays = " + nextUpdateDays.ToString() + ", ");
            sb.Append("@ErrorMessages = '" + errorMsgs + "' ");

            try
            {
                SqlCommand objComm = new SqlCommand(sb.ToString(), new SqlConnection(ConStr));
                objComm.Connection.Open();
                objComm.ExecuteNonQuery();
                objComm.Connection.Close();
            }
            catch (Exception ex)
            { SetError(ex.Message); }
        }

        public Dictionary<string, string> GetUpdatePwdStatus(string localPC, string userID)
        {
            Dictionary<string, string> curRecs = new Dictionary<string, string>();
            StringBuilder sb = new StringBuilder("EXEC Pomps.dbo.up_WS_Admin_CheckUpdateStatus ");
            sb.Append("@WorkstationName = '" + localPC + "', ");
            sb.Append("@userID = '" + userID + "', ");
            sb.Append("@IsClientLogin = 1");
            SqlDataAdapter objDA = new SqlDataAdapter(sb.ToString(), ConStr);
            DataTable dt = new DataTable();

            try
            {
                objDA.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    curRecs.Add("DoUpdateFlag", dr["DoUpdateFlag"].ToString());
                    curRecs.Add("AdminPwd", dr["AdminPwd"].ToString());
                    curRecs.Add("LastUpdatedDateTime", dr["LastUpdatedDateTime"].ToString());
                    curRecs.Add("NextUpdateDateTime", dr["NextUpdateDateTime"].ToString());
                }
                else
                    curRecs.Add("DoUpdateFlag", "1");
            }
            catch (Exception ex)
            { SetError(ex.Message); }

            return curRecs;
        }

        private static string ConStr
        {
            get
            {
                SqlConnectionStringBuilder sConStr = new SqlConnectionStringBuilder();
                sConStr.DataSource = "GBSQL01v2";
                sConStr.UserID = "ExternalSysUser";
                sConStr.Password = "aLg36R12!";
                sConStr.InitialCatalog = "Pomps";
                sConStr.ConnectTimeout = 20;
                return sConStr.ConnectionString;
            }
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
            m_isError = false;
            m_errorMessage = "";
        }

        public bool IsError => m_isError;
        public string ErrorMessage => m_errorMessage;
    }
}
