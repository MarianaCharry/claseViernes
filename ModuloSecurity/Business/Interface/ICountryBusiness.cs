using Entity.DTO;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interface
{
    public interface ICountryBusiness
    {

        Task Delete(int id);
        Task<IEnumerable<countryDto>> GetAll();
        Task<countryDto> GetById(int id);

        Task<country> Save(countryDto entity);

        Task Update(countryDto entity);
    }
}
