using System.ComponentModel.DataAnnotations;

namespace TechnicalAssessment.Persistance
{
    public class Feature
    {
        public int Id { get; set; }

        [Required]
        [StringLength(500)]
        public string Email { get; set; }

        [Required]
        public bool Enabled { get; set; }
        public int FeatureNameId { get; set; }
        public FeatureName FeatureName { get; set; }
    }
}