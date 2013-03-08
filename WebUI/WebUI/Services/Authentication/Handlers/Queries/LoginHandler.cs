using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebUI.Services.Authentication.Data;

namespace WebUI.Services.Authentication.Handlers.Queries
{
    public static class LoginHandler
    {//TODO: commands shouldn't return results
        public static Guid? Login(String email, String password)
        {
            using (var db = new AuthenticationEntities())
            {
                try
                {
                    var accountEntity = db.Accounts.Single(a => a.Login == email);
                    if (accountEntity.Password == password)
                        return accountEntity.AccountGuid;
                    else return null;
                }

                catch
                {
                    return null;
                }                
            }
        }
    }
}