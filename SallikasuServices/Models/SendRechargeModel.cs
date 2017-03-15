using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SallikasuServices.Models
{
    public class SendRechargeModel
    {
        nasthaEntities DB { get; set; }

        public SendRechargeModel()
        {
            DB = new nasthaEntities();
        }
        public bool Process(int MerchantId)
        {
            merchant tMerchant = (from m in DB.merchants where m.id == MerchantId select m).SingleOrDefault();
            if (tMerchant != null)
            {
                system_configs tConfig = (from s in DB.system_configs select s).SingleOrDefault();
                if ( tConfig != null)
                {


                }

            }
            return true;
        }
    }
}