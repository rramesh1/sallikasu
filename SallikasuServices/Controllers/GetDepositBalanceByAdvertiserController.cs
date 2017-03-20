using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace SallikasuServices.Controllers
{
    public class GetDepositBalanceByAdvertiserController : Controller
    {
        // GET: GetDepositBalanceByAdvertiser
        public ActionResult Index(int userid, int merchantid)
        {
            Models.GetDepositBalanceByAdvertiserModel tModel = new Models.GetDepositBalanceByAdvertiserModel();
            List<Models.GetDepositBalanceByAdvertiserData> tList = null;
            String tJson = "{\"status\":\"failed\"}";
            if ( tModel.Process(userid, merchantid,out tList) )
            {
                tJson = "{\"status\":\"ok\"" + JsonConvert.SerializeObject(tList)  +"}";
            }
            return View();
        }
    }
}