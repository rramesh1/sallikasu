using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SallikasuServices.Controllers
{
    public class AdvertiserController : Controller
    {
        // GET: Advertiser
        public ActionResult Get()
        {
            Models.AdvertiserModel tModel = new Models.AdvertiserModel();
            List<merchant_advertisers> tList = tModel.Get();

            return Json(tList, JsonRequestBehavior.AllowGet);
        }

        // GET: Advertiser/Details/5
        public ActionResult GetByMerchant(int id)
        {
            Models.AdvertiserModel tModel = new Models.AdvertiserModel();
            List<merchant_advertisers> tList = tModel.Get();

            return Json(tList, JsonRequestBehavior.AllowGet);
        }

       

        // POST: Advertiser/Create
        [HttpPost]
        public ActionResult Create(merchant_advertisers Advertiser)
        {
            String tReturn = "";
            try
            {
                Models.AdvertiserModel tModel = new Models.AdvertiserModel();
                if (tModel.Create(Advertiser) == true)
                {
                    tReturn = "{\"status\":\"ok\"}";
                }
                else
                {
                    tReturn = "{\"status\":\"Failed\"}";
                }
               
            }
            catch
            {

                tReturn = "{\"status\":\"Failed\"}";
            }
            finally
            {
                
               
            }
            return Json(tReturn, JsonRequestBehavior.AllowGet);
        }

        // GET: Advertiser/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Advertiser/Edit/5
        [HttpPost]
        public ActionResult ChangeAdvertiser(int id, merchant_advertisers collection)
        {
            String tReturn = "";
            try
            {
                
                Models.AdvertiserModel tModel = new Models.AdvertiserModel();

                if ( tModel.Update(collection) )
                {
                    tReturn = "{\"status\":\"ok\"}";
                }
                {

                    tReturn = "{\"status\":\"failed\"}";
                }
            }
            catch
            {
                tReturn = "{\"status\":\"failed\"}";
                return Json(tReturn, JsonRequestBehavior.AllowGet);
            }
            return Json(tReturn, JsonRequestBehavior.AllowGet);
        }

        // GET: Advertiser/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Advertiser/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
