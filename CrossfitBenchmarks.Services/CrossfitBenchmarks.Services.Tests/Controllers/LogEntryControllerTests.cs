using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using CrossfitBenchmarks.Data.Persistance;
using Ninject.MockingKernel.RhinoMock;
using Ninject;
using Rhino.Mocks;
using CrossfitBenchmarks.Services.Controllers;
using CrossfitBenchmarks.Data;
using CrossfitBenchmarks.Data.DataTransfer;

namespace CrossfitBenchmarks.Services.Tests.Controllers
{

    [TestFixture]
    public class LogEntryControllerTests
    {
        [Test]
        public void Put_Calls_GetSingleWorkoutLogEntry_OnRepo()
        {
            var dataOut = new WorkoutLogEntryDto();
            var logEntryOut = new LogEntryDto { UserInfo = dataIn.UserInfo } ;

            workoutLogRepo.Stub(it => it.Create(Arg<LogEntryDto>.Is.NotNull)).Return(logEntryOut);
            userRepo.Stub(it => it.GetUserInfo(Arg<string>.Is.Anything, Arg<string>.Is.Anything)).Return(testUser);

            workoutLogRepo.Expect(it => it.GetSingleWorkoutLogEntry(Arg<LogEntryDto>.Is.NotNull)).Return(dataOut);
            controller.Put(dataIn);
            workoutLogRepo.VerifyAllExpectations();
        }

        [Test]
        public void Put_Calls_Create_OnRepo()
        {
            workoutLogRepo.Expect(it => it.Create(Arg<LogEntryDto>.Is.NotNull)).Return(dataOut);
            userRepo.Stub(it => it.GetUserInfo(Arg<string>.Is.Anything, Arg<string>.Is.Anything)).Return(testUser);

            controller.Put(dataIn);

            workoutLogRepo.VerifyAllExpectations();
        }

        [SetUp]
        public void Setup()
        {
            var kernel = new RhinoMocksMockingKernel();
            workoutLogRepo = kernel.Get<IWorkoutLogRepository>();
            userRepo = kernel.Get<IUserRepository>();
            controller = kernel.Get<LogEntryController>();

            dataIn.UserInfo = new UserInfoDto { NameIdentifier = "userId", IdentityProvider = "providerName" };
        }

        private LogEntryController controller;
        private LogEntryDto dataIn = new LogEntryDto();
        private LogEntryDto dataOut = new LogEntryDto();
        private UserInfoDto testUser = new UserInfoDto { UserId = 3 };
        private IWorkoutLogRepository workoutLogRepo;
        private IUserRepository userRepo;
    }
}

