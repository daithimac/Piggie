using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebUI.Services.Payments.Data;

namespace WebUI.Services.Payments.Handlers.Queries
{
    public static class GetFundsHandler
    {
        public static Fund GetFunds()
        {
            using (var db = new PaymentsEntities())
            {
                var fund = db.Funds.First();

                return fund;
            }
        }
    }
}