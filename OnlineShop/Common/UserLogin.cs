using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Common
{
    [Serializable]
    public class UserLogin
    {
        public UserLogin(int userID, string userName, bool rememerberMe)
        {
            UserID = userID;
            UserName = userName;
            RememerberMe = rememerberMe;
        }


        public int UserID { get; set; }
        public string UserName { get; set; }
        public bool RememerberMe { get; set; }
    }
}