using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SallikasuServices.Controllers
{
    public class ReferUserController : Controller
    {
        // GET: ReferUser
        public ActionResult Index(String UserID, List<string> Referer)
        {
            Models.ReferUserModel tRefer = new Models.ReferUserModel();
            String  tJson = "{\"status\":\"failed\"}";
            if ( tRefer.Process(UserID, Referer))
            {
                tJson = "{\"status\":\"ok\"}";
            }
            return Json(tJson, JsonRequestBehavior.AllowGet);
           
        }

        // GET: ReferUser/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ReferUser/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ReferUser/Create
        [HttpPost]
        public ActionResult Create(String UserID, List<String> collection)
        {
            try
            {
                

                String tJson = "{\"RegistrationCode\":\"ok\"}";
                return Json(tJson, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                String tJson = "{\"RegistrationCode\":\"failed\"}";
                return Json(tJson, JsonRequestBehavior.AllowGet);
            }
        }

        // GET: ReferUser/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ReferUser/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ReferUser/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ReferUser/Delete/5
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
