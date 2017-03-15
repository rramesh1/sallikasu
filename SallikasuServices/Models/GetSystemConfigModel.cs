using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SallikasuServices.Models
{
    public class GetSystemConfigModel
    {
        private nasthaEntities DB { get; set; }
        public GetSystemConfigModel()
        {
            DB = new nasthaEntities();
        }
        public List<system_configs> Get(String CountryCode,String ConfigType)
        {
            List<system_configs> tList = (from m in DB.system_configs
                                          where m.server_or_app == ConfigType && m.country == CountryCode
                                          select m).ToList();

            return tList;
        }
    }
}