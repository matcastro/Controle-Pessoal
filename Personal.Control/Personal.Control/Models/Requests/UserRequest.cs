namespace Personal.Control.Models.Requests
{
    public class UserRequest
    {
        private string _email = string.Empty;
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value.Trim();
            }
        }
        public string Password { get; set; } = string.Empty;
    }
}
