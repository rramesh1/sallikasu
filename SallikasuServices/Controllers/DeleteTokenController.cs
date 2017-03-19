using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SallikasuServices.Controllers
{
    public class DeleteTokenController : Controller
    {
        // GET: DeleteToken
        public ActionResult Index(int Token)
        {
            Models.DeleteTokenModel tModel = new Models.DeleteTokenModel();
            tModel.Process(Token);
            return View();
        }
    }
}