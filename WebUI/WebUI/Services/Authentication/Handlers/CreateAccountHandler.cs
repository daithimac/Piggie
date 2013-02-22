using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebUI.Services.Authentication.Data;

namespace WebUI.Services.Authentication.Handlers
{
    public static class CreateAccountHandler
    {
        public static void CreateAccount(Guid accountGuid, String login, String password, String forename, String surname)
        {
            using (var db = new AuthenticationEntities())
            {
                var account = new Account();
                account.AccountGuid = accountGuid;
                account.Login = login;
                account.Password = password;
                account.Forename = forename;
                account.Surname = surname;

                db.Accounts.Add(account);
                db.SaveChanges();
            }
        }
    }
}