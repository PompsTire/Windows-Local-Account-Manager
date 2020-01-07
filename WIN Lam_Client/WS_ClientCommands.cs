using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace WIN_Lam_Client
{
    class WS_ClientCommands
    {
        private DataTable m_Pending;
        private bool m_isError;
        private string m_errorMessage;
        private int m_errCount;
        private int m_commCount;

        public WS_ClientCommands()
        {
            ClearError();
            m_commCount = 0;
        }

        public bool IsPendingCommands()
        {
            WS_Settings objWS = new WS_Settings();
            m_Pending = new DataTable();

            bool m_isPending = false;
            m_Pending = objWS.GetQueuedComms(Environment.MachineName);
            m_commCount = m_Pending.Rows.Count;

            if (objWS.IsError)
                SetError(objWS.ErrorMessage);
            else
                if (m_commCount > 0)
                m_isPending = true;

            return m_isPending;
        }

        public bool ExecutePending()
        {
            String PKID = "";
            String Comm = "";
            String AccountName = "";
            String CurrPwd = "";
            String NewPwd = "";
            String Role = "Administrators";

            LocalUserAdmin objUA = new LocalUserAdmin();
            WS_Settings objST = new WS_Settings();

            foreach (DataRow dr in m_Pending.Rows)
            {
                Comm = "";
                AccountName = "";
                CurrPwd = "";
                NewPwd = "";
                PKID = "";

                PKID = dr["PKID"].ToString();
                Comm = dr["AccountCommand"].ToString();
                AccountName = dr["AccountName"].ToString();
                CurrPwd = dr["CurrentPassword"].ToString();
                NewPwd = dr["NewPassword"].ToString();
                
                switch (Comm.ToUpper())
                {
                    case "NEW":
                        {
                            objUA.CreateLocalAcct(AccountName, NewPwd, Role);
                            break;
                        }
                    case "DELETE":
                        {                            
                            objUA.DeleteLocalUserAccount(AccountName);
                            break;
                        }
                    case "ENABLE":
                        {
                            objUA.EnableLocalUserAccount(AccountName);
                            break;
                        }
                    case "DISABLE":
                        {
                            objUA.DisableLocalUserAccount(AccountName);
                            break;
                        }
                    case "CHANGEPASSWORD":
                        {
                            objUA.ChangeLocalPassword(AccountName, CurrPwd, NewPwd);
                            break;
                        }
                }
                objST.UpdateExecutedComm(PKID, objUA.ErrorMessage);
                if (objUA.IsError)
                    SetError(objUA.ErrorMessage);

                objUA.ClearError();
            }

            return !m_isError;
        }
        
        private void SetError(string msg)
        {
            m_isError = true;
            if (m_errorMessage.Length > 0)
                m_errorMessage += ";";

            m_errorMessage += msg;
            m_errCount++;
        }

        private void ClearError()
        {
            m_isError = false;
            m_errorMessage = "";
            m_errCount = 0;
        }

        public bool IsError => m_isError;
        public string ErrorMessage => m_errorMessage;
        public int ErrorCount => m_errCount;
        public int CommCount => m_commCount;
    }
}
