using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNS.Domain
{
    public class BaseStation
    {
        public int Id { get; set; }
        public int Capacity { get; set; }
        public int BaseStationStatusId { get; set; }
    }
}
