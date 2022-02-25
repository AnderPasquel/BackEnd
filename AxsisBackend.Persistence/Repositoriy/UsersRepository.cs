using AxsisBackend.Persistence.Models;
using AxsisBackend.Persistence.Repositoriy.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AxsisBackend.Persistence.Repositoriy
{
    public class UsersRepository : IUsersRepository
    {
        private readonly AplicationDbContext _context;

        public UsersRepository(AplicationDbContext context) 
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetUsers() 
        {
            return await _context.User.ToListAsync();
        }

        public async Task<User> GetUserById(long id) 
        {
            return await _context.User.FindAsync(id);
        }

        public async Task Update(User user) 
        {
            _context.Entry(user).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException) 
            {
                if (!UserExists(user.Id))
                {
                    throw new ArgumentException("El Usuario no existe");
                }
                else 
                {
                    throw;
                }
            }
        }

        public async Task Create(User user) 
        {
            _context.User.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User> Delete(long id) 
        {

            var user = await _context.User.FindAsync(id);
            if (user is null) 
            {
                throw new ArgumentException("El Usuario no existe");
            }
            _context.User.Remove(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task ChangeStatus(long id)
        {

            var user = await _context.User.FindAsync(id);
            user.Status = !user.Status;

            _context.Entry(user).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(user.Id))
                {
                    throw new ArgumentException("El Usuario no existe");
                }
                else
                {
                    throw;
                }
            }
        }

        public User GetUserByName(string username)
        {
            return _context.User.Where(obj => obj.UserName == username).Select(obj => obj).FirstOrDefault();
        }

        private bool UserExists(long id) 
        {
            return _context.User.Any(obj => obj.Id == id);
        }
    }
}
