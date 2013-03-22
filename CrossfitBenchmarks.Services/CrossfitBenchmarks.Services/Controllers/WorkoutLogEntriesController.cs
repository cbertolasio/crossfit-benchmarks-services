using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CrossfitBenchmarks.Data.DataTransfer;
using CrossfitBenchmarks.Data.Persistance;

namespace CrossfitBenchmarks.Services.Controllers
{
    public class WorkoutLogEntriesController : ApiController
    {
        private readonly IWorkoutLogRepository workoutLogRepo;
        public bool Delete(int id, string ip, string nid)
        {
            return workoutLogRepo.DeleteAll(id, ip, nid);
        }

        public  WorkoutLogEntriesController(IWorkoutLogRepository workoutLogRepo)
        {
            this.workoutLogRepo = workoutLogRepo;
        }
    }
}

