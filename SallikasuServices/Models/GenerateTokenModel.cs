using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace SallikasuServices.Models
{
    public class GenerateTokenModel
    {
        nasthaEntities DB { get; set; }
        public GenerateTokenModel()
        {
            DB = new nasthaEntities();
        }
        public int process(int userid, int advertiserid, string cellphonenumber)
        {
            Random tRand = new Random();

            int tToken = tRand.Next(1000, 9999);
            try
            {

                token tTokenRec = new token();
                tTokenRec.cell_number = cellphonenumber;
                tTokenRec.merchant_id = advertiserid;
                tTokenRec.user_id = userid;
                tTokenRec.token_number = tToken;
                DB.tokens.Add(tTokenRec);
                DB.SaveChanges();
            }
            catch ( DbUpdateConcurrencyException)
            {
                return -1;
            }
            catch(DbUpdateException )
            {
                return -1;
            }
            catch ( DbEntityValidationException)
            {
                return -1;
            }
            catch(NotSupportedException)
            {
                return -1;
            }
            return tToken;
        }
        private decimal CalculateCommission(int advertiserID)
        {
            decimal? tCommPercent = (from c in DB.subscriptions
                                   from ma in DB.merchant_advertisers
                                   where ma.merchant_id == advertiserID
                                   && ma.subscription_id == c.id
                                   select c.commission_percentage).FirstOrDefault();

            decimal tNetComm = -1;

            if ( tCommPercent != null)
            {
                String tValue = (from sc in DB.system_configs
                                 where sc.tag == "REFERAL_COMMISSION"
                                 && sc.server_or_app == "SERVER"
                                 select sc.value).FirstOrDefault();
                decimal tRefCut = Decimal.Parse(tValue);
                decimal? tReferalPercentage =  tCommPercent * tRefCut;

                tValue = (from scc in DB.system_configs
                          where scc.tag == "MIN_COMMISSION"
                          && scc.server_or_app == "SERVER"
                          select scc.value).FirstOrDefault();
                decimal tMinComm = Decimal.Parse(tValue);
                if (tRefCut > 0 && tCommPercent > tMinComm)
                {
                    tNetComm = tRefCut;
                }
                else
                {
                    tValue = (from scr in DB.system_configs
                              where scr.tag == "MIN_NET_COMMISSION"
                              && scr.server_or_app == "SERVER"
                              select scr.value).FirstOrDefault();
                    tNetComm = Decimal.Parse(tValue);

                }
            }

            return tNetComm;

        }
    }
}