using AxsisBackend.Persistence.Models;
using AxsisBackEnd.Services.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AxsisBackEnd.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _service;

        public UsersController(IUserService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("login")]
        public async Task<dynamic> Login(User user)
        {
            return  new { status = _service.isValidLogin(user.UserName, user.Password) };
        }

        [HttpGet]
        [Route("get-all")]
        public async Task<IEnumerable<User>> GetAll()
        {
            return await _service.GetUsers().ConfigureAwait(false);
        }

        [HttpGet("{id}")]
        public async Task<User> GetById(long id)
        {
            return await _service.GetUserById(id).ConfigureAwait(false);
        }

        // POST: UsersController/Create
        [HttpPost]
        public async Task Create(User user)
        {
            try
            {
                await _service.Create(user).ConfigureAwait(false);
            }
            catch
            {
                throw new ArgumentException("Fallo creación de usuario");
            }
        }

        // POST: UsersController/Create
        [HttpPut]
        [Route("update")]
        public async Task Update(User user)
        {
            try
            {
                await _service.Update(user).ConfigureAwait(false);
            }
            catch
            {
                throw new ArgumentException("Fallo creación de usuario");
            }
        }

        [HttpDelete]
        [Route("delete")]
        public async Task Delete(long id)
        {
            try
            {
                await _service.Delete(id).ConfigureAwait(false);
            }
            catch
            {
                throw new ArgumentException("Fallo eliminacion de usuario");
            }
        }

        // POST: UsersController/Create
        [HttpPut]
        [Route("change-status")]
        public async Task ChangeStatus(long id)
        {
            try
            {
                await _service.ChangeStatus(id).ConfigureAwait(false);
            }
            catch
            {
                throw new ArgumentException("Fallo creación de usuario");
            }
        }

    }
}
