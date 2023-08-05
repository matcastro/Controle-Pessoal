using AutoFixture;
using Personal.Control.Repositories.Models;
using Personal.Control.Repositories.Utils;
using System.Linq.Expressions;
using Xunit;

namespace Personal.Control.Repositories.Tests.Utils
{
    public class DbSetExtensionsTests
    {
        private readonly Fixture _fixture;
        private readonly TestDbContextFactory _dbContextFactory;
        public DbSetExtensionsTests()
        {
            _fixture = new Fixture();
            _dbContextFactory = new TestDbContextFactory();
        }

        [Fact]
        public void AddIfNotExists_WhenPredicateIsNull_ShouldAdd()
        {
            var user = _fixture.Create<User>();
            using var context = _dbContextFactory.CreateDbContext();
            context.Users.AddIfNotExists(user, out var success, null);
            context.SaveChanges();
            context.Users.AddIfNotExists(user, out success, null);

            Assert.True(success);
        }

        [Fact]
        public void AddIfNotExists_WhenPredicateMatches_ShouldNotAdd()
        {
            var user = _fixture.Create<User>();
            using var context = _dbContextFactory.CreateDbContext();

            Expression<Func<User, bool>> predicate = u => u.Id == user.Id;
            context.Users.AddIfNotExists(user, out var success, predicate);
            context.SaveChanges();
            context.Users.AddIfNotExists(user, out success, predicate);

            Assert.False(success);
        }
    }
}
