using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Common
{
    [Serializable]
    public class UserLogin
    {
        public UserLogin(long userID, string userName, bool rememerberMe)
        {
            UserID = userID;
            UserName = userName;
            RememerberMe = rememerberMe;
        }


        public long UserID { get; set; }
        public string UserName { get; set; }
        public bool RememerberMe { get; set; }
    }
}