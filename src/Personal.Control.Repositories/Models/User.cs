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

        public User(string id, string email, string password)
        {
            Id = id;
            Email = email;
            Password = password;
        }
    }
}
