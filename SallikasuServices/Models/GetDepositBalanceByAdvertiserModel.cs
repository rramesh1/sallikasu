using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SallikasuServices.Models
{
    public class GetDepositBalanceByAdvertiserModel
    {
        nasthaEntities DB { get; set; }
        public GetDepositBalanceByAdvertiserModel()
        {
            DB = new nasthaEntities();
        }
        public bool Process(int userid, int merchantid, out List<GetDepositBalanceByAdvertiserData> DepositList)
        {
            DepositList = null;
            try
            {

                DepositList = (from u in DB.users
                               from ma in DB.merchant_advertisers
                               where u.id == userid
                               && (merchantid == -1 || ( ma.merchant_id == merchantid&& ma.status == "A"))
                               select new GetDepositBalanceByAdvertiserData
                               {
                                   Sublocality = ma.merchant.sublocality,
                                   City = ma.merchant.city,
                                   State = ma.merchant.state,
                                   deposit_amount = ma.deposit_balance.HasValue? ma.deposit_balance.Value:0

                               }).ToList();
            }
            catch(Exception ex)
            {
                return false;
            }
            return true;
        }

    }
    public class GetDepositBalanceByAdvertiserData
    {

        public String Sublocality { get; set; }
        public string City { get; set; }
        public String State { get; set; }
        public String ZipCode { get; set; }
        public decimal deposit_amount { get; set; }


    }
}