﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SallikasuServices
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class nasthaEntities : DbContext
    {
        public nasthaEntities()
            : base("name=nasthaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<advertiser_exclusion_dates> advertiser_exclusion_dates { get; set; }
        public virtual DbSet<advertiser_staff_cell_phone_numbers> advertiser_staff_cell_phone_numbers { get; set; }
        public virtual DbSet<amenity> amenities { get; set; }
        public virtual DbSet<amenity_types> amenity_types { get; set; }
        public virtual DbSet<bill> bills { get; set; }
        public virtual DbSet<biz_hours> biz_hours { get; set; }
        public virtual DbSet<biz_types> biz_types { get; set; }
        public virtual DbSet<city_marketing_budget> city_marketing_budget { get; set; }
        public virtual DbSet<marketing_budget_spends> marketing_budget_spends { get; set; }
        public virtual DbSet<merchant> merchants { get; set; }
        public virtual DbSet<merchant_advertisers> merchant_advertisers { get; set; }
        public virtual DbSet<monthly_bills> monthly_bills { get; set; }
        public virtual DbSet<nastha_credits> nastha_credits { get; set; }
        public virtual DbSet<nastha_redemptions> nastha_redemptions { get; set; }
        public virtual DbSet<order> orders { get; set; }
        public virtual DbSet<picture> pictures { get; set; }
        public virtual DbSet<product> products { get; set; }
        public virtual DbSet<product_types> product_types { get; set; }
        public virtual DbSet<referred_users> referred_users { get; set; }
        public virtual DbSet<registration_codes> registration_codes { get; set; }
        public virtual DbSet<subscription> subscriptions { get; set; }
        public virtual DbSet<system_configs> system_configs { get; set; }
        public virtual DbSet<token> tokens { get; set; }
        public virtual DbSet<tos_agreements> tos_agreements { get; set; }
        public virtual DbSet<user_merchant_referrals> user_merchant_referrals { get; set; }
        public virtual DbSet<user_types> user_types { get; set; }
        public virtual DbSet<user> users { get; set; }
        public virtual DbSet<advertiser_deposit> advertiser_deposit { get; set; }
    }
}
