using Kralizek.EntityFramework;

// ReSharper disable once CheckNamespace
namespace System.Data.Entity
{
    public static class DbSetExtensions
    {
        public static IAsyncDbSet<T> ToAsyncDbSet<T>(this DbSet<T> dbSet) where T : class
        {
            if (dbSet == null)
            {
                throw new ArgumentNullException(nameof(dbSet));
            }

            return new DbSetAdapter<T>(dbSet);
        }
    }
}