using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using TechnicalAssessment.Persistance;

namespace TechnicalAssessment.Infrastructure.IntegrationTests
{
    public class Tests
    {
        private DatabaseContext _context;

        [SetUp]
        public void Setup()
        {
            var connection = new SqliteConnection("Filename=:memory:");
            connection.Open();

            var contextOptions = new DbContextOptionsBuilder<DatabaseContext>()
                .UseSqlite(connection)
                .Options;

            using var context = new DatabaseContext(contextOptions);
            //if (context.Database.EnsureCreated)
            //{
            //    context.FeatureNames.AddRange(
            //        new FeatureName { Name = "Feature1" },
            //        new FeatureName { Name = "Feature2" });

            //    context.SaveChanges();

            //    context.Features.AddRange(
            //        new Feature { FeatureNameId = 1, Email = "test@test.com", Enabled = true },
            //        new Feature { FeatureNameId = 1, Email = "test2@test2.com", Enabled = false });

            //    context.SaveChanges();
            //}
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}