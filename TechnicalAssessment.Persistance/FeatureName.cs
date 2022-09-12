using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalAssessment.Persistance
{
    public class FeatureName
    {
        public int Id { get; set; }

        [StringLength(500)]
        [Index(IsUnique = true)]
        public string Name { get; set; }
    }
}
