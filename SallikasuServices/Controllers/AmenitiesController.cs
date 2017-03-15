using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SallikasuServices.Models
{
    public class AmenitiesController : Controller
    {
        // GET: Amenities
        public ActionResult Index()
        {
            return View();
        }

        // GET: Amenities/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Amenities/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Amenities/Create
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

        // GET: Amenities/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Amenities/Edit/5
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

        // GET: Amenities/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Amenities/Delete/5
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
