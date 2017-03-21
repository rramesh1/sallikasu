using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SallikasuServices.Models
{
    public class GetMySubscriptionModel
    {
        nasthaEntities DB { get; set; }
        public GetMySubscriptionModel()
        {
            DB = new nasthaEntities();
        }

        public bool Process(int Userid, int merchantid, out List<GetMySubscriptionData> tList)
        {
            tList = null;
            try
            {
                tList = (from s in DB.subscriptions
                         from u in DB.users
                         from ma in DB.merchant_advertisers
                         where u.id == Userid
                         && ma.merchant_id == u.merchant_id
                         && ma.subscription_id == s.id
                         && (merchantid == -1 || ma.merchant_id == merchantid)
                         select new GetMySubscriptionData
                         {
                             name = ma.merchant.name,
                             sublocality = ma.merchant.sublocality,
                             city = ma.merchant.city,
                             state = ma.merchant.state,
                             deposit_money = s.deposit.HasValue ? s.deposit.Value : 0,
                             commission_percentage = s.commission_percentage.HasValue ? s.commission_percentage.Value : 0,
                             min_deposit_amount = s.min_deposit_balance.HasValue ? s.min_deposit_balance.Value : 0

                         }).ToList();
            }
            catch(Exception)
            {
                return false;
            }
            return true;
        }
    }
    public class GetMySubscriptionData
    {
        public String name, sublocality, city, state, zipcode;
        public decimal deposit_money, commission_percentage, min_deposit_amount;
    }
}