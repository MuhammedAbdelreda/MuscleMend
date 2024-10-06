using Core.Services.Trainer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Trainer
{
    public interface ITrainerService
    {
        Task CreateAsync(CreateUpdateTrainerDto trainer);
        Task UpdateAsync(int id, CreateUpdateTrainerDto trainer);
        Task DeleteAsync(int id);
        Task<List<TrainerDto>> GetAllAsync();
        Task<TrainerDto> GetWithIdAsync(int id);
    }
}
