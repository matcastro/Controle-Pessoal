namespace Personal.Control.Models.Requests
{
    public class UserRequest
    {
        private string _email = string.Empty;
        
        /// <summary>
        /// Email of the user. Must be in a correct email format.
        /// </summary>
        public string Email
        {
            get
            {
                return this._email;
            }
            set
            {
                this._email = value.Trim();
            }
        }

        /// <summary>
        /// User password. Must pass all constraints and be encrypted for general uses.
        /// </summary>
        public string Password { get; set; } = string.Empty;
    }
}
