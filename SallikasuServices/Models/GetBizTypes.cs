using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SallikasuServices.Models
{
    public class GetBizTypes
    {
        nasthaEntities DB { get; set; }
        public GetBizTypes()
        {
            DB = new nasthaEntities();
        }
        public List<biz_types> Get()
        {
            List<biz_types> tList = (from b in DB.biz_types select b).ToList<biz_types>();

            return tList;
        }
    }
}