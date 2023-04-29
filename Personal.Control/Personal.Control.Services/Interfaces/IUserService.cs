namespace Personal.Control.Services.Interfaces
{
    public interface IUserService
    {
        public Task Register(string username, string password);
    }
}
