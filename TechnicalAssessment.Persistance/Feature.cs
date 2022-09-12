using System.ComponentModel.DataAnnotations;

namespace TechnicalAssessment.Persistance
{
    public class Feature
    {
        public int Id { get; set; }

        [StringLength(500)]
        public string Email { get; set; }
        public FeatureName FeatureName { get; set; }
        public bool Enabled { get; set; }
    }
}