using System.ComponentModel.DataAnnotations;

namespace Personal.Control.Repositories.Models
{
    public class User
    {
        [Key]
        public string Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public User(string id, string email, string password)
        {
            Id = id;
            Email = email;
            Password = password;
        }
    }
}
