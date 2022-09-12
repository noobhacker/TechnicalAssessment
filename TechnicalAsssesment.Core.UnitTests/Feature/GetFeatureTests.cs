using TechnicalAssessment.Core.Exceptions;
using TechnicalAssessment.Core.Features.Queries.GetFeature;

namespace TechnicalAsssesment.Core.UnitTests.Feature
{
    public class GetFeatureTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void GivenRecordNotFound_ReturnNotModified()
        {
            var handler = new GetFeatureQueryHandler(new MockRecordNotFoundRepository());

            Assert.Throws<NotFoundException>(() => handler.Handle(new GetFeatureQuery
            {

            }));

        }
    }
}