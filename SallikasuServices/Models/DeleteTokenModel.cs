using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SallikasuServices.Models
{
    public class DeleteTokenModel
    {
        nasthaEntities DB { get; set; }
        public DeleteTokenModel()
        {
            DB = new nasthaEntities();
        }
        public bool Process(int token)
        {
            try
            {
                token tToken = (from t in DB.tokens where t.token_number == token select t).FirstOrDefault();
                if ( tToken == null)
                {
                    return false;
        
                }
                DB.tokens.Remove(tToken);
                DB.SaveChanges();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}