﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CrossfitBenchmarks.Data.DataTransfer;
using CrossfitBenchmarks.Data.Persistance;

namespace CrossfitBenchmarks.Services.Controllers
{
    public class TheBenchmarksController : ApiController
    {
        private readonly IWorkoutLogRepository workoutLogRepo;


        // GET api/thebenchmarks/5
        public IEnumerable<WorkoutLogEntryDto> Get(int id)
        {
            return workoutLogRepo.GetBenchmarkDataForUser(id);
        }


        public TheBenchmarksController(IWorkoutLogRepository workoutLogRepo)
        {
            this.workoutLogRepo = workoutLogRepo;
        }
    }
}
