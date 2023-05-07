using Personal.Control.Utils.Criptography;

namespace Personal.Control.Services.Models
{
    public class User
    {
        public string Id { get; set; }
        public string Email { get; set; } = string.Empty;

        private string _password = string.Empty;
        public string Password 
        {
            get
            {
                return _password;
            } 
            set
            {
                _password = PasswordEncryptor.Encrypt(value, PasswordSalt);
            }
        }
        public byte[] PasswordSalt { get; set; } = Array.Empty<byte>();

        public User() 
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
