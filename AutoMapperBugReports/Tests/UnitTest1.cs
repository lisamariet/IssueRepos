using System;
using System.Linq;
using AutomapperEnumBugExample.DomainModels;
using AutomapperEnumBugExample.Startup;
using AutomapperEnumBugExample.ViewModels;
using AutoMapper;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]

    public class UnitTest1
    {

        private IMapper _mapper;

        [SetUp]
        public void SetupTest()
        {
            var mapperConfig = MappingConfigFactory.CreateConfiguration();
            _mapper = mapperConfig.CreateMapper();
        }

        [Test]
        public void ShouldMapAllStatuses()
        {
            var statuses = Enum.GetValues(typeof(Status)).Cast<Status>();
            Assert.DoesNotThrow(() =>
            {
                foreach (var orderStatus in statuses)
                {
                    var result = _mapper.Map<ViewStatus>(orderStatus);
                    if (!Enum.IsDefined(typeof(ViewStatus), result))
                        throw new ArgumentOutOfRangeException($"Invalid Status: {result}");
                }
            });
        }

        [Test]
        public void ShouldMapFinalizeStatus()
        {
            var result = _mapper.Map<ViewStatus>(Status.Finalized);

            Assert.AreEqual(ViewStatus.Ordered, result);
        }

        [Test]
        public void ShouldMapInitializedStatus()
        {
            var result = _mapper.Map<ViewStatus>(Status.Initialized);

            Assert.AreEqual(ViewStatus.Ordered, result);
        }
    }
}
