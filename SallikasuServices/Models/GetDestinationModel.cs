using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SallikasuServices.Models
{
    public class GetDestinationModel
    {
        nasthaEntities DB { get; set; }

        public GetDestinationModel()
        {
            DB = new nasthaEntities();
        }
        public List<String> GetState()
        {
            List<String> tDestinations = (from m in DB.merchants  select new (m.state)).Distinct().ToList();

            return tDestinations;
        }
        public List<String> GetCity(String State)
        {
            List<String> tDestinations = (from m in DB.merchants where m.state == State select new (m.city)).Distinct().ToList();

            return tDestinations;
        }
        public List<String> GetSublocality(String State, String City)
        {
            List<String> tDestinations = (from m in DB.merchants where m.state == State && m.city == City select new (m.sublocality)).Distinct().ToList();

            return tDestinations;
        }
    }
    public class DestinationModel
    {
        public DestinationModel(String state,String city, String subLocality )
        {
            State = state;
            City = city;
            SubLocality = subLocality;
        }
        public String State { get; set; }
        public String City { get; set; }
        public string SubLocality { get; set; }
    }
}