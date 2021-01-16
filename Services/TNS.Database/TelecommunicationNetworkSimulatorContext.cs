﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNS.Domain;

namespace TNS.Database
{
    public class TelecommunicationNetworkSimulatorContext : DbContext
    {
        public TelecommunicationNetworkSimulatorContext() : base("DefaultConnection")
        { }
        public DbSet<BaseStation> BaseStations { get; set; }
        public DbSet<BaseStationLoad> BaseStationLoads { get; set; }
        public DbSet<SubscriptionType> SubscriptionTypes { get; set; }
        public DbSet<Constants> Constants { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // turn off pluralization
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

        }

    }
}


