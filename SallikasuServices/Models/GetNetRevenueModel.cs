using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SallikasuServices.Models
{
    public class GetNetRevenueModel
    {
        nasthaEntities DB { get; set; }
        public GetNetRevenueModel()
        {
            DB = new nasthaEntities();
        }
        public bool Process(int userid,String start_mmyy, String end_mmyy, int merchantid,out List<GetNewRevenueData> tList)
        {
            tList = null;
            try
            {
                tList = (from au in DB.advertiser_users
                         from mb in DB.monthly_bills
                         from ma in DB.merchant_advertisers
                         where au.user_id == userid
                         && (merchantid == -1 || au.merchant_id == merchantid)
                         && ma.merchant_id == au.merchant_id
                         && ma.status == "A"
                         && mb.month >= Int16.Parse(start_mmyy.Substring(0, 2)) && mb.year >= Int16.Parse(start_mmyy.Substring(2, 2))
                         && mb.month <= Int16.Parse(end_mmyy.Substring(0, 2)) && mb.year <= Int16.Parse(end_mmyy.Substring(2, 2))
                         select new GetNewRevenueData {
                             month = mb.month.HasValue?mb.month.Value:0,
                             year = mb.year.HasValue?mb.year.Value:0,
                             cumulative_commission_after_free_cashback = (mb.cumul_amt_free_cbk.HasValue ? mb.cumul_amt_free_cbk.Value : 0) + (mb.cumul_comm_today.HasValue ? mb.cumul_comm_today.Value : 0),
                             forfeited_amount = mb.forfeited_amt_today.HasValue ? mb.forfeited_amt_today.Value : 0,
                             cashback_paid_by_sallikasu = mb.cumul_expcbk_today.HasValue ? mb.cumul_expcbk_today.Value:0,
                             
                         }).ToList();
            }
            catch(Exception )
            {
                return false;
            }
            return true;
        }
    }
    public class GetNewRevenueData
    {
        public int month;
        public int year;
        public decimal cumulative_commission_after_free_cashback;
        public decimal forfeited_amount;
        public decimal cashback_paid_by_sallikasu;
        public decimal net_amount;
        public GetNewRevenueData()
        {
            net_amount = cumulative_commission_after_free_cashback + forfeited_amount - cashback_paid_by_sallikasu;
        }
    }
}