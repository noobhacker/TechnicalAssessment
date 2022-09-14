using TechnicalAssessment.Persistance;

namespace TechnicalAssessment.Core.Interfaces
{
    public interface IFeatureRepository
    {
        // Use customized response class instead of directly uses ORM entity
        // once the query goes complex
        public Feature? Get(string email, string featureName);
        public void Add(string email, string featureName, bool enabled);
    }
}
