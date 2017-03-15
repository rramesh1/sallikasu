using System;
using System.Collections.Generic;
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


            token tTokenRec = new token();
            tTokenRec.cell_number = cellphonenumber;
            tTokenRec.merchant_id = advertiserid;
            tTokenRec.user_id = userid;
            tTokenRec.token_number = tToken;
            DB.tokens.Add(tTokenRec);
            DB.SaveChanges();
            return tToken;
        }
    }
}