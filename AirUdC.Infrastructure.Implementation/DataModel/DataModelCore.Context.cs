﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AirUdC.Infrastructure.Implementation.DataModel
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Core_DBEntities : DbContext
    {
        public Core_DBEntities()
            : base("name=Core_DBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Feedback> Feedback { get; set; }
        public virtual DbSet<MultimediaType> MultimediaType { get; set; }
        public virtual DbSet<Property> Property { get; set; }
        public virtual DbSet<PropertyMultimedia> PropertyMultimedia { get; set; }
        public virtual DbSet<PropertyOwner> PropertyOwner { get; set; }
        public virtual DbSet<Reservation> Reservation { get; set; }

        public System.Data.Entity.DbSet<AirUdC.GUI.Models.Parameters.PropertyOwnerModel> PropertyOwnerModels { get; set; }
    }
}
