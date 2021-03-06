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
    
    public partial class merchant_advertisers
    {
        public int id { get; set; }
        public int merchant_id { get; set; }
        public string status { get; set; }
        public Nullable<System.DateTime> date_merchant_became_advertiser { get; set; }
        public Nullable<int> subscription_id { get; set; }
        public Nullable<System.DateTime> subscription_last_date_change { get; set; }
        public string info_text { get; set; }
        public Nullable<decimal> deposit_balance { get; set; }
        public Nullable<decimal> cashback_percentage { get; set; }
        public Nullable<System.DateTime> lowest_balance_reached_date { get; set; }
        public string owner_name { get; set; }
        public string owner_cell_phone_number { get; set; }
        public string owner_email { get; set; }
        public string manager_name { get; set; }
        public string manager_cell_phone_number { get; set; }
        public string manager_email { get; set; }
        public Nullable<decimal> min_order_value { get; set; }
        public string commission_for_alcohol { get; set; }
        public System.DateTime created_at { get; set; }
        public System.DateTime updated_at { get; set; }
    
        public virtual merchant merchant { get; set; }
    }
}
