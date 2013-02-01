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
    public class TheHerosControllerTests
    {
        [Test]
        public void Get_ReturnsData_From_Repo()
        {
            var dataOut = new List<WorkoutLogEntryDto>();
            repo.Expect(it => it.GetWorkoutLogEntries(Arg<int>.Is.GreaterThan(0), Arg<string>.Is.Equal("H"))).Return(dataOut);
            controller.Get(3);

            repo.VerifyAllExpectations();
        }

        [SetUp]
        public void Setup()
        {
            var kernel = new RhinoMocksMockingKernel();
            controller = kernel.Get<TheHerosController>();
            repo = kernel.Get<IWorkoutLogRepository>();
        }

        private IWorkoutLogRepository repo;
        private TheHerosController controller;
    }
}

