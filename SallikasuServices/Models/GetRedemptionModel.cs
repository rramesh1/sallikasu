using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SallikasuServices.Models
{
    public class GetRedemptionModel
    {
        nasthaEntities DB { get; set; }
        public GetRedemptionModel()
        {
            DB = new nasthaEntities();
        }
        public bool Process(int UserId, DateTime StartDtTm, DateTime EndDtTm, out decimal? TotalRedemption, out List<GetRedemptionData> RedemptionList)
        {
            TotalRedemption = 0;
            RedemptionList = null;
            try
            {
                RedemptionList = (from nr in DB.nastha_redemptions
                                  where nr.user_id == UserId
                                  && nr.created_at > StartDtTm
                                  & nr.created_at < EndDtTm
                                  select new GetRedemptionData
                                  {
                                      merchant_name = nr.merchant.name,
                                      city = nr.merchant.city,
                                      amount_redeemed = nr.amount_redeemed,
                                      created_at = nr.created_at
                                  }
                                  ).ToList();

                if (RedemptionList == null && RedemptionList.Count() > 0)
                {
                    TotalRedemption = (from tr in RedemptionList select tr.amount_redeemed).Sum();
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    }
    public class GetRedemptionData
    {
        public GetRedemptionData()
        { }
        public String merchant_name { get; set; }
        public string city { get; set; }
        public decimal? amount_redeemed { get; set; }
        public DateTime created_at { get; set; }
    }
}