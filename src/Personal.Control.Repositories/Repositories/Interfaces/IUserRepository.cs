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

        /// <summary>
        /// Gets an user from the database
        /// </summary>
        /// <param name="id">User identifier</param>
        /// <returns>A task with the retrived user</returns>
        /// <exception cref="EntityNotFoundException">Thrown when user does not exists</exception>
        public Task<User> GetAsync(string id);

        /// <summary>
        /// Updates user data into the database
        /// </summary>
        /// <param name="user">User filled with desired data to be updated. Null/empty fields won't be considered.</param>
        /// <returns></returns>
        public Task<User> UpdateAsync(User user);

        /// <summary>
        /// Deletes user data from database
        /// </summary>
        /// <param name="id">Id of the user to be deleted</param>
        /// <returns></returns>
        public Task DeleteAsync(string id);
    }
}
