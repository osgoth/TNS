using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNS.Domain
{
    public interface IBaseStationRepository
    {
        Task<List<BaseStation>> GetBaseStations();

        Task<BaseStation> GetBaseStationByIdAsync(int id);
    }
}