using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SallikasuServices.Models
{
    public class GetAdvertisersForFeaturePhoneModel
    {
        nasthaEntities DB { get; set; }
        public GetAdvertisersForFeaturePhoneModel()
        {
            DB = new nasthaEntities();
        }
        public List<merchant> Process( String State, String city, String Sublocality, string Category)
        {
            system_configs tconfig = (from s in DB.system_configs where s.tag == "FeaturePhoneLimit" select s).FirstOrDefault();
            int FeaturePhoneLimit = Int32.Parse(tconfig.value);
            List < merchant > tList = (from m in DB.merchants
                                       where m.state == State
                                       && m.city == city
                                       && m.sublocality == Sublocality
                                       select m).Take(FeaturePhoneLimit).ToList();

            return
        }
    }
}