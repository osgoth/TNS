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
        // base station statuses:
        // 0 - stopped
        // 1 - running

        // base station id to current capacity relation
        public Dictionary<int, int> baseStationCapacity = new Dictionary<int, int>();

        public ControllerService()
        {
            using (var dbContext = new TelecommunicationNetworkSimulatorContext())
            {
                for (int i = 0; i < dbContext.BaseStations.Count(); i++)
                {
                    baseStationCapacity.Add(i, 0);
                }
            }
        }
        public void RestartBaseStation(BaseStation baseStation)
        {
            using (var dbContext = new TelecommunicationNetworkSimulatorContext())
            {
                baseStation.BaseStationStatusId = 0;
                foreach (var user in dbContext.Users.Where(i => i.BaseStationId == baseStation.Id))
                {
                    user.UserStatusId = 0;

                }
            }
        }
    }
}
