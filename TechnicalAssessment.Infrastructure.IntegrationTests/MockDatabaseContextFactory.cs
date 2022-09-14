using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using TechnicalAssessment.Persistance;

namespace TechnicalAssessment.Infrastructure.IntegrationTests
{
    public class MockDatabaseContextFactory : IDisposable
    {
        private readonly SqliteConnection _connection = new SqliteConnection("Filename=:memory:");
        private DatabaseContext? _databaseContext;
        public DatabaseContext Create()
        {
            _connection.Open();

            var contextOptions = new DbContextOptionsBuilder<DatabaseContext>()
                .UseSqlite(_connection)
                .Options;

            _databaseContext = new DatabaseContext(contextOptions);
            if (_databaseContext.Database.EnsureCreated())
            {
                _databaseContext.FeatureNames.AddRange(
                    new FeatureName { Name = "Feature1" },
                    new FeatureName { Name = "Feature2" });

                _databaseContext.SaveChanges();

                _databaseContext.Features.AddRange(
                    new Feature { FeatureNameId = 1, Email = "test@test.com", Enabled = true },
                    new Feature { FeatureNameId = 2, Email = "test@test.com", Enabled = true },
                    new Feature { FeatureNameId = 1, Email = "test2@test2.com", Enabled = false });

                _databaseContext.SaveChanges();
            }

            return _databaseContext;
        }

        public void Dispose()
        {
            _connection.Close();
            _databaseContext?.Dispose();
        }
    }
}
