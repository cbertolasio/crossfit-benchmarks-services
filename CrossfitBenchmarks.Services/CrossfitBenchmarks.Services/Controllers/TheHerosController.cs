using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Http;
using CrossfitBenchmarks.Data.DataTransfer;
using CrossfitBenchmarks.Data.Persistance;

namespace CrossfitBenchmarks.Services.Controllers
{
    [Authorize]
    public class TheHerosController : ApiController
    {
        
        public IEnumerable<WorkoutLogEntryDto> Get(int id)
        {
            return workoutLogRepo.GetWorkoutLogEntries(id, "H");
        }

        public TheHerosController(IWorkoutLogRepository workoutLogRepo)
        {
            this.workoutLogRepo = workoutLogRepo;
        }

        private readonly IWorkoutLogRepository workoutLogRepo;
    }
}
