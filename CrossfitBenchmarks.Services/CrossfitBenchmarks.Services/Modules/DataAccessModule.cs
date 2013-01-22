using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using CrossfitBenchmarks.Data.Persistance;
using CrossfitBenchmarks.Services.Controllers;
using Ninject;
using Ninject.Web.Common;


namespace CrossfitBenchmarks.Services.Modules
{
    public class DataAccessModule : Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
            // This gives us the ability to perform multiple operations
            // on multiple repositories in a single transaction.
            Bind<CrossfitBenchmarksEntities1>().ToSelf().InRequestScope();
            Bind<IUnitOfWork>().ToMethod(ctx => ctx.Kernel.Get<CrossfitBenchmarksEntities1>());
            Bind<DbContext>().ToMethod(ctx => ctx.Kernel.Get<CrossfitBenchmarksEntities1>());

            Bind<IWorkoutTypesRepository>().To<WorkoutTypesRepository>();
            Bind<IWorkoutLogRepository>().To<WorkoutLogRepository>();
        }

        public DataAccessModule()
        {
        }
    }
}