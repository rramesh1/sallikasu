using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SallikasuServices.Models
{
    public class GetDepositBalanceByAllAdvertisersModel
    {
        nasthaEntities DB { get; set; }
        
        public GetDepositBalanceByAllAdvertisersModel()
        {
            DB = new nasthaEntities();
        }
        public bool Process(int UserID, DateTime StartDate, DateTime EndDate, out List<GetDepositBalanceByAllAdvertiserData> tList)
        {
            tList = null;
            try
            {
                tList = (from u in DB.users
                         from ma in DB.merchant_advertisers
                         from ad in DB.advertiser_deposit
                         where u.id == UserID
                         && u.merchant_id == ma.merchant_id
                         && ma.merchant_id == ad.merchant_id
                         && (ad.created_at >= StartDate && ad.created_at <= EndDate)
                         select new GetDepositBalanceByAllAdvertiserData
                         {
                             Name = ma.merchant.name,
                             City = ma.merchant.city,
                             State = ma.merchant.state,
                             deposit_received_date = ad.deposit_received_dt,
                             amount_deposited = ad.amount_deposit

                         }).ToList();
            }
            catch(Exception ex)
            {
                return false;
            }
            return true;
        }

    }
    public class GetDepositBalanceByAllAdvertiserData
    {
        public String Name;
        public String City;
        public String State;
        public DateTime deposit_received_date;
        public decimal amount_deposited;
    }
}