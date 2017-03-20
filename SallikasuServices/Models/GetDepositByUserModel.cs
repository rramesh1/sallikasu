using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SallikasuServices.Models
{
    public class GetDepositByUserModel
    {
        nasthaEntities DB { get; set; }

        public bool Process(int userid, out List<GetDepositByUserData> tList)
        {
            tList = null;
            try
            {
                tList = (from u in DB.users
                         from ad in DB.merchant_advertisers
                         from s in DB.subscriptions
                         where u.id == userid
                         && u.merchant_id == ad.merchant_id
                         && ad.subscription_id == s.id
                         select new GetDepositByUserData
                         {
                             Name = ad.merchant.name,
                             City = ad.merchant.city,
                             State = ad.merchant.state,
                             DepositAmount = ad.deposit_balance,
                             MinDepoistAmount = s.min_deposit_balance
                         }).ToList();
                if ( tList == null || tList.Count == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch(Exception )
            {
                return false;
            }
        }
    }
    public class GetDepositByUserData
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public decimal? DepositAmount { get; set; }
        public decimal? MinDepoistAmount { get; set; }
    }
}