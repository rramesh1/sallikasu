using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;


namespace TextSearchRequest
{
    public class AddMerchantPlaceIdModel
    {
        private TextSearchRequest.TextSearch m_DB;
        public TextSearch DB { get { return m_DB; }  }

        public AddMerchantPlaceIdModel()
        {
            m_DB = new TextSearch();
            //m_DB.Database.Connection.ConnectionString = ConfigurationManager.ConnectionStrings["TextSearch"].ConnectionString;
            //m_DB.Database.Connection.Open();
            //m_DB.Database.Connection.Close();
        }
        /*@
         * @Description: This method takes the PlaceID search Response and adds to the merchant table. This should be run 
         * before running the placedetails query.
         */
        public void AddMerchant( Result Place)
        {
            IQueryable<merchant> tmerchants = from a in DB.merchants where a.place_id == Place.place_id select a;

            if (tmerchants != null && tmerchants.Count() > 0)
                return;
            merchant tMerchant = new merchant();
            tMerchant.name = Place.name;
            tMerchant.place_id = Place.place_id;
            tMerchant.advertiser = "N";
            tMerchant.created_at = DateTime.Now;
            ProcessPhoto(Place.photos, ref tMerchant);

            DB.merchants.Add(tMerchant);
            DB.SaveChanges();

        }
        private bool ProcessPhoto(List<Photo> photos, ref merchant Merchant)
        {
            if (photos != null && photos.Count > 0)
            {
                GetPlacePhoto tPhotoSearch = new GetPlacePhoto();
                String tFilename = "";
                if (tPhotoSearch.process(photos[0].photo_reference, Merchant.place_id, out tFilename))
                {
                    Merchant.pictures = new List<picture>();
                    picture tPicture = new picture();
                    tPicture.merchant = Merchant;
                    tPicture.interior_photo_url = tFilename;
                    
                    Merchant.pictures.Add(tPicture);
                }
                tPhotoSearch = null;
            }
            
            return true;
        }


    }
}