using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SallikasuServices.Models
{
    
    public class RegistrationCodeModel
    {
        nasthaEntities DB { get; set; }
        public RegistrationCodeModel()
        {
            DB = new nasthaEntities();
        }
        public bool Verify(int RegistrationCode)
        {
            registration_codes tCode = (from m in DB.registration_codes where m.registration_code == RegistrationCode select m).FirstOrDefault();

            if (tCode == null)
                return false;

            return true;
        }
        public int Get(int MerchantId)
        {
            registration_codes tCode = (from m in DB.registration_codes where m.merchant_id == MerchantId select m).FirstOrDefault();

            if ( tCode == null)
            {
                Random tGen =  new Random();
                Int32 tNum;
                while (true)
                {
                    tNum = Int32.Parse( tGen.Next(0, 1000000).ToString("D6"));
                    registration_codes tcount = (from t in DB.registration_codes where t.registration_code == tNum select t).FirstOrDefault();
                    if ( tcount == null)
                    {
                        registration_codes tNewCode = new registration_codes();
                        tNewCode.merchant_id = MerchantId;
                        tNewCode.registration_code = tNum;
                        DB.registration_codes.Add(tNewCode);
                        DB.SaveChanges();
                        return tNum;
                    }
                }
            }
            return -1;
        }
    }
}