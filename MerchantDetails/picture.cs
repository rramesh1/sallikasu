//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MerchantDetails
{
    using System;
    using System.Collections.Generic;
    
    public partial class picture
    {
        public int id { get; set; }
        public Nullable<int> merchant_id { get; set; }
        public string interior_photo_url { get; set; }
        public System.DateTime created_at { get; set; }
        public System.DateTime updated_at { get; set; }
    
        public virtual merchant merchant { get; set; }
    }
}
