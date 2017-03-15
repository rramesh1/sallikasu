using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SallikasuServices.Models
{
    public class SearchRequestModel
    {
        nasthaEntities DB { get; set; }
        public SearchRequestModel()
        {
            DB = new nasthaEntities();
        }
        public List<merchant> Get(String State, String City, String Sublocality,String BusinessType, String products, String AlcoholServed , DateTime CurrentDateTime)
        {
            List<SearchRequestData> tList = (from m in DB.merchants
                                    where m.state == State && m.city == City
                                    && (Sublocality == null || m.sublocality == Sublocality)
                                    select new SearchRequestData(  m.address,
                                   m.advertiser,
                                   m.advertiser_exclusion_dates.ToList(),
                                   m.advertiser_staff_cell_phone_numbers.ToList(),
                                   m.amenities.ToList(),
                                   m.bills.ToList(),
                                   m.biz_hours.ToList(),
                                   m.black_listed,
                                   m.city,
                                   m.id,
                                   m.latitude,
                                   m.longitude,
                                   m.merchant_advertisers.ToList(),
                                   m.monthly_bills.ToList(),
                                   m.name,
                                   m.nastha_credits.ToList(),
                                   m.nastha_redemptions.ToList(),
                                   m.opt_out,
                                   m.orders.ToList(),
                                   m.permanent_cell_phone_number,
                                   m.phone,
                                   m.pictures.ToList(),
                                   m.place_id,
                                   m.products.ToList(),
                                   m.rating,
                                   m.referred_phone_number,
                                   m.registration_codes.ToList(),
                                   m.state,
                                   m.sublocality,
                                   m.thumbnail_photo_url,
                                   m.tokens.ToList(),
                                   m.tos_agreements.ToList(),
                                   m.type,
                                   m.website,
                                   m.zipcode)).ToList();
            DayOfWeek tDayOfWeek = CurrentDateTime.DayOfWeek;

            
            foreach( SearchRequestData tData in tList )
            {
                if ( tData.biz_hours != null && 
                    tData.biz_hours.Count > 0 )
                {
                    foreach(biz_hours tBiz in tData.biz_hours)
                    {
                        /*
                         * If[display_merchant_for = (Morning Only)] AND 
                         *      (curren time of user <= end_time) AND
                         *      (curren day of user = ""day"" column) AND 
                         *      (end_time != 99:99), 
                         *          THEN: biz_end_time = end_time.
                         *  ELSE: If[display_merchant_for = (Midday Only or Morning and Midday Only)] 
                         *              AND(current time of user <= end_time) 
                         *              AND(current day of user = ""day"" column)  
                         *              AND(end_time != 99:99), THEN: 
                         *                  biz_end_time = end_time.
                         *  ELSE: If[display_merchant_for = (Evening Only, Midday and Evening Only, Morning and Evening Only, or All Times)] 
                         *          AND(current time of user <= end_time) 
                         *          AND(current day of user = ""day"" column)  
                         *          AND(end_time != 99:99), THEN: 
                         *              biz_end_time = end_time.
*/
                        if (tBiz.day_of_week == (int)tDayOfWeek)
                        {
                            if (tBiz.display_merchant_for.Contains("Morning") &&
                                    CurrentDateTime.ToLongTimeString().CompareTo( tBiz.end_time) <= 0 &&
                                    tBiz.end_time != "99.99" )
                            {

                            }
                            else if ( tBiz.display_merchant_for.Contains("Midday") &&
                                    CurrentDateTime.ToLongTimeString().CompareTo(tBiz.end_time) <= 0 &&
                                    tBiz.end_time.CompareTo( "99.99" ) != 0 )
                            {

                            }
                            else if (tBiz.display_merchant_for.Contains("Evening") &&
                                    CurrentDateTime.ToLongTimeString().CompareTo(tBiz.end_time) <= 0 &&
                                    tBiz.end_time.CompareTo("99.99") != 0)
                            {

                            }
                        }
                    }
                }
            }


/*
 * Also, determine the biz_end_time based on the biz_hours table for the merchant_id AND 
 * the following rules so as to create immediacy for the user to drive to the merchant and send it to the App.
 * 
 * If the merchant_id were a Non - Sponsored Merchant, then send the following as the ""remaining_budget"" attribute.
 * a) Subtract the cumulative sum of ALL the budget_spent_on_merchant_conversions column values for the per_city_id value matching the ""id"" column of the per_city_marketing_budgets table, where the city and state values of the same per_city_marketing_budgets record match the city and state values of the merchant from the ""budget"" column of the per_city_marketing_budgets record.


2) products table, EXCEPT created_at and updated_at.Sort the products by ascending order before returning them in the response.

3) If the merchant_id were an advertiser with the status column = ""A""(i.e.Active), then send the following also.
merchant_advertisers table, date_merchant_became_advertiser, subscription_id, owner_name, owner_cell_phone_number, owner_email, commission_for_alcohol, lowest_balance_reached_date, created_at, and updated_at.

4) If the merchant_id were an advertiser with the status column = ""A""(i.e.Active), then send the following also.
a) commission_percentage from the subscriptions table based on the store's corresponding subscription_id in the merchant_advertisers record.
b) min_order_value from the merchant_advertisers record.
c) min_deposit_balance from the subscriptions table based on the store's corresponding subscription_id in the merchant_advertisers record.

5) If the merchant_id were an advertiser with the status column = ""A""(i.e.Active), then send the following also.
amenities table, EXCEPT created_at and updated_at."
*/

            return tList;

        }
    }
    public class SearchRequestData
    {
        public String address { get; set; }
        public String advertiser { get; set; }
        public List<advertiser_exclusion_dates> advertiser_exclusion_dates { get; set; }
        public List<advertiser_staff_cell_phone_numbers> advertiser_staff_cell_phone_numbers { get; set; }
        public List<amenity> amenities { get; set; }
        public List<bill> bills { get; set; }
        public List<biz_hours> biz_hours { get; set; }
        public String black_listed { get; set; }
        public String city { get; set; }
        public String country { get; set; }
        public String cumulative_referrals { get; set; }
        public int id { get; set; }
        public float latitude { get; set; }
        public float longitude { get; set; }
        public List<merchant_advertisers> merchant_advertisers { get; set; }
        public List<monthly_bills> monthly_bills { get; set; }
        public String name { get; set; }
        public List<nastha_credits> nastha_credits { get; set; }
        public List<nastha_redemptions> nastha_redemptions { get; set; }
        public String opt_out { get; set; }
        public List<order> orders { get; set; }
        public String permanent_cell_phone_number { get; set; }
        public String phone { get; set; }
        public List<picture> pictures { get; set; }
        public String place_id { get; set; }
        public List<product> products { get; set; }
        public decimal rating { get; set; }
        public String referred_phone_number { get; set; }
        public List<registration_codes> registration_codes { get; set; }
        public String state { get; set; }
        public String sublocality { get; set; }
        public String thumbnail_photo_url { get; set; }
        public List<token> tokens { get; set; }
        public List<tos_agreements> tos_agreements { get; set; }
        public String type { get; set; }
        public String website { get; set; }
        public String zipcode { get; set; }
        public SearchRequestData(String Address,
                                 String Advertiser,
                                 List<advertiser_exclusion_dates> Advertiser_exclusion_dates,
                                 List<advertiser_staff_cell_phone_numbers> Advertiser_staff_cell_phone_numbers,
                                 List<amenity> Amenities,
                                 List<bill> Bills,
                                 List<biz_hours> Biz_hours,
                                 String Black_listed,
                                 String City,
                                 int Id,
                                 float? Latitude,
                                 float? Longitude,
                                 List<merchant_advertisers>  Merchant_advertisers,
                                 List<monthly_bills>  Monthly_bills,
                                 String Name,
                                 List<nastha_credits> Nastha_credits,
                                 List<nastha_redemptions> Nastha_redemptions,
                                 String Opt_out,
                                 List<order> Orders,
                                 String Permanent_cell_phone_number,
                                 String Phone,
                                 List<picture> Pictures,
                                 String Place_id,
                                 List<product> Products,
                                 decimal? Rating,
                                 String Referred_phone_number,
                                 List<registration_codes> Registration_codes,
                                 String State,
                                 String Sublocality,
                                 String Thumbnail_photo_url,
                                 List<token> Tokens,
                                 List<tos_agreements> Tos_agreements, 
                                 String Type,
                                 String Website,
                                 String Zipcode)
        {
            address = Address;
            advertiser = Advertiser;
            advertiser_exclusion_dates = Advertiser_exclusion_dates;
            advertiser_staff_cell_phone_numbers = Advertiser_staff_cell_phone_numbers;
            amenities = Amenities;
            bills = Bills;
            biz_hours = Biz_hours;
            black_listed = Black_listed;
            city = City;
            id = Id;
            latitude = Latitude.HasValue ? Latitude.Value : 0;
            longitude = Longitude.HasValue ? Longitude.Value : 0;
            merchant_advertisers = Merchant_advertisers;
            monthly_bills = Monthly_bills;
            name = Name;
            nastha_credits = Nastha_credits;
            nastha_redemptions = Nastha_redemptions;
            opt_out = Opt_out;
            orders = Orders;
            permanent_cell_phone_number = Permanent_cell_phone_number;
            phone = Phone;
            pictures = Pictures;
            place_id = Place_id;
            products = Products;
            rating = Rating.HasValue ? Rating.Value : 0;
            referred_phone_number = Referred_phone_number;
            registration_codes = Registration_codes;
            state = State;
            sublocality = Sublocality;
            thumbnail_photo_url = Thumbnail_photo_url;
            tokens = Tokens;
            tos_agreements = Tos_agreements;
            type = type;
            website = Website;
            zipcode = Zipcode;
        }
    }
}