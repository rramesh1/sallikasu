using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SallikasuServices.Models
{
    public class GetServiceTaxModel
    {
        nasthaEntities DB { get; set; }
        public GetServiceTaxModel()
        {
            DB = new nasthaEntities();
        }
        public bool Process(int userid, int month,int year, out decimal cumm_service_tax)
        {
            cumm_service_tax = 0; 
            try
            {
                decimal? tCummServiceTax = (from mb in DB.monthly_bills
                                            from u in DB.users
                                            where u.id == userid
                                            && mb.merchant_id == u.merchant_id
                                            && mb.month == month
                                            && mb.year == year
                                            select mb.tax).Sum();
                cumm_service_tax = tCummServiceTax.HasValue ? tCummServiceTax.Value : 0;

                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}