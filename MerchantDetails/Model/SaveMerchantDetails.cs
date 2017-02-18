using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Validation;
using System.Data.Entity.Infrastructure;

namespace MerchantDetails
{
    public class SaveMerchantDetails
    {
        private nasthaEntities m_DB;
        public nasthaEntities DB  { get { return m_DB; } }

        public SaveMerchantDetails()
        {
            m_DB = new nasthaEntities();
        }
        public void ProcessMerchantDetail(RootObject tSearch)
        {
            merchant tMerchant = (from m in m_DB.merchants where (m.place_id == tSearch.result.place_id) select m).SingleOrDefault<merchant>();
            if ( tMerchant != null)
            {
                String tAddress, tSubDivision, tCity, tZip, tState, tCountry;
                DeformatAddress.Process(tSearch.result.formatted_address, out tAddress, out tSubDivision, out tCity, out tZip, out tState, out tCountry);
                tMerchant.address = tAddress;
                tMerchant.sublocality = tSubDivision;
                tMerchant.city = tCity;
                tMerchant.state = tState;
                tMerchant.zipcode = tZip;
                foreach (AddressComponent taddr in tSearch.result.address_components)
                {
                    if ( tState.Trim().ToUpper() == taddr.long_name.Trim().ToUpper())
                        tMerchant.state = taddr.short_name;
                    if ( tCountry.Trim().ToUpper() == taddr.long_name.Trim().ToUpper())
                        tMerchant.country = taddr.short_name;
                }
                tMerchant.phone = tSearch.result.international_phone_number;
                tMerchant.latitude = tSearch.result.geometry.location.lat;
                tMerchant.longitude = tSearch.result.geometry.location.lng;
                if ( tSearch.result.opening_hours != null)
                    processBizHours(tSearch.result.opening_hours.periods,  ref tMerchant);
                tMerchant.updated_at = DateTime.Now;
                DB.merchants.Attach(tMerchant);
                DB.Entry(tMerchant).State = System.Data.Entity.EntityState.Modified;
                try
                {
                    DB.SaveChanges();
                }
                
                catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }
                    throw;
                }
                catch (DbUpdateException ex)
                {
                    Console.WriteLine(" Update Exception:" + ex.Message);
                    throw;
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Exception : " + ex.Message);
                    throw;
                }
            }
        }
       
       
        private bool processBizHours( List<Period> tTime, ref merchant Merchant)
        {
            Merchant.biz_hours = new List<biz_hours>();
            foreach (Period tPeriod in tTime)
            {
                biz_hours tHours = new biz_hours();
                tHours.day_of_week = tPeriod.open.day;
                tHours.start_time = tPeriod.open.time;
                tHours.end_time = tPeriod.close.time;
                tHours.merchant_id = Merchant.id;
                Merchant.biz_hours.Add(tHours);
            }
            return true;
        }
        public void UpdateMerchant(merchant Merchant)
        {
            List<merchant> tMerchantList = (from m in m_DB.merchants where (m.id == Merchant.id) select m ).ToList<merchant>();

            if ( tMerchantList.Count == 1)
            {
                merchant tMerchnant  = tMerchantList.First<merchant>();
                tMerchnant = Merchant;
                m_DB.SaveChanges();
            }
        }
    }
}