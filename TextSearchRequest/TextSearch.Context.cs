﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TextSearchRequest
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;


    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]

    public partial class TextSearch : DbContext
    {
        public TextSearch()
            : base("name=TextSearch")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<merchant> merchants { get; set; }
        public virtual DbSet<picture> pictures { get; set; }
    }
}
