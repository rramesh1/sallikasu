//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class marketing_budget_spends
    {
        public int id { get; set; }
        public Nullable<int> per_city_id { get; set; }
        public string zipcode { get; set; }
        public Nullable<decimal> spent_on_conversions { get; set; }
        public System.DateTime created_at { get; set; }
        public System.DateTime updated_at { get; set; }
    }
}
