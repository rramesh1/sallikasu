using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SallikasuServices.Models;
using Newtonsoft.Json;

namespace SallikasuServices.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult Index(String Type)
        {
            RegisterUserModel tRegisterUser = new RegisterUserModel();
            List<user> tUserList = tRegisterUser.GetUsers(Type);
            String tJson = JsonConvert.SerializeObject(tUserList);
            tRegisterUser = null;
            return Json(tJson, JsonRequestBehavior.AllowGet);
        }

        // GET: Register/Details/5
        public ActionResult Details(int id)
        {
            RegisterUserModel tRegisterUser = new RegisterUserModel();

            user tUser = tRegisterUser.GetUser(id);
            string tJson = JsonConvert.SerializeObject(tUser);
            return Json(tJson, JsonRequestBehavior.AllowGet);
        }

        
        // POST: Register/Create
        [HttpPost]
        public ActionResult Create(user collection)
        {
            try
            {
                // TODO: Add insert logic here
                RegisterUserModel tRegister = new RegisterUserModel();

                tRegister.SetUser(collection);

                return Json("{\"status\":\"ok\"}", JsonRequestBehavior.AllowGet) ;
            }
            catch
            {
                return Json("{\"status\":\"fail\"}");
            }
        }

        // GET: Register/Edit/5
        public ActionResult Edit(int id)
        {
            RegisterUserModel tRegister = new RegisterUserModel();
            user tUser = tRegister.GetUser(id);
            return Json(tUser,JsonRequestBehavior.AllowGet);
        }

        // POST: Register/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, user collection)
        {
            try
            {
                // TODO: Add update logic here

                RegisterUserModel tRegister = new RegisterUserModel();
                tRegister.SetUser(collection);
                return Json("{\"status\":\"ok\"}");
            }
            catch
            {
                return Json("{\"status\":\"failed\"}");
            }
        }

        

        // POST: Register/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                RegisterUserModel tRegister = new RegisterUserModel();
                tRegister.DeleteUser(id);
                return Json("{\"status\":\"ok\"}");
            }
            catch
            {
                return Json("{\"status\":\"fail\"}");
            }
        }
    }
}
