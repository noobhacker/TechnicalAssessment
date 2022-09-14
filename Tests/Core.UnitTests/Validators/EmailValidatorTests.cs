using TechnicalAssessment.Core.Validators;

namespace TechnicalAssessment.Core.UnitTests.Validators
{
    public class EmailValidatorTests
    {
        [Test]
        public void WhenGivenThreeDots_ReturnsFalse()
        {
            var result = EmailValidator.Validate("...");

            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public void WhenGivenTwoAts_ReturnsFalse()
        {
            var result = EmailValidator.Validate("@@");

            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public void WhenGivenTwoEmptyString_ReturnsFalse()
        {
            var result = EmailValidator.Validate("");

            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public void WhenGivenSpaces_ReturnsFalse()
        {
            var result = EmailValidator.Validate("  ");

            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public void WhenGivenStringWithoutAts_ReturnsFalse()
        {
            var result = EmailValidator.Validate("000111222");

            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public void WhenGivenProperEmail_ReturnsTrue()
        {
            var result = EmailValidator.Validate("test@test.com");

            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public void WhenGivenEmailWithMultipleSuffix_ReturnsTrue()
        {
            var result = EmailValidator.Validate("test@test.cc.bb.xyz.mm");

            Assert.That(result, Is.EqualTo(true));
        }
    }
}
