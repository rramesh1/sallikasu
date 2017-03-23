using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SallikasuServices.Models
{
    public class TransactionMetricsModel
    {
        nasthaEntities DB { get; set; }
        public TransactionMetricsModel()
        {
            DB = new nasthaEntities();
        }
        public bool Process(int userid, String start_mmyy, String end_mmyy, int merchantid, out List<TransactionMetricsData> tList)
        {
            tList = null;
            try
            {
                tList = (from mb in DB.monthly_bills
                         from u in DB.users
                         where u.id == userid
                         && u.merchant_id == mb.merchant_id
                         && (merchantid == null || mb.merchant_id == merchantid)
                         && mb.month >= Int16.Parse(start_mmyy.Substring(0, 2)) && mb.year >= Int16.Parse(start_mmyy.Substring(2, 2))
                         && mb.month <= Int16.Parse(end_mmyy.Substring(0, 2)) && mb.year <= Int16.Parse(end_mmyy.Substring(2, 2))
                         select new TransactionMetricsData
                         {
                             month = mb.month.HasValue?mb.month.Value:0,
                             year = mb.year.HasValue?mb.year.Value:0,
                             sublocality=mb.merchant.sublocality,
                             city  = mb.merchant.city,
                             state  = mb.merchant.state,
                             zipcode = mb.merchant.zipcode,

                         }).ToList();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }
    }
    public class TransactionMetricsData
    {
        public string sublocality, city, state, zipcode;
        public int month, year, number_of_customers, incremental_number_of_customers;
        decimal gross_amount, alcohol_total,
                 incremental_gross_amount,
                 incremental_alcohol_total,
                 number_of_repeat_customers;

    }
}