using Core.Services.Class.Dtos;
using Core.Services.Trainer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Class
{
    public interface IClassService
    {
        Task CreateAsync(CreateUpdateClassDto _class);
        Task UpdateAsync(int id, CreateUpdateClassDto _class);
        Task DeleteAsync(int id);
        Task<List<ClassDto>> GetAllAsync();
        Task<ClassDto> GetWithIdAsync(int id);
    }
}
