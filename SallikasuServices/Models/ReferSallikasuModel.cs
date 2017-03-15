using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SallikasuServices.Models
{
    public class ReferSallikasuModel
    {
        nasthaEntities DB { get; set; }
        public ReferSallikasuModel()
        {
            DB = new nasthaEntities();
        }
        public bool Process(String User, int MerchantID, String OwnerCellphone)
        {
            try
            {
                //Validate Phonenumber
                ValidateNumberTwillio tNumberValidation = new ValidateNumberTwillio();
                if (!tNumberValidation.Validate(OwnerCellphone))
                    return false;

                merchant tMerchant = (from m in DB.merchants
                                      where m.id == MerchantID  && 
                                      m.opt_out == "N" select m).FirstOrDefault();
                if (tMerchant == null)
                    return false;

                tMerchant.cumulative_referrals += 1;

                List<user_merchant_referrals> tUsers = (from u in DB.user_merchant_referrals                                     
                                                        where u.cell_phone_entered_by_user == OwnerCellphone 
                                                        select u).ToList();
                List<DateTime> tcount = (from d in tUsers
                                         group d by d.created_at into grp
                                         where grp.Count() > 1
                                         select grp.Key).ToList();
                if (tcount == null || tcount.Count == 0)
                {
                    return false;
                }
                tMerchant.permanent_cell_phone_number = OwnerCellphone;

                RegistrationCodeModel tRegCodeModel = new RegistrationCodeModel();
                int tRegCode = tRegCodeModel.Get(MerchantID);

                String tFreeReferalsThresholdStr = (from sc in DB.system_configs
                                                 where sc.tag == "free_referals_threshold"
                                                 select sc.value).FirstOrDefault();
                int tFreeReferalsThreshold = Int32.Parse(tFreeReferalsThresholdStr);

                string tSidStr = (from sid in DB.system_configs
                                  where sid.tag == "EXOTEL_SID"
                                  select sid.value).FirstOrDefault();
                String tTokenStr = (from tok in DB.system_configs
                                    where tok.tag == "EXOTEL_TOKEN"
                                    select tok.value).FirstOrDefault();

                String tFromPhoneStr = (from tok in DB.system_configs
                                        where tok.tag == "SALLIKASU_PHONE"
                                        select tok.value).FirstOrDefault();

                SendSMSExotel tExotelSMS = new SendSMSExotel(tSidStr, tTokenStr);
                if ( tMerchant.cumulative_referrals < tFreeReferalsThreshold)
                {
                    tExotelSMS.execute(tFromPhoneStr, OwnerCellphone, "REFER_SALIKASU"); //TODO: we are going to have to put a string here.
                    
                }
                else if ( tMerchant.cumulative_referrals * (1 + 10 / 100) > tFreeReferalsThreshold)
                {
                    tExotelSMS.execute(tFromPhoneStr, OwnerCellphone, "SALIKASU_DELIST"); //TODO: we are going to have to put a string here.
                }

                return true;

            }
            catch( Exception  )
            {
                return false;
            }
        }
    }
}