using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Kralizek.EntityFramework
{
    public sealed class DbSetAdapter<T> : IAsyncDbSet<T>
        where T : class
    {
        private readonly DbSet<T> _innerDbSet;

        public DbSetAdapter(DbSet<T> dbSet)
        {
            if (dbSet == null)
            {
                throw new ArgumentNullException(nameof(dbSet));
            }

            _innerDbSet = dbSet;
        }

        public T Add(T entity) => _innerDbSet.Add(entity);

        public T Attach(T entity) => _innerDbSet.Attach(entity);

        public T Create() => _innerDbSet.Create();

        TDerivedEntity IDbSet<T>.Create<TDerivedEntity>() => _innerDbSet.Create<TDerivedEntity>();

        public T Find(params object[] keyValues) => _innerDbSet.Find(keyValues);

        public Task<T> FindAsync(params object[] keyValues) => _innerDbSet.FindAsync(keyValues);

        public T Remove(T entity) => _innerDbSet.Remove(entity);

        public IEnumerator<T> GetEnumerator() => ((IEnumerable<T>)_innerDbSet).GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable<T>)_innerDbSet).GetEnumerator();

        public Type ElementType => ((IQueryable<T>)_innerDbSet).ElementType;

        public Expression Expression => ((IQueryable<T>)_innerDbSet).Expression;

        public ObservableCollection<T> Local => _innerDbSet.Local;

        public IQueryProvider Provider => ((IQueryable<T>)_innerDbSet).Provider;

        public IDbSet<T> Inner => _innerDbSet;
    }

}