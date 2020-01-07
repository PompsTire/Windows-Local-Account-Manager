using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;

namespace WIN_Lam_Admin
{
    class cls_ADS
    {
        string m_userID;

        public bool IsInGroup(string user_id, string authorization_group)
        {
            bool m_isInGroup = false;

            foreach(string grp in GetUserRoles(user_id))
            {
                if(authorization_group == grp)
                {
                    m_isInGroup = true;
                    break;
                }
            }

            return m_isInGroup;
        }

        public List<string> GetUserRoles(string user_id)
        {
            List<string> rslts = new List<string>();
            PrincipalContext pDomain = new PrincipalContext(ContextType.Domain);
            UserPrincipal user = UserPrincipal.FindByIdentity(pDomain, user_id);

            if(user != null)
            {
                PrincipalSearchResult<Principal> groups = user.GetAuthorizationGroups();

                foreach(Principal p in groups)
                {
                    if (p is GroupPrincipal)
                        rslts.Add(p.SamAccountName);
                }

            }
            return rslts;
        }


        public string UserID { get => m_userID; set => m_userID = value; }

    }
}
