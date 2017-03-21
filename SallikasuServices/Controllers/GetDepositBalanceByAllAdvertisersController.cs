using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace SallikasuServices.Controllers
{
    public class GetDepositBalanceByAllAdvertisersController : Controller
    {
        // GET: GetDepositByAllAdvertisers
        public ActionResult Index(int userid, DateTime start_date, DateTime end_date)
        {
            Models.GetDepositBalanceByAllAdvertisersModel tModel = new Models.GetDepositBalanceByAllAdvertisersModel();
            List<Models.GetDepositBalanceByAllAdvertiserData> tList;
            String tJson = "{\"status\":\"failed\"}";
            if ( tModel.Process(userid,start_date,end_date, out tList))
            {
                tJson = "{\"status\":\"ok\"" + ",\"" +
                               JsonConvert.SerializeObject(tList)
                               + "}";
            }
            return View();
        }
    }
}