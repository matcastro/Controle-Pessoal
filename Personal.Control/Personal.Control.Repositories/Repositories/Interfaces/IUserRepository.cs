using Personal.Control.Repositories.Models;

namespace Personal.Control.Repositories.Repositories.Interfaces
{
    public interface IUserRepository
    {
        public Task Save(User user);
    }
}
