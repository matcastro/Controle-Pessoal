using System.ComponentModel.DataAnnotations;

namespace Personal.Control.Repositories.Models
{
    public class User
    {
        /// <summary>
        /// Identifier of a user
        /// </summary>
        [Key]
        public string Id { get; set; }

        /// <summary>
        /// User email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// User password. Containing salt++password
        /// </summary>
        public string Password { get; set; }

        private User(string id)
        {
            Id = id;
            Email = null!;
            Password = null!;
        }

        public User(string id, string email, string password)
        {
            Id = id;
            Email = email;
            Password = password;
        }

        internal static User CreateDeletableUser(string id)
        {
            return new User(id);
        }
    }
}
