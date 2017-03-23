using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SallikasuServices.Controllers
{
    public class TransactionMetricsController : Controller
    {
        // GET: TransactionMatrix
        public ActionResult Index(int userid,int month,int year, int merchantid=-1)
        {
            return View();
        }
    }
}