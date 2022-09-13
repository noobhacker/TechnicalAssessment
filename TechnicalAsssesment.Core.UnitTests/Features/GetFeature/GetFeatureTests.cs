using TechnicalAssessment.Core.Exceptions;
using TechnicalAssessment.Core.Features.Queries.GetFeature;

namespace Core.UnitTests.Features.GetFeature
{
    public class GetFeatureTests
    {
        [Test]
        public void GivenInvalidEmail_ReturnsBadRequest()
        {
            var handler = new GetFeatureQueryHandler(new MockReturnsFeatureRepository());

            Assert.Throws<BadRequestException>(() => handler.Handle(new GetFeatureQuery
            {
                email = "...",
                featureName = "Feature1"
            }));
        }

        [Test]
        public void GivenInvalidFeatureName_ReturnsBadRequest()
        {
            var handler = new GetFeatureQueryHandler(new MockReturnsFeatureRepository());

            Assert.Throws<BadRequestException>(() => handler.Handle(new GetFeatureQuery
            {
                email = "test@test.com",
                featureName = ""
            }));
        }

        [Test]
        public void GivenRecordNotFound_ReturnsNotFound()
        {
            var handler = new GetFeatureQueryHandler(new MockFeatureNotFoundRepository());

            Assert.Throws<NotFoundException>(() => handler.Handle(new GetFeatureQuery
            {
                email = "test@test.com",
                featureName = "Feature1"
            }));
        }

        [Test]
        public void GivenProperInput_ReturnsExpectedResponse()
        {
            var handler = new GetFeatureQueryHandler(new MockReturnsFeatureRepository());

            var result = handler.Handle(new GetFeatureQuery
            {
                email = "test@test.com",
                featureName = "Feature1"
            });

            Assert.IsTrue(result.canAccess);
        }
    }
}