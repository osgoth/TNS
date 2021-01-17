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
    public class UserRepository : IUserRepository
    {
        //TODO: for DI
        private readonly TelecommunicationNetworkSimulatorContext _context;

        public IUnitOfWork UnitOfWork => _context;

        //TODO: for DI
        public UserRepository(TelecommunicationNetworkSimulatorContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        //TODO: remove after DI install
        public UserRepository()
        {
            _context = new TelecommunicationNetworkSimulatorContext();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(_ => _.Id == id);
        }

        public async Task<List<User>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }
    }
}
