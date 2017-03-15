using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SallikasuServices.Controllers
{
    public class GetProductsForAdvertiserController : Controller
    {
        // GET: GetProductsForAdvertiser
        public ActionResult Get(int AdvertiserId)
        {
            SallikasuServices.Models.GetProductsForAdvertiserModel tModel;
            tModel = new Models.GetProductsForAdvertiserModel();
            List<product> tProducts = tModel.Get(AdvertiserId);

            return Json(tProducts,JsonRequestBehavior.AllowGet);
        }

    }
}
