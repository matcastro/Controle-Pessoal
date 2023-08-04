using Microsoft.AspNetCore.Mvc;

namespace Personal.Control.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        /// <summary>
        /// Login to start using the system
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpPost]
        [Route("login")]
        public IActionResult Login()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Used to refresh user session token
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpPost]
        [Route("token/refresh")]
        public IActionResult RefreshToken()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Used to revoke user token
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpPost]
        [Route("token/revoke")]
        public IActionResult RevokeToken()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Retrive the authentication status
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpPost]
        [Route("status")]
        public IActionResult Status()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Make a logout operation
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpPost]
        [Route("logout")]
        public IActionResult Logout()
        {
            throw new NotImplementedException();
        }
    }
}