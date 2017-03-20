using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SallikasuServices.Models
{
    public class CreateDepositModel
    {
        nasthaEntities DB { get; set; }
        public CreateDepositModel()
        {
            DB = new nasthaEntities();
        }
        public bool Process(int merchantid, decimal amount_deposit)
        {
            try
            {
                merchant_advertisers tMerchant = (from m in DB.merchant_advertisers where m.merchant_id == merchantid select m).FirstOrDefault();
                if (tMerchant == null)
                    return false;
                tMerchant.status = "A";
                tMerchant.deposit_balance += amount_deposit;
                advertiser_deposit tAdDeposit = new advertiser_deposit();
                tAdDeposit.amount_deposit = amount_deposit;
                tAdDeposit.deposit_received_dt = DateTime.Now;
                tAdDeposit.merchant_id = merchantid;
                tAdDeposit.created_at = DateTime.Now;
                DB.advertiser_deposit.Add(tAdDeposit);

                subscription tSub = (from s in DB.subscriptions where s.id == tMerchant.subscription_id select s).FirstOrDefault();
                if ( tSub != null &&  tMerchant.deposit_balance > tSub.min_deposit_balance)
                {
                    tMerchant.merchant.opt_out = "N";   
                }
                else
                {
                    return false;
                }
                DB.merchant_advertisers.Attach(tMerchant);
                DB.SaveChanges();
            }
            catch(Exception ex)
            {
                return false;
            }
            return true;
        }

    }
}