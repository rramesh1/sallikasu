using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Data.Entity;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace TextSearchRequest
{
    class TextSearchModel
    {
        public TextSearchModel()
        {
            
        }
        public bool process(string Locality, String City, String Zipcode)
        {
            if (City.Length == 0)
                return false;
            if (Locality.Length == 0 && Zipcode.Length == 0)
                return false;

            string tGoogleSearch = "https://maps.googleapis.com/maps/api/place/textsearch/json?query=";
            String tParameter = City.Trim();
            if (Locality.Length > 0)
                tParameter = Locality.Trim() + "+" + tParameter;
            if (Zipcode.Length > 0)
                tParameter = tParameter + "+" + Zipcode.Trim();
            

            tGoogleSearch += tParameter + "&type=restaurant"+ "&key=AIzaSyCsuHqQzUYUbGsAWpQOU7v_E-RZRzsSNqY";
            String tSearch;
            GetTextSearchRequest(tGoogleSearch, out tSearch);
            if (tSearch == null)
            {
                return false;
            }
            else
            {
                ParseMessage(tSearch);
                return true;
            }
        }
        
        bool ParseMessage(string Response)
        {
            var tPlaceSearchResponse = JsonConvert.DeserializeObject<RootObject>(Response);
            if (tPlaceSearchResponse.status.ToUpper() != "OK")
            {
                System.Console.WriteLine("TextSearch return a not OK response.");
                return false ;
            }

            AddMerchantPlaceIdModel tAddMerchant = new AddMerchantPlaceIdModel();
            foreach (Result tPlace in tPlaceSearchResponse.results)
            {
                tAddMerchant.AddMerchant(tPlace);
            }
            return true;
        } 
       
        void GetTextSearchRequest(string tGoogleSearch, out String Results)
        {
            Results = "";
            System.Net.WebClient http = new System.Net.WebClient();
            try
            {
                System.IO.Stream tStream = http.OpenRead(tGoogleSearch);
                if (tStream != null)
                {
                    StreamReader sr = new StreamReader(tStream);
                    Results = sr.ReadToEnd();
                }
            }
            catch (ArgumentNullException nex)
            {
                
            }
            catch (System.Net.WebException ex)
            {

            }

        }
    }
}
