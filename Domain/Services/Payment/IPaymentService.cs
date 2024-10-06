using Core.Services.Payment.Dtos;
using Core.Services.Trainer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Payment
{
    public interface IPaymentService
    {
        Task CreateAsync(CreateUpdatePaymentDto payment);
        Task UpdateAsync(int id, CreateUpdatePaymentDto payment);
        Task DeleteAsync(int id);
        Task<List<PaymentDto>> GetAllAsync();
        Task<PaymentDto> GetWithIdAsync(int id);
    }
}
