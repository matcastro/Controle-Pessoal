using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Personal.Control.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
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
        public IActionResult Register()
        {
            throw new NotImplementedException();
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
    }
}