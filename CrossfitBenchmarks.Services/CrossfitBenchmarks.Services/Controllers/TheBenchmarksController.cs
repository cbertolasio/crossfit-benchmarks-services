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
    [Authorize]
    public class TheBenchmarksController : ApiController
    {
        private readonly IUserRepository userRepository;
        private const string WORKOUTTYPEID_B = "B";
        private readonly IWorkoutLogRepository workoutLogRepo;


        // GET api/thebenchmarks/5
        public IEnumerable<WorkoutLogEntryDto> Get( string nameIdentifier,  string identityProvider)
        {
            var userInfo = userRepository.GetUserInfo(nameIdentifier, identityProvider);
            if (userInfo == null)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound) { Content = new StringContent(string.Format("No User was found for nameIdentifier '{0}' and identityProvider '{1}'", nameIdentifier, identityProvider)), ReasonPhrase = "User Not Found" };
                throw new HttpResponseException(resp);
            }

            return workoutLogRepo.GetWorkoutLogEntries(userInfo.UserId, WORKOUTTYPEID_B);
        }


        public TheBenchmarksController(IWorkoutLogRepository workoutLogRepo, IUserRepository userRepository)
        {
            this.userRepository = userRepository;
            this.workoutLogRepo = workoutLogRepo;
        }
    }
}
