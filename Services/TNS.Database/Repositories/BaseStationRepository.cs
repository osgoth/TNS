using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNS.Database.Base;
using TNS.Domain;

namespace TNS.Database.Repositories
{
    public class BaseStationRepository : IBaseStationRepository
    {
        //TODO: for DI
        private readonly TelecommunicationNetworkSimulatorContext _context;

        public IUnitOfWork UnitOfWork => _context;

        //TODO: for DI
        public BaseStationRepository(TelecommunicationNetworkSimulatorContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        //TODO: remove after DI install
        public BaseStationRepository()
        {
            _context = new TelecommunicationNetworkSimulatorContext();
        }

        public async Task<BaseStation> GetBaseStationByIdAsync(int id)
        {
            return await _context.BaseStations.FirstOrDefaultAsync(_ => _.Id == id);
        }

        public async Task<List<BaseStation>> GetBaseStations()
        {
            return await _context.BaseStations.ToListAsync();
        }
    }
}
