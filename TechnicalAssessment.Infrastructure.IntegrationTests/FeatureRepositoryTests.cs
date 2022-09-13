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

        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        private DatabaseContext GetPrepopulatedDatabase()
        {
            
        }
    }
}