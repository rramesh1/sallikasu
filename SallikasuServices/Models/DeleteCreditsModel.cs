using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SallikasuServices.Models
{
    public class DeleteCreditsModel
    {
        nasthaEntities DB { get; set; }

        public DeleteCreditsModel()
        {
            DB = new nasthaEntities();
        }

        public bool Process(int UserId, decimal CreditRemaining)
        {
            List<nastha_credits> tCredits = (from nc in DB.nastha_credits where nc.user_id == UserId select nc).ToList();

            if ( tCredits.Count > 0 )
            {
                foreach ( nastha_credits tcredit in tCredits)
                {
                    DB.nastha_credits.Remove(tcredit);
                }
               
                nastha_credits tAddCredits = new nastha_credits();
                tAddCredits.credit_received = CreditRemaining;
                tAddCredits.credit_type = "R";
                int? tMerchantID = (from sc in DB.users where sc.id == UserId select sc.merchant_id).FirstOrDefault();
                tAddCredits.merchant_id = tMerchantID;
                tAddCredits.created_at = tAddCredits.updated_at = DateTime.Now;

                DB.nastha_credits.Add(tAddCredits);
                DB.SaveChanges();

                return true;
            }
            return false;
             
        }
    }
}