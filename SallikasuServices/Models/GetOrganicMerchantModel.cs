using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SallikasuServices.Models;
namespace SallikasuServices.Models
{
    public class GetOrganicMerchantModel
    {
        public nasthaEntities DB { get; set; }
        public GetOrganicMerchantModel()
        {
            DB = new nasthaEntities();
        }
        public List<merchant> Get(String State, String City, String Type, String Name)
        {
            List<merchant> tMerchantList = (from m in DB.merchants 
                                            where (m.state == State && m.city == City) && (m.name == Name || Name == "") && m.type == Type
                                            select m).ToList<merchant>();

            return tMerchantList;
        }
    }
}