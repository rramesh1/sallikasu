using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SallikasuServices.Models
{
    public class GetCommissionPaidByAdvertiserModel
    {
        nasthaEntities DB { get; set; }
        public GetCommissionPaidByAdvertiserModel()
        {
            DB = new nasthaEntities();
        }
        public bool Process(int userid,DateTime StartDate, DateTime EndDate, int MerchantID, out List<GetCommissionPaidByAdvertiserData> tList)
        {
            tList = null;
            try
            {
                tList = (from u in DB.users
                         from ma in DB.merchant_advertisers
                         where u.id == userid
                         && ma.merchant_id == u.merchant_id
                         && (MerchantID == -1 || ma.merchant_id == MerchantID)
                         && ma.status == "A"
                         select new GetCommissionPaidByAdvertiserData
                         {
                             month = ma.merchant.name,
                             city = ma.merchant.city,
                             state = ma.merchant.state,
                             zipcode = ma.merchant.zipcode,
                             sublocality = ma.merchant.sublocality

                         }).ToList();
            }
            catch(Exception )
            {
                return false;
            }
            return true;
        }
    }
    public class GetCommissionPaidByAdvertiserData
    {
        public string month, year, city, state, zipcode, sublocality;
        public decimal cumul_comm_today;
    }
}