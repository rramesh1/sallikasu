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
    
    public partial class user
    {
        public int id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public Nullable<int> user_type_id { get; set; }
        public Nullable<int> merchant_id { get; set; }
        public System.DateTime user_deactivated_at { get; set; }
        public string encrypted_password { get; set; }
        public string reset_password_token { get; set; }
        public System.DateTime reset_password_token_sent_at { get; set; }
        public System.DateTime remember_created_at { get; set; }
        public Nullable<int> sign_in_count { get; set; }
        public System.DateTime current_sign_in_at { get; set; }
        public System.DateTime last_sign_in_at { get; set; }
        public string current_sign_ip { get; set; }
        public string last_sign_in_ip { get; set; }
        public string confirmation_token { get; set; }
        public System.DateTime confirmed_at { get; set; }
        public System.DateTime confirmation_sent_at { get; set; }
        public Nullable<int> failed_attempts { get; set; }
        public string unlock_token { get; set; }
        public System.DateTime locked_at { get; set; }
        public System.DateTime created_at { get; set; }
        public System.DateTime updated_at { get; set; }
    }
}
