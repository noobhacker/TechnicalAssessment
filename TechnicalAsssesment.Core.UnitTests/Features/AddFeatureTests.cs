using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalAssessment.Core.Exceptions;
using TechnicalAssessment.Core.Features.Commands.AddFeature;
using TechnicalAssessment.Core.UnitTests.Features;

namespace TechnicalAssessmentCore.Core.UnitTests.Features
{
    public class AddFeatureTests
    {
        [Test]
        public void GivenInvalidEmail_ReturnsNotModified()
        {
            var handler = new AddFeatureCommandHandler(new MockReturnsFeatureRepository());

            Assert.Throws<NotModifiedException>(() => handler.Handle(new AddFeatureCommand
            {
                email = "...",
                featureName = "Feature1",
                enable = true
            }));
        }

        [Test]
        public void GivenEmptyFeatureName_ReturnsNotModified()
        {
            var handler = new AddFeatureCommandHandler(new MockReturnsFeatureRepository());

            Assert.Throws<NotModifiedException>(() => handler.Handle(new AddFeatureCommand
            {
                email = "test@test.com",
                featureName = "",
                enable = true
            }));
        }

        [Test]
        public void GivenVeryLongFeatureName_ReturnsNotModified()
        {
            var handler = new AddFeatureCommandHandler(new MockReturnsFeatureRepository());

            Assert.Throws<NotModifiedException>(() => handler.Handle(new AddFeatureCommand
            {
                email = "test@test.com",
                featureName = new string('a', 500),
                enable = true
            }));
        }

        [Test]
        public void GivenRecordAlreadyExist_ReturnsNotModified()
        {
            var handler = new AddFeatureCommandHandler(new MockReturnsFeatureRepository());

            Assert.Throws<NotModifiedException>(() => handler.Handle(new AddFeatureCommand
            {
                email = "test@test.com",
                featureName = "Feature1",
                enable = true
            }));
        }

        [Test]
        public void GivenCorrectInput_PassAllValidations()
        {
            var handler = new AddFeatureCommandHandler(new MockReturnsFeatureRepository());

            Assert.Throws<NotModifiedException>(() => handler.Handle(new AddFeatureCommand
            {
                email = "test@test.com",
                featureName = "Feature1",
                enable = true
            }));
        }
    }
}
