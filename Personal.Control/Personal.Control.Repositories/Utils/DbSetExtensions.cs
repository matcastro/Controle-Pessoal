using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace Personal.Control.Repositories.Utils
{
    public static class DbSetExtensions
    {
        public static EntityEntry<T>? AddIfNotExists<T>(
            this DbSet<T> dbSet, 
            T entity,
            out bool success,
            Expression<Func<T, bool>>? predicate = null) where T : class
        {
            success = true;

            var exists = predicate != null && dbSet.Any(predicate);
            if (exists)
            {
                success = false;
                return null;
            }
            return dbSet.Add(entity);
        }
    }
}
