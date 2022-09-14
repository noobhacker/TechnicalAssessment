using Microsoft.EntityFrameworkCore;
using TechnicalAssessment.Infrastructure.Repositories;

namespace TechnicalAssessment.Infrastructure.IntegrationTests
{
    public class FeatureRepositoryTests
    {
        [Test]
        public void Get_GivenExistsInput_ReturnsFeatureEnabled()
        {
            using var context = new MockDatabaseContextFactory().Create();
            var repository = new FeatureRepository(context);

            var feature = repository.Get("test@test.com", "Feature1");

            Assert.IsTrue(feature?.Enabled);
        }

        [Test]
        public void Get_GivenNonExistingInput_ReturnsFeatureEnabled()
        {
            using var context = new MockDatabaseContextFactory().Create();
            var repository = new FeatureRepository(context);

            var feature = repository.Get("test@test.com", "Feature3");

            Assert.That(feature, Is.EqualTo(null));
        }

        [Test]
        public void Add_GivenCorrectInput_QueriesInsertedResult()
        {
            using var context = new MockDatabaseContextFactory().Create();
            var repository = new FeatureRepository(context);

            repository.Add("test3@test.com", "Feature3", true);

            var query = repository.Get("test3@test.com", "Feature3");
            Assert.That(query?.Enabled, Is.EqualTo(true));
        }

        [Test]
        public void Add_GivenAlreadyExistInput_TriggersUniqueConstraintError()
        {
            using var context = new MockDatabaseContextFactory().Create();
            var repository = new FeatureRepository(context);

            Assert.Throws<DbUpdateException>(() => repository.Add("test@test.com", "Feature1", true));

        }
    }
}