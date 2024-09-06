using Entity.DTO;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interface
{
    public interface ICityBusiness
    {

        Task Delete(int id);
        Task<IEnumerable<cityDto>> GetAll();
        Task<cityDto> GetById(int id);

        Task<city> Save(cityDto entity);

        Task Update(cityDto entity);
    }
}
