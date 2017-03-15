using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace SallikasuServices.Controllers
{
    public class GetDestinationController : Controller
    {
        // GET: GetDestination
        public ActionResult Get(String State, String City)
        {
            SallikasuServices.Models.GetDestinationModel tModel = new Models.GetDestinationModel();
            List<String> tList;
            if (State == null)
                tList = tModel.GetState();
            else if (City == null)
                tList = tModel.GetCity(State);
            else
            {
                tList = tModel.GetSublocality(State, City);
            }
            return View();
        }

        
    }
}
