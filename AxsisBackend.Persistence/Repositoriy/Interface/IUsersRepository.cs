using AxsisBackend.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AxsisBackend.Persistence.Repositoriy.Interface
{
    public interface IUsersRepository
    {
        Task<IEnumerable<User>> GetUsers();

        Task<User> GetUserById(long id);

        Task Update(User user);

        Task Create(User user);

        Task<User> Delete(long id);

        Task ChangeStatus(long id);

        User GetUserByName(string username);

    }
}
