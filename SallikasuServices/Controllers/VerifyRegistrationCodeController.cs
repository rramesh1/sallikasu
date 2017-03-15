using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SallikasuServices.Models;

namespace SallikasuServices.Controllers
{
    public class VerifyRegistrationCodeController : Controller
    {
        // GET: VerifyRegistrationCode
        public ActionResult Index(int Regcode)
        {
            RegistrationCodeModel tModel = new RegistrationCodeModel();
            if ( tModel.Verify(Regcode))
            {
                return Json("{\"status\":\"ok\"}",JsonRequestBehavior.AllowGet);
            }

            return Json("{\"status\":\"failed\"}", JsonRequestBehavior.AllowGet);
        }

      
    }
}
