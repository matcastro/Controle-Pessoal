using Personal.Control.Services.Models;
using Personal.Control.Utils.Exceptions;

namespace Personal.Control.Services.Services.Interfaces
{
    public interface IUserService
    {
        /// <summary>
        /// Method responsible to orquestrate an user registration
        /// </summary>
        /// <param name="user">An user to be registered</param>
        /// <returns>A task with the same user with its id</returns>
        /// <exception cref="DuplicatedEntityException">Shows that an user has already been registered in the database</exception>
        public Task<User> Register(User user);
    }
}
