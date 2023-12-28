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
        public Task<User> RegisterAsync(User user);

        /// <summary>
        /// Method to retrieve user information
        /// </summary>
        /// <param name="id">The user identifier to be used to locate the user</param>
        /// <returns>A task with the retrieved user</returns>
        public Task<User> GetAsync(string id);
        
        /// <summary>
        /// Update user data
        /// </summary>
        /// <param name="user">User entity with fields to be updated. Fields null or empty won't be updated</param>
        /// <returns>A task with the updated user</returns>
        public Task<User> UpdateAsync(User user);
    }
}
