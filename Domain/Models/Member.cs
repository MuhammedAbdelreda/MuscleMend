using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Member
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public DateTime MemberShipStartDate { get; set; }
        public DateTime MemberShipEndDate { get; set; }
        public bool IsActive {  get; set; }
        public string Password { get; set; }

        public ICollection<WorkoutPlan> WorkOutPlans{  get; set; } = new List<WorkoutPlan>();
        public ICollection<ProgressTracking> ProgressTrackings{ get; set; }= new List<ProgressTracking>();
        public ICollection<Payment> Payments { get; set; } = new List<Payment>();

    }
}
