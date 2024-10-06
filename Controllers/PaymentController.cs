using Core.Services.Class.Dtos;
using Core.Services.Class;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Core.Services.Payment;
using Core.Services.Payment.Dtos;
using Domain.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService service;

        public PaymentController(IPaymentService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<PaymentDto>>> Get()
        {
            return await service.GetAllAsync();
        }

        [HttpGet("Id")]
        public async Task<PaymentDto> GetWithId(int id)
        {
            return await service.GetWithIdAsync(id);
        }

        [HttpDelete("Id")]
        public async Task Delete(int id)
        {
            await service.DeleteAsync(id);
        }

        [HttpPost]
        public async Task Create(CreateUpdatePaymentDto payment)
        {
            await service.CreateAsync(payment);
        }

        [HttpPut("Id")]
        public async Task Update(int id, CreateUpdatePaymentDto payment)
        {
            await service.UpdateAsync(id, payment);
        }
    }
}
