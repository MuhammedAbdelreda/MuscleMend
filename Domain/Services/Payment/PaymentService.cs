using AutoMapper;
using Core.IRepository;
using Core.Services.Payment.Dtos;
using Core.Services.Trainer.Dtos;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Payment
{
    public class PaymentService:IPaymentService
    {
        private readonly IGenericRepository<Domain.Models.Payment> repo;
        private readonly IMapper mapper;

        public PaymentService(IGenericRepository<Domain.Models.Payment> repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }
        public async Task CreateAsync(CreateUpdatePaymentDto payment)
        {
            var result = mapper.Map<Domain.Models.Payment>(payment);
            await repo.Create(result);
        }

        public async Task DeleteAsync(int id)
        {
            var result = await repo.GetWithId(id);
            if (result == null)
            {
                throw new Exception("Member not found");
            }
            await repo.Delete(result);
        }

        public async Task<List<PaymentDto>> GetAllAsync()
        {
            var result = await repo.GetAll();
            return mapper.Map<List<PaymentDto>>(result);
        }

        public async Task<PaymentDto> GetWithIdAsync(int id)
        {
            var result = await repo.GetWithId(id);
            if (result == null)
            {
                throw new Exception();
            }
            return mapper.Map<PaymentDto>(result);
        }

        public async Task UpdateAsync(int id, CreateUpdatePaymentDto payment)
        {
            var result = await repo.GetWithId(id);
            var resultToReturn = mapper.Map(payment, result);
            await repo.Update(resultToReturn);
        }
    }
}
