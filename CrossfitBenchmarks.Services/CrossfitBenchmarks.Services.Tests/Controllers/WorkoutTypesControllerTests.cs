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

namespace CrossfitBenchmarks.Services.Tests.Controllers
{
    [TestFixture]
    public class WorkoutTypesControllerTests
    {
        [Test]
        public void Get_Calls_Repo()
        {
            workoutTypesRepo.Expect(it => it.GetAll()).Return(testData);
            
            controller.Get();

            workoutTypesRepo.VerifyAllExpectations();
        }

        [SetUp]
        public void Setup()
        {
            var kernel = new RhinoMocksMockingKernel();
            workoutTypesRepo = kernel.Get<IWorkoutTypesRepository>();
            controller = kernel.Get<WorkoutTypesController>();
        }


        private WorkoutTypesController controller;
        private List<WorkoutType> testData = new List<WorkoutType>();
        private IWorkoutTypesRepository workoutTypesRepo;
    }
}
