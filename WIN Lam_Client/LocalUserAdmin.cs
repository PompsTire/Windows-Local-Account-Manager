using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;

namespace WIN_Lam_Client
{
    class LocalUserAdmin
    {
        private bool m_isError;
        private string m_errorMessage;

        public LocalUserAdmin()
        {
            ClearError();
        }

        public bool VerifyLocalUserExists(string userName)
        {
            bool userExists = false;
            using (PrincipalContext context = new PrincipalContext(ContextType.Machine))
            {
                UserPrincipal up = UserPrincipal.FindByIdentity(context, IdentityType.SamAccountName, userName);
                userExists = (up != null);
            }

            return userExists;
        }

        public bool DisableLocalUserAccount(string userName)
        {
            try
            {
                using (PrincipalContext context = new PrincipalContext(ContextType.Machine))
                {
                    UserPrincipal user = UserPrincipal.FindByIdentity(context, IdentityType.SamAccountName, userName);

                    if (user == null)
                        throw new ApplicationException("User " + userName + " Not Found");
                    else
                        user.Enabled = false;
                }
            }
            catch (Exception ex)
            { SetError(ex.Message); }

            return !IsError;
        }

        public bool EnableLocalUserAccount(string userName)
        {
            try
            {
                using (PrincipalContext context = new PrincipalContext(ContextType.Machine))
                {
                    UserPrincipal user = UserPrincipal.FindByIdentity(context, IdentityType.SamAccountName, userName);

                    if (user == null)
                        throw new ApplicationException("User " + userName + " Not Found");
                    else
                        user.Enabled = true;
                }
            }
            catch (Exception ex)
            { SetError(ex.Message); }

            return !IsError;
        }

        public bool DeleteLocalUserAccount(string userName)
        {
            try
            {
                using (PrincipalContext context = new PrincipalContext(ContextType.Machine))
                {
                    UserPrincipal user = UserPrincipal.FindByIdentity(context, IdentityType.SamAccountName, userName);

                    if (user == null)
                        throw new ApplicationException("User " + userName + " Not Found");
                    else
                        user.Delete();
                }
            }
            catch (Exception ex)
            { SetError(ex.Message); }

            return !IsError;
        }

        public bool ValidateLocalUserAccount(string userName, string password)
        {
            bool isValid = false;
            try
            {
                using (PrincipalContext context = new PrincipalContext(ContextType.Machine))
                {
                    isValid = context.ValidateCredentials(userName, password);
                }
            }
            catch (Exception ex)
            { SetError(ex.Message); }

            return isValid;
        }

        public bool ChangeLocalPassword(string userName, string oldPassword, string newPassword)
        {
            // Local security policy as of 1/29/2020 at pomps is that password cannot be changed more 
            //  than 1 time in a 24 hour period.
            try
            {
                using (PrincipalContext context = new PrincipalContext(ContextType.Machine))
                {
                    UserPrincipal user = UserPrincipal.FindByIdentity(context, IdentityType.SamAccountName, userName);
                    if (user == null)
                        throw new ApplicationException("user " + userName + " not found");
                    else
                        user.ChangePassword(oldPassword, newPassword);
                }
            }
            catch (Exception ex)
            { SetError(ex.Message); }

            return !IsError;
        }

        public bool CreateLocalAcct(string userName, string userPassword, string localGroup, string optionalDescription = "")
        {
            try
            {
                string localPC = Environment.MachineName;

                DirectoryEntry AD = new DirectoryEntry("WinNT://" + localPC + ",computer");
                DirectoryEntry newUser = AD.Children.Add(userName, "user");
                newUser.Invoke("SetPassword", new object[] { userPassword });
                newUser.Invoke("Put", new object[] { "Description", optionalDescription });
                newUser.CommitChanges();

                using (DirectoryEntry grp = AD.Children.Find(localGroup, "group"))
                {
                    if (grp != null)
                    {
                        grp.Invoke("Add", new object[] { newUser.Path.ToString() });
                        Console.WriteLine("Admin User Added With No Errors");
                    }
                    else
                    {
                        throw new ApplicationException("Error adding " + userName + " to " + localGroup + " group");
                    }
                }
            }
            catch (Exception ex)
            { SetError(ex.Message); }

            return !IsError;
        }

        private void SetError(string msg)
        {
            m_isError = true;

            if (m_errorMessage.Length > 0)
                m_errorMessage += ";";

            m_errorMessage += msg;
        }

        public void ClearError()
        {
            m_isError = false;
            m_errorMessage = "";
        }

        public bool IsError => m_isError;

        public string ErrorMessage => m_errorMessage;
    }
}
