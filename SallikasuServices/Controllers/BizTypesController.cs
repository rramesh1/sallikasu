using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SallikasuServices.Controllers
{
    public class BizTypesController : Controller
    {
        // GET: BizTypes
        public ActionResult Get()
        {
            SallikasuServices.Models.GetBizTypes tType = new Models.GetBizTypes();
            List<biz_types> tTypeList = tType.Get();
            return Json(tTypeList, JsonRequestBehavior.AllowGet);
        }

        // GET: BizTypes/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BizTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BizTypes/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: BizTypes/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BizTypes/Edit/5
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

        // GET: BizTypes/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BizTypes/Delete/5
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
