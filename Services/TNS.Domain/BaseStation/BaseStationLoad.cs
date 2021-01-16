using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNS.Domain
{
    public class BaseStationLoad
    {
        public int Id { get; set; }
        public int BaseStationId { get; set; }
        public DateTime TimeSaved { get; set; }
        public int CurrentLoad { get; set; }
        public int LoadMax { get; set; }
        public int LoadAverage { get; set; }
        public int InQueueMax { get; set; }
        public int InQueueAverage { get; set; }

        public BaseStation BaseStation { get; set; }
    }
}
