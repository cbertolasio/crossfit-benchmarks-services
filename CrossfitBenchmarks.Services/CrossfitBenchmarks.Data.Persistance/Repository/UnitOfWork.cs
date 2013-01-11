using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossfitBenchmarks.Data.Persistance
{
    public interface IUnitOfWork
    {
        void Commit();
    }

    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();

        T Find(params object[] keyValues);
    }

    public interface IWorkoutTypesRepository : IRepository<WorkoutType>
    {
    }

    public class WorkoutTypesRepository : RepositoryBase<WorkoutType>, IWorkoutTypesRepository
    {
        public  WorkoutTypesRepository(DbContext context)
            : base(context)
        {
        }
    }

    public class RepositoryBase<T> : IRepository<T>
        where T: class
    {
        private DbContext context;
        private DbSet<T> dbSet;

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


    public partial class CrossfitBenchmarksEntities1 : IUnitOfWork
    {

        #region IUnitOfWork Members
        public void Commit()
        {
            throw new NotImplementedException();
        }

        #endregion
    }

    class UnitOfWork
    {
    }
}
