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
        public bool Process(int userid,String StartDate, String EndDate, int MerchantID, out List<GetCommissionPaidByAdvertiserData> tList)
        {
            tList = null;
            try
            {
                tList = (from u in DB.users
                         from ma in DB.merchant_advertisers
                         from mb in DB.monthly_bills
                         where u.id == userid
                         && ma.merchant_id == u.merchant_id
                         && (MerchantID == -1 || ma.merchant_id == MerchantID)
                         && mb.merchant_id == ma.merchant_id
                         && ma.status == "A"
                         && (mb.month >= Int16.Parse(StartDate.Substring(0, 2)) && mb.year >= Int16.Parse(StartDate.Substring(2, 2))
                         && mb.month <= Int16.Parse(EndDate.Substring(0, 2)) && mb.year <= Int16.Parse(EndDate.Substring(2, 2))
                         )
                         orderby mb.year, mb.month
                         select new GetCommissionPaidByAdvertiserData
                         {
                             month = mb.month.HasValue ? mb.month.Value : 0,
                             year = mb.year.HasValue ? mb.year.Value : 0,
                             city = ma.merchant.city,
                             state = ma.merchant.state,
                             zipcode = ma.merchant.zipcode,
                             sublocality = ma.merchant.sublocality,
                             cumul_comm_today = mb.cumul_comm_today.HasValue? mb.cumul_comm_today.Value:0

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
        public int month, year;
        public string city, state, zipcode, sublocality;
        public decimal cumul_comm_today;
    }
}