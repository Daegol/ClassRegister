using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClassRegister.Services.DTOs;

namespace ClassRegister.Services.IServices
{
    public interface IParentService
    {
        Task<IEnumerable<ParentDto>> GetParents();

        Task DeleteParent(string pesel);
        Task UpdateParent(UpdateParentDto parentDto);
        Task<PlanDto> GetPlan(Guid id);
    }
}