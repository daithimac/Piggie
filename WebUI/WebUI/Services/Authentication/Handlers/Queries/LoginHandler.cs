using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebUI.Services.Authentication.Data;
using WebUI.Services.Authentication.Data.Mocks;

namespace WebUI.Services.Authentication.Handlers.Queries
{
    public static class LoginHandler
    {//TODO: commands shouldn't return results
        public static Guid? Handle(String email, String password)
        {
            //using (var db = new AuthenticationEntities())
            //{
            //    try
            //    {
            //        var accountEntity = db.Accounts.Single(a => a.Login == email);
            //        if (accountEntity.Password == password)
            //            return accountEntity.AccountGuid;
            //        else return null;
            //    }

            //    catch
            //    {
            //        return null;
            //    }
            //}

            var results = AuthenticationEntitiesMock.Accounts.Where(a => a.Login == email && a.Password == password);

            if (results.Count() <= 0 || results.Count() > 1)
            {
                return null;
            }

            return results.First().AccountGuid;

            //try
            //{
            //    var accountEntity = AuthenticationEntitiesMock.Accounts.Single(a => a.Login == email);
            //    if (accountEntity.Password == password)
            //        return accountEntity.AccountGuid;
            //    else return null;
            //}

            //catch
            //{
            //    return null;
            //}
        }
    }
}