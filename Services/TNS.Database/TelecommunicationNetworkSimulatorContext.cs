using System;
using System.Collections.Generic;
using System.Data.Entity;
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

    }
}


