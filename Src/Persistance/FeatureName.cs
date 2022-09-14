using System.ComponentModel.DataAnnotations;

namespace TechnicalAssessment.Persistance
{
    public class FeatureName
    {
        public int Id { get; set; }

        [Required]
        [StringLength(500)]
        public string Name { get; set; }
    }
}
