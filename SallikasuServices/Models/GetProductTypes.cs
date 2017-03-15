using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SallikasuServices.Models
{
    
    public class GetProductTypesModel
    {
        nasthaEntities DB { get; set; }

        public GetProductTypesModel()
        {
            DB = new nasthaEntities();
        }
        public List<product> Get()
        {
            List<product> tList = (from p in DB.products select p).ToList();
            return tList;
        }
    }
}