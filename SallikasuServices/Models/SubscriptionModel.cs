using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SallikasuServices.Models
{
    public class SubscriptionModel
    {
        nasthaEntities DB { get; set; }
        public SubscriptionModel()
        {
            DB = new nasthaEntities();
        }
        public List<subscription> Get()
        {
            List<subscription> tList = (from m in DB.subscriptions select m).ToList();

            return tList;
        }
    }
}