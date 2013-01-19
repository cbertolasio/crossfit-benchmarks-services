using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace CrossfitBenchmarks.Services.Tests
{
    [TestFixture]
    public class AutomapperTests
    {
        [Test]
        public void AutomapsAreValid()
        {
            CrossfitBenchmarks.Services.AutomapBootstrap.Initialize();
            AutoMapper.Mapper.AssertConfigurationIsValid();
        }
    }
}
