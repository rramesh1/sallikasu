using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SallikasuServices.Models
{
    public class CancelSubscriptionModel
    {
        nasthaEntities DB { get; set; }
        public CancelSubscriptionModel()
        {
            DB = new nasthaEntities();

        }
        public bool Process(int userid, int merchantid)
        {
            try
            {
                List<merchant_advertisers> tList = (from ma in DB.merchant_advertisers
                                                    where ma.merchant_id == merchantid
                                                    select ma).ToList();
                foreach ( merchant_advertisers tMerchant in tList)
                {
                    tMerchant.status = "C";
                    tMerchant.merchant.advertiser = "N";
                    tMerchant.merchant.opt_out = "Y";
                    tMerchant.merchant.black_listed = "N";
                    DB.merchant_advertisers.Attach(tMerchant);
                }
                DB.SaveChanges();
                return true;
            }
            catch(Exception )
            {
                return false;
            }

        }
    }
}