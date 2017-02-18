//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace nastha.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class order
    {
        public int id { get; set; }
        public Nullable<int> user_id { get; set; }
        public Nullable<int> merchant_id { get; set; }
        public Nullable<int> token_number { get; set; }
        public Nullable<decimal> net_amount { get; set; }
        public Nullable<decimal> gross_amount { get; set; }
        public Nullable<decimal> alcohol_total { get; set; }
        public Nullable<decimal> cashback_percentage { get; set; }
        public Nullable<decimal> prorated_gross_amount { get; set; }
        public Nullable<decimal> prorated_alcohol_total { get; set; }
        public System.DateTime order_time { get; set; }
        public Nullable<decimal> referral_cost { get; set; }
        public Nullable<decimal> sor_gross_revenue { get; set; }
        public Nullable<decimal> sor_net_revenue { get; set; }
        public Nullable<decimal> user_commission { get; set; }
        public Nullable<decimal> cashback { get; set; }
        public Nullable<decimal> user_payment_to_merchant { get; set; }
        public System.DateTime created_at { get; set; }
        public System.DateTime updated_at { get; set; }
    
        public virtual merchant merchant { get; set; }
    }
}
