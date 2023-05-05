using Microsoft.EntityFrameworkCore;
using Personal.Control.Repositories.Contexts;
using Personal.Control.Repositories.Models;
using Personal.Control.Repositories.Repositories.Interfaces;
using Personal.Control.Repositories.Utils;
using Personal.Control.Utils.Exceptions;
using Personal.Control.Utils.Messages;

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
            context.Users.AddIfNotExists(user, out var success, u => u.Email == user.Email);
            if (!success)
                throw new DuplicatedEntityException(RepositoryMessages.UserAlreadyExists, user.Email);
            await context.SaveChangesAsync();
        }
    }
}
