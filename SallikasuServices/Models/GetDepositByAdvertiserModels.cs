using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SallikasuServices.Models
{
    public class GetDepositByAdvertiserModels
    {
        nasthaEntities DB { get; set; }
        public GetDepositByAdvertiserModels()
        {
            DB = new nasthaEntities();
        }
        public bool Process(int userid, DateTime startDate, DateTime EndDate, int MerchantId, out List<GetDepositByAdvertiserData> tList)
        {
            tList = null;
            try
            {
                tList = (from u in DB.users
                         from ma in DB.merchant_advertisers
                         from ad in DB.advertiser_deposit
                         where u.id == userid
                         && ma.merchant_id == u.merchant_id
                         && (MerchantId == -1 || ma.merchant_id == MerchantId)
                         && ad.merchant_id == ma.merchant_id
                         && ad.deposit_received_dt >= startDate && ad.deposit_received_dt <= EndDate
                         select new GetDepositByAdvertiserData
                         {
                             city = ma.merchant.city,
                             state = ma.merchant.state,
                             sublocality = ma.merchant.sublocality,
                             zipcode = ma.merchant.zipcode,
                             deposit_date = ad.deposit_received_dt,
                             amount_deposit = ad.amount_deposit
                         }).ToList();
            }
            catch(Exception ex)
            {
                return false;
            }
            return true;
        }
    }
    public class GetDepositByAdvertiserData
    {
        public String sublocality, city, state, zipcode;
        public decimal amount_deposit;
        public DateTime deposit_date;
    }
}