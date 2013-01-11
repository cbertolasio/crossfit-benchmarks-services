using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CrossfitBenchmarks.Data;
using CrossfitBenchmarks.Data.Persistance;

namespace CrossfitBenchmarks.Services.Controllers
{
    public class WorkoutTypesController : ApiController
    {
        private readonly IWorkoutTypesRepository workoutTypes;
        
        // GET api/workouttypes
        public IEnumerable<WorkoutType> Get()
        {
            return workoutTypes.GetAll();
        }

        // GET api/workouttypes/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/workouttypes
        public void Post([FromBody] string value)
        {
        }

        // PUT api/workouttypes/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/workouttypes/5
        public void Delete(int id)
        {
        }

        public WorkoutTypesController(IWorkoutTypesRepository workoutTypes)
        {
            this.workoutTypes = workoutTypes;
        }
    }
}
