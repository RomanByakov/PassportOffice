﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BusinessLayer
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PassportContext : DbContext
    {
        public PassportContext()
            : base("name=PassportContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<PassportData> PassportDatas { get; set; }
        public DbSet<UserAuthorization> UserAuthorizations { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Sex> Sexes { get; set; }
        public DbSet<Passport> Passports { get; set; }
    }
}
