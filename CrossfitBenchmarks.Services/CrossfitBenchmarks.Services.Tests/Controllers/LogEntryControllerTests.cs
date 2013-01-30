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
        public void Put_Calls_Create_OnRepo()
        {
            workoutLogRepo.Expect(it => it.Create(Arg<LogEntryDto>.Is.NotNull)).Return(dataOut);

            controller.Put(dataIn);

            workoutLogRepo.VerifyAllExpectations();
        }

        [SetUp]
        public void Setup()
        {
            var kernel = new RhinoMocksMockingKernel();
            workoutLogRepo = kernel.Get<IWorkoutLogRepository>();
            controller = kernel.Get<LogEntryController>();
        }

        private LogEntryController controller;
        private LogEntryDto dataIn = new LogEntryDto();
        private LogEntryDto dataOut = new LogEntryDto();
        private IWorkoutLogRepository workoutLogRepo;
    }
}

