using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using CrossfitBenchmarks.Data.DataTransfer;
using CrossfitBenchmarks.Data.Persistance;

namespace CrossfitBenchmarks.Services.Controllers
{
    [Authorize]
    public class TheBenchmarksController : ApiController
    {
        private const string WORKOUTTYPEID_B = "B";
        private readonly IWorkoutLogRepository workoutLogRepo;


        // GET api/thebenchmarks/5
        public IEnumerable<WorkoutLogEntryDto> Get(int id)
        {
            return workoutLogRepo.GetWorkoutLogEntries(id, WORKOUTTYPEID_B);
        }


        public TheBenchmarksController(IWorkoutLogRepository workoutLogRepo)
        {
            this.workoutLogRepo = workoutLogRepo;
        }
    }
}
