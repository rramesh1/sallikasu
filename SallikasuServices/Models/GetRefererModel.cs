using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SallikasuServices.Models
{
    public class GetRefererModel
    {
        nasthaEntities DB { get; set; }

        public GetRefererModel()
        {
            DB = new nasthaEntities();
        }
        public bool Get(string Cellphone)
        {
            referred_users tuser = (from m in DB.referred_users where m.referred_user_email_address == Cellphone select m).FirstOrDefault();
            return (tuser == null);
        }
    }
}