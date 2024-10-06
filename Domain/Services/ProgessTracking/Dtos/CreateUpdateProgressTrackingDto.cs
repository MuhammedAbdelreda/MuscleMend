using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.ProgessTracking.Dtos
{
    public class CreateUpdateProgressTrackingDto
    {
        [Required]
        public DateTime TrackingDate { get; set; }

        [Required]
        [Range(0, 300)] //Weight With kg
        public decimal Weight { get; set; }

        [Required]
        [Range(0, 100)]
        public decimal BodyFatPercentage { get; set; }

        [Required]
        [Range(0, 300)] //With kg
        public decimal MuscleMass { get; set; }
        [Required]
        public int MemberId { get; set; }
    }

}
