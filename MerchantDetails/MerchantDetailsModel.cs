using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Net;

namespace MerchantDetails
{
    class MerchantDetailsModel
    {
        private List<merchant> PlaceDetailsList { get; set; }
        private nasthaEntities DB { get; }
        private string SearchStr {get;set; }
        public MerchantDetailsModel()
        {
            DB = new nasthaEntities();
            PlaceDetailsList = new List<merchant>();
        }

        public bool GetMerchantList()
        {
            try
            {
                PlaceDetailsList = (from m in DB.merchants where m.address == null && m.place_id != null  select m).ToList<merchant>();

            }
            catch (Exception ex)
            {
                String Message = ex.Message + ex.InnerException != null ? " InnerException: " + ex.InnerException.Message : "";
                System.Console.WriteLine("Error Getting PlaceID from database: " + Message);
                return false;
            }
            return true;
        }
        
        public void GetPlaceDetails()
        {
            SearchStr = "https://maps.googleapis.com/maps/api/place/details/json?key=AIzaSyCsuHqQzUYUbGsAWpQOU7v_E-RZRzsSNqY";
            RootObject tResponse;
            foreach ( merchant tMerchant in PlaceDetailsList)
            {
                if ( !GetPlaceDetails(tMerchant, out tResponse))
                {
                    return;
                }
                if ( tResponse != null)
                {
                    SaveMerchantDetails tSave = new SaveMerchantDetails();
                    tSave.ProcessMerchantDetail(tResponse);
                    
                }
            }
        }
        public bool GetPlaceDetails(merchant Merchant, out RootObject PlaceDetail)
        {
            String tSearchStr = SearchStr + "&placeid=" +Merchant.place_id;
            PlaceDetail = null;
            System.Net.WebClient http = new System.Net.WebClient();
            
            try
            {
                System.IO.Stream tStream = http.OpenRead(tSearchStr);
                if (tStream != null)
                {
                    System.IO.StreamReader tReader = new System.IO.StreamReader(tStream);
                    String tResponse = tReader.ReadToEnd();
                    PlaceDetail = (RootObject)JsonConvert.DeserializeObject(tResponse, typeof(RootObject));

                    if (PlaceDetail.status.ToUpper() != "OK")
                    {
                        System.Console.WriteLine("TextSearch return a not OK response.");
                        return false;
                    }
                    tReader.Dispose();
                }
            }
            catch(WebException ex)
            {
                String tMessage = ex.Message + ex.InnerException == null ? "" : " InnerException : " + ex.InnerException.Message;
                System.Console.WriteLine(tMessage);
                return false;
            }
            catch (Exception ex)
            {
                String tMessage = ex.Message + ex.InnerException == null ? "" : " InnerException : " + ex.InnerException.Message;
                System.Console.WriteLine(tMessage);
                return false;
            }
            finally
            {
                http.Dispose();
            }
           return true;
        }
    }
}
