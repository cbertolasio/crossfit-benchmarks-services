using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using CrossfitBenchmarks.Data.DataTransfer;
using CrossfitBenchmarks.Data.Persistance;

namespace CrossfitBenchmarks.Services.Controllers
{
    public class TheGirlsController : ApiController
    {
        public IEnumerable<WorkoutLogEntryDto> Get(int userId)
        {
            return repository.GetBenchmarkDataForUser(userId, "G");
        }

        public TheGirlsController(IWorkoutLogRepository repository)
        {
            this.repository = repository;
        }

        private readonly IWorkoutLogRepository repository;
    }
}
