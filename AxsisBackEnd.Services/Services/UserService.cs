using AxsisBackend.Persistence.Models;
using AxsisBackend.Persistence.Repositoriy;
using AxsisBackend.Persistence.Repositoriy.Interface;
using AxsisBackEnd.Services.Services.Interface;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AxsisBackEnd.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUsersRepository _repository;

        public UserService(IUsersRepository repository) 
        {
            _repository = repository;
        }
        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _repository.GetUsers().ConfigureAwait(false);
        }

        public async Task<User> GetUserById(long id)
        {
            return await _repository.GetUserById(id).ConfigureAwait(false);
        }

        public async Task Update(User user)
        {
            await _repository.Update(user).ConfigureAwait(false);
        }

        public async Task Create(User user)
        {
            PasswordHasher passwordHasher = new PasswordHasher();
            user.Password = passwordHasher.HashPassword(user.Password);

            await _repository.Create(user).ConfigureAwait(false);
        }

        public async Task<User> Delete(long id)
        {
            return await _repository.Delete(id).ConfigureAwait(false);
        }

        public async Task ChangeStatus(long id)
        {
            await _repository.ChangeStatus(id).ConfigureAwait(false);
        }

        public bool isValidLogin(string username, string password) 
        {
            User user = _repository.GetUserByName(username);
            if (user is not null)
            {
                PasswordHasher hash = new PasswordHasher();
                PasswordVerificationResult result = hash.VerifyHashedPassword(user.Password, password);
                if (result == PasswordVerificationResult.Success)
                {
                    return true;
                }
                else 
                {
                    return false;
                }                   
            }
            else 
            {
                return false;
            }
        }
    }
}
