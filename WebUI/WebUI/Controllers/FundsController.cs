using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Services.Payments.Handlers.Queries;
using WebUI.Services.Payments.Handlers.Commands;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class FundsController : Controller
    {
        public ActionResult Create(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        public ActionResult Create(CreateModel model, string returnUrl)
        {
            var accountGuid = (Guid)Session["AccountGuid"];
            var fundGuid = Guid.NewGuid();

            CreateFundHandler.CreateFund(accountGuid, 
                fundGuid, 
                model.GoalAmount, 
                model.Name, 
                model.ReleaseOn);
            
            return RedirectToAction("Summary", "Funds");
        }

        public ActionResult Summary(SummaryModel model, string returnUrl)
        {
            var accountGuid = (Guid)Session["AccountGuid"];
            var funds = GetFundsHandler.GetFunds(accountGuid);

            model.Funds = new List<SummaryFund>();
            foreach(var f in funds)
            {
                model.Funds.Add(new SummaryFund
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
