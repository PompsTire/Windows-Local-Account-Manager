using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIN_Lam_Client
{
    class Program
    {
        private static string userAccountName;
        private static string userAccountPassword;
        private static string localPC;
        private static string m_ErrorMessages;

        static void Main(string[] args)
        {
            WS_Settings objWS = new WS_Settings();
            // Check to see if we can connect to the SQL server. This will verify that we are on the network and
            //  can log any changes we make to the local user accounts. Exit if connect = false
            Console.WriteLine("Verifying Connection to SQL");            
            if (objWS.VerifyCanConnect(20) == false)
                Environment.Exit(-1);

            LocalUserAdmin objLUA = new LocalUserAdmin();
            AESHMAC_CRYPTO objAES = new AESHMAC_CRYPTO();
            localPC = System.Environment.MachineName;
            
            // Get the settins: keys, account name etc
            Console.WriteLine("Getting App Settings");
            Dictionary<string, string> appSettings = objWS.GetAppSettings();
              
            // Check last time password was updated, Key is pc name and the user ID
            Console.WriteLine("Checking Action Log");
            Dictionary<string, string> curRecs = objWS.GetUpdatePwdStatus(localPC, appSettings["localUserID"].ToString());

            int doUpdate = int.Parse(curRecs["DoUpdateFlag"]);

            // doUpdate will be 0 if there is already password for it that is within datetime threshold
            if (doUpdate == 1)
            {
                userAccountName = appSettings["localUserID"];
                string key1 = appSettings["Key1"];
                string key2 = appSettings["Key2"];
                string userRole = appSettings["localRole"];

                // either use a password defined in db or randomly create one
                if (bool.Parse(appSettings["generateRandomPassword"]) == true)
                    userAccountPassword = RandomPasswordGenerator(int.Parse(appSettings["randomPasswordLength"]));
                else
                    userAccountPassword = appSettings["localPassword"];

                string newEncryptedPassword = objAES.SimpleEncryptWithPassword(userAccountPassword, key1, Encoding.ASCII.GetBytes(key2));

                // If account exists then change password, else create new account
                if (objLUA.VerifyLocalUserExists(userAccountName))
                {
                    Console.WriteLine("Updating User Account");
                    string oldEncryptedPassword = curRecs["AdminPwd"];
                    string oldDecryptedPassword = objAES.SimpleDecryptWithPassword(oldEncryptedPassword, key1, key2.Length);
                    objLUA.ChangeLocalPassword(userAccountName, oldDecryptedPassword, userAccountPassword);
                }
                else
                {
                    // use the UNENCRYPTED password
                    Console.WriteLine("Creating New User Account");
                    objLUA.CreateLocalAcct(userAccountName, userAccountPassword, appSettings["localRole"], "");
                }
                           
                if (objLUA.IsError)
                {
                    Console.WriteLine(objLUA.ErrorMessage);
                }
                else
                {
                    objWS.UpdateWorkstationAccountRecord(localPC, userAccountName, newEncryptedPassword, int.Parse(appSettings["PasswordDurationDays"]), "");
                }
            }
            else
            {
                Console.WriteLine("Password is current");
            }

            // Check the client command queue and execute any pending aux commands
            //  
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Checking For Queued Commands...");
            WS_ClientCommands objCC = new WS_ClientCommands();
            if (objCC.IsPendingCommands())
            {
                Console.WriteLine("Executing " + objCC.CommCount.ToString() + " Queued Commands");
                objCC.ExecutePending();
                if (objCC.IsError)
                    Console.WriteLine("Errors Encountered: " + objCC.ErrorMessage);
                else
                    Console.WriteLine("Completed With No Errors");
            }

            //Console.WriteLine("Finished. Press Any Key...");
            //Console.ReadKey();
        }

        private static string RandomPasswordGenerator(int CharLength)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[CharLength];
            var random = new Random();

            for (int i = 0; i < CharLength; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            return new String(stringChars);
        }
    }
}
