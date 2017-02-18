using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TextSearchRequest
{
    public class GetPlacePhoto
    {
        String SearchStr = "https://maps.googleapis.com/maps/api/place/photo?maxwidth=400&key=AIzaSyCsuHqQzUYUbGsAWpQOU7v_E-RZRzsSNqY";
        public GetPlacePhoto()
        {

        }
        public bool process(string PhotoReference, String PlaceID, out String FileName)
        {
            FileName = "";
            System.Net.WebClient http = new System.Net.WebClient();
            String tSearch = SearchStr + "&photoreference=" + PhotoReference;
            try
            {
                FileName = "c:\\temp\\" + PlaceID;
                http.DownloadFile(tSearch, FileName);
                return File.Exists(FileName);
            }
            catch (ArgumentNullException nex)
            {
                return false;
            }
            catch (System.Net.WebException ex)
            {
                return false;
            }
            finally
            {
                http.Dispose();
            }
            
        }

    }
}
