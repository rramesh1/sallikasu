using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace SallikasuServices.Controllers
{
    public class GetDepositByUserController : Controller
    {
        // GET: GetDepositByUser
        public ActionResult Index(int userid)
        {
            Models.GetDepositByUserModel tModel = new Models.GetDepositByUserModel();
            List<Models.GetDepositByUserData> tList = null;
            String tJson = "{\"status\":\"failed\"}";
            if ( tModel.Process(userid, out tList) )
            {
                tJson = "{\"status\":\"failed\"" +
                            JsonConvert.SerializeObject(tList) +
                        "}";
            }
            return Json(tJson,JsonRequestBehavior.AllowGet);
        }
    }
}