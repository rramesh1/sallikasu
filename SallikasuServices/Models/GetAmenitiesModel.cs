using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SallikasuServices.Models
{
    public class GetAmenitiesModel
    {
        nasthaEntities DB { get; set; }
        public GetAmenitiesModel()
        {
            DB = new nasthaEntities();
        }
        public List<amenity_types> Get()
        {
            List<amenity_types> tTypes = (from m in DB.amenity_types select m).ToList<amenity_types>();

            return tTypes;
        }

        
    }
}