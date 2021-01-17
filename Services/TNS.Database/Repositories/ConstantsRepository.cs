using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNS.Database.Base;
using TNS.Domain;

namespace TNS.Database
{
    public class ConstantsRepository : IConstantsRepository
    {
        //TODO: for DI
        private readonly TelecommunicationNetworkSimulatorContext _context;

        public IUnitOfWork UnitOfWork => _context;

        //TODO: for DI
        public ConstantsRepository(TelecommunicationNetworkSimulatorContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        //TODO: remove after DI install
        public ConstantsRepository()
        {
            _context = new TelecommunicationNetworkSimulatorContext();
        }

        public async Task<Constants> GetConstants()
        {
            return await _context.Constants.FirstOrDefaultAsync();
        }
    }
}
