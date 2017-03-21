using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SallikasuServices.Models
{
    public class GetSubscriptionByAllAdvertiserModel
    {
        nasthaEntities DB { get; set; }

        public GetSubscriptionByAllAdvertiserModel()
        {
            DB = new nasthaEntities();
        }
        public bool Process(int userId, out List<GetSubscriptionsByAllAdvertiserData> GetSubs)
        {
            GetSubs = null;
            try
            {
                GetSubs = (from s in DB.subscriptions
                           from m in DB.merchant_advertisers
                           from u in DB.users
                           where u.id == userId
                           && u.merchant_id == m.merchant_id
                           && m.subscription_id == s.id
                           select new GetSubscriptionsByAllAdvertiserData
                           {
                               name = m.merchant.name,
                               city = m.merchant.city,
                               state = m.merchant.state,
                               deposit_money = s.deposit.HasValue ? s.deposit.Value : 0,
                               commission_percentage = s.commission_percentage.HasValue ? s.commission_percentage.Value : 0,
                               min_deposit_balance = s.min_deposit_balance.HasValue ? s.min_deposit_balance.Value : 0
                           }).ToList();
            }
            catch(Exception)
            {
                return false;
            }
            return true;
        }
    }
    public class GetSubscriptionsByAllAdvertiserData
    {
        public string name;
        public string city;
        public string state;
        public decimal deposit_money;
        public decimal commission_percentage;
        public decimal min_deposit_balance;
    }
}