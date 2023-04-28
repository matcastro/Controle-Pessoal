using System.ComponentModel.DataAnnotations;

namespace Personal.Control.Repositories.Models
{
    public class User
    {
        [Key]
        public string Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public User(string email, string password)
        {
            Id = Guid.NewGuid().ToString();
            Email = email;
            Password = password;
        }
    }
}
