﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Mdia.Entity
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MdiaEntities : DbContext
    {
        public MdiaEntities()
            : base("name=MdiaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CONTENT> CONTENT { get; set; }
        public virtual DbSet<CONTENT_TYPE> CONTENT_TYPE { get; set; }
        public virtual DbSet<DOWNLOAD> DOWNLOAD { get; set; }
        public virtual DbSet<PAYMENT> PAYMENT { get; set; }
        public virtual DbSet<PAYMENT_CHANNEL> PAYMENT_CHANNEL { get; set; }
        public virtual DbSet<PAYMENT_INTERSWITCH> PAYMENT_INTERSWITCH { get; set; }
        public virtual DbSet<PAYMENT_MODE> PAYMENT_MODE { get; set; }
        public virtual DbSet<RIGHT> RIGHT { get; set; }
        public virtual DbSet<ROLE> ROLE { get; set; }
        public virtual DbSet<ROLE_RIGHT> ROLE_RIGHT { get; set; }
        public virtual DbSet<USER> USER { get; set; }
    }
}