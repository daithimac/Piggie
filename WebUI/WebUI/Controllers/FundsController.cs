using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Services.Payments.Handlers.Queries;
using WebUI.Services.Payments.Handlers.Commands;
using WebUI.Services.Payments.Handlers.Commands;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class FundsController : Controller
    {
        public ActionResult CreateFund(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            var items = new List<String> {"Weekly", "Monthly" };
            ViewBag.Frequency = new SelectList(items);

            return View();
        }

        [HttpPost]
        public ActionResult CreateFund(CreateFundModel model, string returnUrl)
        {
            var accountGuid = (Guid)Session["AccountGuid"];
            var fundGuid = Guid.NewGuid();

            CreateFundHandler.Handle(accountGuid, 
                fundGuid, 
                model.GoalAmount, 
                model.Name, 
                model.ReleaseOn,
                model.Frequency,
                model.RecipiantAccount);

            return RedirectToAction("Summary", "Funds");
        }

        public ActionResult Summary(SummaryModel model, string returnUrl)
        {
            var accountGuid = (Guid)Session["AccountGuid"];
            var funds = GetFundsHandler.Handle(accountGuid);

            model.Funds = new List<SummaryFund>();
            foreach(var f in funds)
            {
                model.Funds.Add(new SummaryFund
                {
                    Name = f.Name,
                    Balance = f.Balance,
                    Frequency = FrequencyAsString(f.Frequency),
                    Amount = f.Amount,
                    CreatedOn = f.CreatedOn,
                    GoalAmount = f.GoalAmount,
                    ReleaseOn = f.ReleaseOn
                });
            }

            ViewBag.Message = "Funds viewbag title";          
            
            return View(model);
        }

        [AllowAnonymous]
        public ActionResult CreatePaymentCard(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login

        [HttpPost]
        [AllowAnonymous]
        public ActionResult CreatePaymentCard(CreatePaymentCardModel model)//, string returnUrl)
        {
            var accountGuid = (Guid)Session["AccountGuid"];
            var title = model.Title;
            var name = model.Name;
            var address1 = model.Address1;
            var address2 = model.Address2;
            var cardNumber = model.CardNumber;
            var cardType = model.CardType;
            var ccv = model.CCV;

            CreatePaymentCardHandler.Handle(accountGuid, title, name, address1, address2, cardNumber, cardType, ccv);

            return RedirectToAction("Summary", "Funds");
        }


        private String FrequencyAsString(int frequency)
        {
            switch (frequency)
            {
                case 0:
                    {
                        return "Weekly";
                    } break;
                case 1:
                    {
                        return "Monthly";
                    } break;
                default:
                    {
                        throw new Exception("Unknown type");
                    }
            }
        }
    }
}
