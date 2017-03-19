using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace SallikasuServices.Models
{
    public class ReferUserModel
    {
        nasthaEntities DB { get; set; }

        public ReferUserModel()
        {
            DB = new nasthaEntities();
                 
        }
        public bool Process( String UserID, List<String> ReferalUser)
        {
            user tUser = (from m in DB.users where m.email == UserID select m).FirstOrDefault();
            if (tUser == null)
                return false;

            foreach( string treferer in ReferalUser)
            {
                if ( Regex.IsMatch(treferer,@"\d") )
                {
                    //Call Exotel to confirm number.
                    SmsReferer(treferer);
                }
                else 
                {
                    System.ComponentModel.DataAnnotations.EmailAddressAttribute tAddress = new System.ComponentModel.DataAnnotations.EmailAddressAttribute();

                    if (tAddress.IsValid(treferer))
                    {
                        emailReferer(treferer);
                    }
                }
            }

            return true;

        }
        bool SmsReferer(string Number)
        {
            // Validate PhoneNumber
            
            // SMS Using exotel.
            List<system_configs> tConfigs = (from m in DB.system_configs
                                             where m.server_or_app == "S"
                                             && (m.tag == "EXOTEL_SID"
                                             || m.tag == "EXOTEL_TOKEN") select m).ToList();
            string tSid="", tToken="";
            foreach ( system_configs tconfig in tConfigs)
            {
                if ( tconfig.tag == "EXOTEL_SID")
                {
                    tSid = tconfig.value;
                }
                else if ( tconfig.tag == "EXOTEL_TOKEN")
                {
                    tToken = tconfig.value;
                    
                }
            }
            if ( tSid.Trim().Length == 0 || tToken.Trim().Length == 0)
            {
                return false;   
            }
            SendSMSExotel tExotel = new SendSMSExotel(tSid,tToken);
            
            return true;
        }
        bool emailReferer(string email)
        {
            return true;
        }
    }
}