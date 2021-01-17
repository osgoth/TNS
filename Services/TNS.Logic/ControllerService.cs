using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNS.Domain;
using TNS.Database;

namespace TNS.Logic
{
    public class ControllerService
    {
        // base station id to current capacity relation
        public Dictionary<int, int> baseStationCapacity = new Dictionary<int, int>();

        public ControllerService()
        {
            var baseStations = new TelecommunicationNetworkSimulatorContext().BaseStations.ToList();

            foreach (var bs in baseStations)
            {
                baseStationCapacity.Add(bs.Id, 0);
            }
        }

    }
}
