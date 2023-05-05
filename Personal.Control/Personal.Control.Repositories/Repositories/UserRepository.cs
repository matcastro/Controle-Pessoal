using Microsoft.EntityFrameworkCore;
using Personal.Control.Repositories.Contexts;
using Personal.Control.Repositories.Models;
using Personal.Control.Repositories.Repositories.Interfaces;

namespace Personal.Control.Repositories.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory;

        public UserRepository(IDbContextFactory<ApplicationDbContext> dbContextFactory) {
            this._dbContextFactory = dbContextFactory;
        }

        public async Task Save(User user)
        {
            using var context = await _dbContextFactory.CreateDbContextAsync();
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
        }
    }
}
