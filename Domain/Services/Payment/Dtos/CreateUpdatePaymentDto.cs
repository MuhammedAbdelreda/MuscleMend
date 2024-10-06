using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Payment.Dtos
{
    public class CreateUpdatePaymentDto
    {
        [Required]
        [Range(0,10000)]
        public decimal Amount { get; set; }
        [Required]
        public DateTime PaymentDate { get; set; }
        [Required]
        public int MemberId {  get; set; }
    }
}
