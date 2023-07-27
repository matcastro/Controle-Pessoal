using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace Personal.Control.Repositories.Utils
{
    public static class DbSetExtensions
    {
        /// <summary>
        /// Validator of existance in database
        /// </summary>
        /// <typeparam name="T">Type of the entity to be checked</typeparam>
        /// <param name="dbSet">DbSet of the type to be checked</param>
        /// <param name="entity">Entity to enter the dbSet</param>
        /// <param name="success">Flag show insertion success</param>
        /// <param name="predicate">Comparer function to check entity existence</param>
        /// <returns></returns>
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
