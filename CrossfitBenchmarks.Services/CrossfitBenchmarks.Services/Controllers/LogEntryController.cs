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
    public class LogEntryController : ApiController
    {
        public LogEntryDto Put([FromBody] LogEntryDto dataToSave)
        {
            return workoutLogRepo.Create(dataToSave);
        }

        public  LogEntryController(IWorkoutLogRepository workoutLogRepo)
        {
            this.workoutLogRepo = workoutLogRepo;
        }


        private readonly IWorkoutLogRepository workoutLogRepo;
    }
}

