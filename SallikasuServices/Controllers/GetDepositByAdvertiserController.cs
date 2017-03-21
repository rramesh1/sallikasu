using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace SallikasuServices.Controllers
{
    public class GetDepositByAdvertiserController : Controller
    {
        // GET: GetDepositByAdvertiser
        public ActionResult Index(int userid, DateTime start_date, DateTime end_date, int merchantid)
        {
            Models.GetDepositByAdvertiserModels tModel = new Models.GetDepositByAdvertiserModels();
            List<Models.GetDepositByAdvertiserData> tList;

            String tJson = "{\"status\":\"failed\"}";
            if ( tModel.Process(userid,start_date,end_date,merchantid,out tList))
            {

                tJson = "{\"status\":\"ok\"" + ",\"" +
                            JsonConvert.SerializeObject(tList)
                            + "}";
            }
            return Json(tJson,JsonRequestBehavior.AllowGet);
        }
    }
}