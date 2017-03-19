using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SallikasuServices.Models
{
    public class GetCreditsModel
    {
        nasthaEntities DB { get; set; }
        public GetCreditsModel()
        {
            DB = new nasthaEntities();
        }
        public bool Process(String UserID, out decimal? TotalCredits, out List<nastha_credits> CreditList)
        {
            TotalCredits = null;
            CreditList = null;
            try
            {
                
                CreditList = (from nc in DB.nastha_credits
                              from u in DB.users
                              where u.email == UserID
                              && u.id == nc.user_id
                              select nc).ToList();
                TotalCredits = (from tc in CreditList
                                select tc.credit_received).Sum();
            }
            catch(ArgumentNullException)
            {
                return false;
            }
            return true;

        }
    }
}