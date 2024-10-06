using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Exercise
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Reps {  get; set; }
        public int Sets {  get; set; }
        public TimeSpan RestTime { get; set; }

        public int WorkoutPlanId {  get; set; }
    }
}
