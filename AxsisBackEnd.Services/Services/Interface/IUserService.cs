using AxsisBackend.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AxsisBackEnd.Services.Services.Interface
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUsers();

        Task<User> GetUserById(long id);

        Task Update(User user);

        Task Create(User user);

        Task<User> Delete(long id);

        Task ChangeStatus(long id);

        bool isValidLogin(string username, string password);

    }
}
