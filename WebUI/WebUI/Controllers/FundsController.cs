using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class FundsController : Controller
    {
        //
        // GET: /Funds/

        public ActionResult Summary()
        {
            ViewBag.Message = "Funds viewbag title";          

            return View();
        }

    }
}
