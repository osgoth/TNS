using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNS.Domain
{
    public interface IUserRepository
    {
        Task<List<User>> GetUsers();

        Task<User> GetUserByIdAsync(int id);

    }
}
