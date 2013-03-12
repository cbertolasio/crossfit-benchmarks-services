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
    public class TheHeroesControllerTests
    {
        [Test]
        public void Get_ReturnsData_From_Repo()
        {
            var dataOut = new List<WorkoutLogEntryDto>();
            var testUser = new UserInfoDto { UserId = 3 };
            userRepo.Stub(it => it.GetUserInfo(Arg<string>.Is.Anything, Arg<string>.Is.Anything)).Return(testUser);
            repo.Expect(it => it.GetWorkoutLogEntries(Arg<int>.Is.GreaterThan(0), Arg<string>.Is.Equal("H"))).Return(dataOut);
            controller.Get("userName", "facebook");

            repo.VerifyAllExpectations();
        }

        [SetUp]
        public void Setup()
        {
            var kernel = new RhinoMocksMockingKernel();
            controller = kernel.Get<TheHeroesController>();
            repo = kernel.Get<IWorkoutLogRepository>();
            
            userRepo = kernel.Get<IUserRepository>();
        }

        private IWorkoutLogRepository repo;
        private TheHeroesController controller;
        private IUserRepository userRepo;
    }
}

