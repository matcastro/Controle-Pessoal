using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Personal.Control.Models.Requests;
using Personal.Control.Repositories.Contexts;
using Personal.Control.Utils.Configs;
using Personal.Control.Validators;

namespace Personal.Control.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public UsersController(IOptions<Config> options, ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        /// <summary>
        /// Retrive data from a registered user
        /// </summary>
        /// <param name="id">User id</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(string id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Register a user to use the system
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpPut]
        public IActionResult Register(UserRequest request)
        {
            request.Validate();
            return Ok();
        }

        /// <summary>
        /// Resets a user password
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpPost]
        [Route("password/reset")]
        public IActionResult ResetPassword()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Removes the user from the system
        /// </summary>
        /// <param name="id">User id</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(string id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Retrive user permissions
        /// </summary>
        /// <param name="id">User id</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpGet]
        [Route("{id}/permissions")]
        public IActionResult GetPermissions(string id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Update data of an user
        /// </summary>
        /// <param name="id">User id</param>
        /// <returns></returns>
        [HttpPost]
        [Route("{id}")]
        public IActionResult Update(string id)
        {
            return Ok(id);
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var emails = await this._dbContext.Users.Select(x => x.Email).ToListAsync();
            return Ok(emails);
        }
    }
}