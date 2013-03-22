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
    public class LogEntryController : ApiController
    {
        public WorkoutLogEntryDto Put([FromBody] LogEntryDto dataToSave)
        {
            var userInfo = userRepository.GetUserInfo(dataToSave.UserInfo.NameIdentifier, dataToSave.UserInfo.IdentityProvider);
            if (userInfo == null)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound) { Content = new StringContent(string.Format("No User was found for nameIdentifier '{0}' and identityProvider '{1}'", dataToSave.UserInfo.NameIdentifier, dataToSave.UserInfo.IdentityProvider)), ReasonPhrase = "User Not Found" };
                throw new HttpResponseException(resp);
            }

            dataToSave.UserId = userInfo.UserId.ToString();
            dataToSave.UserInfo = userInfo;
            var dataAfterSave = workoutLogRepo.Create(dataToSave);

            return workoutLogRepo.GetSingleWorkoutLogEntry(dataAfterSave);
        }

        public bool Delete(int id, string ip, string nid)
        {
            return workoutLogRepo.Delete(id, ip, nid);
        }

        public  LogEntryController(IWorkoutLogRepository workoutLogRepo, IUserRepository userRepository)
        {
            this.userRepository = userRepository;
            this.workoutLogRepo = workoutLogRepo;
        }


        private readonly IUserRepository userRepository;
        private readonly IWorkoutLogRepository workoutLogRepo;
    }


    public class DeleteLogEntry
    {
        public int id { get; set; }
        public string nid { get; set; }
        public string ip { get; set; }

        public  DeleteLogEntry()
        {
            
        }
    }
}

