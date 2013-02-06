using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CrossfitBenchmarks.Data;
using CrossfitBenchmarks.Data.DataTransfer;
using CrossfitBenchmarks.Data.Persistance;
using AutoMapper;

namespace CrossfitBenchmarks.Services.Controllers
{
    [Authorize]
    public class WorkoutTypesController : ApiController
    {
        private readonly IWorkoutTypesRepository workoutTypesRepo;
        public IEnumerable<WorkoutTypeDto> Get()
        {
            return  Mapper.Map<IEnumerable<WorkoutTypeDto>>(workoutTypesRepo.GetAll());
        }

        public WorkoutTypesController(IWorkoutTypesRepository workoutTypesRepo)
        {
            this.workoutTypesRepo = workoutTypesRepo;
        }

        protected WorkoutTypesController()
        {
            
        }
    }
}
