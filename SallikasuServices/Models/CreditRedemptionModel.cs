using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SallikasuServices.Models
{
    public class CreditRedemptionModel
    {
        nasthaEntities DB { get; set; }
        public CreditRedemptionModel()
        {
            DB = new nasthaEntities();

        }
        public bool Process(int userid, int merchantid,decimal AmountRedeemed)
        {
            try
            {
                /*
                 * If the Server does NOT find the user_id in the users table AND the merchant_id in the merchant_advertisers table, then Server creates a record in the sallikasu_redemptions table..
                 */
                user tUser = (from u in DB.users where u.id == userid select u).FirstOrDefault();
                if (tUser == null )
                {
                    merchant_advertisers tAdvert = (from ma in DB.merchant_advertisers where ma.merchant_id == merchantid select ma).FirstOrDefault();
                    if ( tAdvert == null )
                    {
                        nastha_redemptions tRedemption = new nastha_redemptions();
                        tRedemption.amount_redeemed = AmountRedeemed;
                        tRedemption.created_at = tRedemption.updated_at = DateTime.Now;
                        tRedemption.merchant_id = merchantid;
                        tRedemption.user_id = userid;
                        DB.nastha_redemptions.Add(tRedemption);
                        DB.SaveChanges();
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch(Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}