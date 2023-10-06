namespace Personal.Control.Services.Models
{
    public class User
    {
        /// <summary>
        /// Identifier of the user. Guid generated value.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// User email.
        /// </summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// User password, already encrypted.
        /// </summary>
        public string Password { get; set; } = string.Empty;
        public byte[] PasswordSalt { get; set; } = Array.Empty<byte>();

        public User()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
