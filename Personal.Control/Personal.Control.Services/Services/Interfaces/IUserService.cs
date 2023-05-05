using Personal.Control.Services.Models;

namespace Personal.Control.Services.Services.Interfaces
{
    public interface IUserService
    {
        public Task<User> Register(User user);
    }
}
