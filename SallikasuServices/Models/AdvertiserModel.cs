using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Infrastructure;

namespace SallikasuServices.Models
{
    public class AdvertiserModel
    {
        nasthaEntities DB { get; set; }
        public AdvertiserModel()
        {
            DB = new nasthaEntities();
        }
        public List<merchant_advertisers> Get()
        {
            List<merchant_advertisers> tList = (from m in DB.merchants
                                                from ma in DB.merchant_advertisers
                                                where m.id == ma.merchant_id && m.advertiser == "Y"
                                                select ma).ToList();
            return tList;
        }
        public bool Create(merchant_advertisers tMerchant)
        {

            try
            {
                DB.merchant_advertisers.Add(tMerchant);
                DB.SaveChanges();
            }
            catch(DbUpdateException ex)
            {
                String Message = "Create MerchantAdvertisers: " + ex.Message + ex.InnerException != null ? " InnerException: " + ex.InnerException.Message : "";
                System.Console.WriteLine(Message);
                return false;
            }
            catch(System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                String Message = "Create MerchantAdvertisers: " + ex.Message + ex.InnerException != null ? " InnerException: " + ex.InnerException.Message : "";
                System.Console.WriteLine(Message);
                return false;
            }
            catch (Exception ex)
            {
                String Message = "Create MerchantAdvertisers: " + ex.Message + ex.InnerException != null ? " InnerException: " + ex.InnerException.Message : "";
                System.Console.WriteLine(Message);
                return false;
            }
            return true;
        }
        public bool Update( merchant_advertisers Advertiser)
        {
            try
            {
                DB.merchant_advertisers.Attach(Advertiser);
                DB.Entry(Advertiser).State = System.Data.Entity.EntityState.Modified;
                DB.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                String Message = "Create MerchantAdvertisers: " + ex.Message + ex.InnerException != null ? " InnerException: " + ex.InnerException.Message : "";
                System.Console.WriteLine(Message);
                return false;
            }
            catch (Exception ex)
            {
                String Message = "Create MerchantAdvertisers: " + ex.Message + ex.InnerException != null ? " InnerException: " + ex.InnerException.Message : "";
                System.Console.WriteLine(Message);
                return false;
            }
            return true;
        }
        public merchant_advertisers Get(int id)
        {
            merchant_advertisers tAdvt = (from m in DB.merchant_advertisers where m.id == id select m).SingleOrDefault();

            return tAdvt;
        }
        public merchant_advertisers GetByMerchantId(int id)
        {
            merchant_advertisers tAdvt = (from m in DB.merchant_advertisers where m.merchant_id == id select m).SingleOrDefault();
            return tAdvt;
        }
    }
}