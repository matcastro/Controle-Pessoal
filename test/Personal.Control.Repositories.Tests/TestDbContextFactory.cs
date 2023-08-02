using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Personal.Control.Repositories.Contexts;

namespace Personal.Control.Repositories.Tests
{
    public class TestDbContextFactory : IDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseInMemoryDatabase("test");

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
