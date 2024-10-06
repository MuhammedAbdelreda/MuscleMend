using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.ProgessTracking.Dtos
{
    public class ProgressTrackingDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Weight { get; set; }
        public decimal BodyFatPercentage { get; set; }
        public decimal MuscleMass { get; set; }
    }
}
