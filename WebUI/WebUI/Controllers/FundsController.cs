using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Services.Payments.Handlers.Queries;

namespace WebUI.Controllers
{
    public class FundsController : Controller
    {
        //
        // GET: /Funds/

        public ActionResult Summary()
        {
            var accountGuid = (Guid)Session["AccountGuid"];

            //var fund = GetFundsHandler.GetFunds(accountGuid).First();
            //ViewData["Name"] = fund.Name;
            //ViewData["Amount"] = fund.Amount;
            //ViewData["GoalAmount"] = fund.GoalAmount;
            //ViewData["CreatedOn"] = fund.CreatedOn;
            //ViewData["ReleaseOn"] = fund.ReleaseOn;

            ViewBag.Message = "Funds viewbag title";          

            return View();
        }

    }
}
