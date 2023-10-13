using Personal.Control.Repositories.Models;
using Personal.Control.Utils.Exceptions;

namespace Personal.Control.Repositories.Repositories.Interfaces
{
    public interface IUserRepository
    {
        /// <summary>
        /// Saves an user in the database
        /// </summary>
        /// <param name="user">User to be saved</param>
        /// <returns>A task with the execution of the saving process</returns>
        /// <exception cref="DuplicatedEntityException">User already registered</exception>
        public Task SaveAsync(User user);
    }
}
