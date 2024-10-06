using Core.Services.ProgessTracking.Dtos;
using Core.Services.Trainer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.ProgessTracking
{
    public interface IProgressTrackingService
    {
        Task CreateAsync(CreateUpdateProgressTrackingDto progressTracking);
        Task UpdateAsync(int id, CreateUpdateProgressTrackingDto progressTracking);
        Task DeleteAsync(int id);
        Task<List<ProgressTrackingDto>> GetAllAsync();
        Task<ProgressTrackingDto> GetWithIdAsync(int id);
    }
}
