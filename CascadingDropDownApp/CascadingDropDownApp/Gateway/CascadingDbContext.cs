﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using CascadingDropDownApp.Models;

namespace CascadingDropDownApp.Gateway
{
    public class CascadingDbContext:DbContext
    {
        public CascadingDbContext():base("DefaultConnection")
        {
            
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Division> Divisions { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Upazila> Upazilas { get; set; }
        public DbSet<UnionParishad> UnionParishads { get; set; }
        public DbSet<BookingTicket> BookingTickets { get; set; }
        public DbSet<CustomerModels> Customers { get; set; }
        public DbSet<CustomerAddressModels> CustomerAddresses { get; set; }
        public DbSet<DepartmentModels> Departments { get; set; }

        public DbSet<TicketTypeModels> TicketTypes { get; set; }
        public DbSet<CategoryModels> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }
    }
}