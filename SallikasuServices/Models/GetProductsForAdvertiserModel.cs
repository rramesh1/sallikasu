using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace SallikasuServices.Models
{
    public class GetProductsForAdvertiserModel
    {
        nasthaEntities DB { get; set; }
        public GetProductsForAdvertiserModel()
        {
            DB = new nasthaEntities();
        }
        public List<product> Get(int Id)
        {
            merchant tMerchant = (from m in DB.merchant_advertisers
                                  where m.merchant_id == Id
                                  select m.merchant).FirstOrDefault();
            List<product> tProducts = tMerchant.products.ToList();
            return tProducts;
        }
    }
}