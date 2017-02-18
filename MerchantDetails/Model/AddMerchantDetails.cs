using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MerchantDetails
{
    public class AddMerchantDetails
    {
        public nasthaEntities DB { get; set; }
        public AddMerchantDetails()
        {
            DB = new nasthaEntities();
        }
        public bool Process(RootObject PlaceDetailResponse)
        {
            if (PlaceDetailResponse == null)
                return false;

            merchant tMerchant = (from m in DB.merchants where m.place_id == PlaceDetailResponse.result.place_id select m).ToList<merchant>().First();

            tMerchant.name = PlaceDetailResponse.result.name;
            
            string tAddress, tSubLocality, tCity, tPostalcode, tState, tCountry;
            DeformatAddress.Process(PlaceDetailResponse.result.formatted_address, out tAddress,
                                    out tSubLocality, out tCity, out tPostalcode, out tState, out tCountry);
            tMerchant.address = tAddress;
            tMerchant.sublocality = tSubLocality;
            tMerchant.city = tCity;
            tMerchant.zipcode = tPostalcode;
            tMerchant.state = tState;
            tMerchant.country = tCountry;

            tMerchant.advertiser = "N";
            tMerchant.amenities = null;
            tMerchant.bills = null;
            biz_hours tBizTime;
            List<biz_hours> tBizHourList = new List<biz_hours>();
            foreach ( Period tHours in PlaceDetailResponse.result.opening_hours.periods )
            {
                ParseBizHours(tHours, out tBizTime);
                tBizHourList.Add(tBizTime);
            }
            tMerchant.biz_hours = tBizHourList;

            tMerchant.latitude = float.Parse(  PlaceDetailResponse.result.geometry.location.lat.ToString());
            tMerchant.longitude = float.Parse(PlaceDetailResponse.result.geometry.location.lng.ToString());
            tMerchant.opt_out = "N";
            tMerchant.permanent_cell_phone_number = PlaceDetailResponse.result.formatted_phone_number;
            tMerchant.thumbnail_photo_url = PlaceDetailResponse.result.icon;
            tMerchant.website = PlaceDetailResponse.result.website;

            DB.merchants.Add(tMerchant);

            DB.SaveChanges();

            return true;

        }
        void ParseBizHours(Period Hours, out biz_hours tBizTime)
        {
            tBizTime = null;
            if (Hours.close.day != Hours.open.day)
                return;
            tBizTime = new biz_hours();
            tBizTime.day_of_week = Hours.open.day;
            tBizTime.start_time = Hours.open.time;
            tBizTime.end_time = Hours.close.time;

        }
    }
}