using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebUI.Services.Authentication.Data;

namespace WebUI.Services.Authentication.Handlers.Queries
{
    public static class LoginHandler
    {
        public static Boolean Login(String email, String password)
        {
            using (var db = new AuthenticationEntities())
            {
                try
                {
                    var accountEntity = db.Accounts.Single(a => a.Login == email);
                    return (accountEntity.Password == password);
                }

                catch
                {
                    return false;
                }                
            }
        }
    }
}