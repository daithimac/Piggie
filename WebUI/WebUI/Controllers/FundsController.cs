using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Services.Payments.Handlers.Queries;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class FundsController : Controller
    {
        //
        // GET: /Funds/

        public ActionResult Summary(SummaryModel model, string returnUrl)
        {
            var accountGuid = (Guid)Session["AccountGuid"];
            var funds = GetFundsHandler.GetFunds(accountGuid);

            model.Funds = new List<Fund>();
            foreach(var f in funds)
            {
                model.Funds.Add(new Fund
                {
                    Name = f.Name,
                    Amount = f.Amount,
                    CreatedOn = f.CreatedOn,
                    GoalAmount = f.GoalAmount,
                    ReleaseOn = f.ReleaseOn
                });
            }

            ViewBag.Message = "Funds viewbag title";          

            return View(model);
        }



    }
}
