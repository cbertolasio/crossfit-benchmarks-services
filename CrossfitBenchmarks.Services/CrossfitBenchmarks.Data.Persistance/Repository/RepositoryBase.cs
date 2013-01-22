using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossfitBenchmarks.Data.Persistance
{
    public class RepositoryBase<T> : IRepository<T>
        where T: class
    {
        protected DbContext context;
        protected DbSet<T> dbSet;

        public RepositoryBase(DbContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            this.context = context;
            this.dbSet = this.context.Set<T>();
        }

        public T Find(params object[] keyValues)
        {
            return dbSet.Find(keyValues);
        }

        public IEnumerable<T> GetAll()
        {
            return dbSet.ToList();
        }
    }
}

