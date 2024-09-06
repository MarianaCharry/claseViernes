using Entity.DTO;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interface
{
    public interface IStateBusiness
    {
        Task Delete(int id);
        Task<IEnumerable<stateDto>> GetAll();
        Task<stateDto> GetById(int id);

        Task<state> Save(stateDto entity);

        Task Update(stateDto entity);
    }
}
