using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebUI.Services.Payments.Data;
using WebUI.Services.Payments.Data.Mocks;

namespace WebUI.Services.Payments.Handlers.Queries
{
    public static class GetFundsHandler
    {
        public static IQueryable<Fund> GetFunds(Guid accountGuid)
        {
            //using (var db = new PaymentsEntities())
            //{
            //    var fund = db.Funds.Select(a => a.AccountGuid == accountGuid);

            //    return fund;
            //}

            var funds = PaymentsEntitiesMock.Funds.AsQueryable();
                //.Where(a => a.AccountGuid == accountGuid).AsQueryable();
            return funds;
        }
    }
}