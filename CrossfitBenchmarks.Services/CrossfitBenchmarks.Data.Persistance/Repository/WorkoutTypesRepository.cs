using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossfitBenchmarks.Data.Persistance
{
    public class WorkoutTypesRepository : RepositoryBase<WorkoutType>, IWorkoutTypesRepository
    {
        public  WorkoutTypesRepository(DbContext context)
            : base(context)
        {
        }
    }
}

