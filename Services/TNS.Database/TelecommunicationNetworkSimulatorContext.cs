using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNS.Database
{
    public class TelecommunicationNetworkSimulatorContext : DbContext
    {
        public TelecommunicationNetworkSimulatorContext() : base("DefaultConnection")
        {
            //public DbSet<Student> Students { get; set; }


    }
    }
}
