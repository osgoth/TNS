using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TNS.Database.Base;
using TNS.Domain;

namespace TNS.Database
{
    public class TelecommunicationNetworkSimulatorContext : DbContext, IUnitOfWork
    {

        public TelecommunicationNetworkSimulatorContext() : base(@"Data Source=.\SQLEXPRESS;Initial Catalog=TNS;Integrated Security=True;MultipleActiveResultSets=true")
        { }

        public DbSet<BaseStation> BaseStations { get; set; }
        public DbSet<BaseStationLoad> BaseStationLoads { get; set; }
        public DbSet<SubscriptionType> SubscriptionTypes { get; set; }
        public DbSet<Constants> Constants { get; set; }
        public DbSet<User> Users { get; set; }




        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            try
            {
                await this.SaveChangesAsync(cancellationToken);
            }
            catch (DbEntityValidationException e)
            {
                //need to Handle with some logger
            }
            catch (OptimisticConcurrencyException e)
            {
                //need to Handle with some logger
            }
            catch (DbUpdateConcurrencyException e)
            {
                //need to Handle with some logger
            }
            catch (Exception e)
            {
                //need to Handle with some logger
            }

            return true;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // turn off pluralization
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

        }


    }
}


