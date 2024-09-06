using Entity.DTO;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface ICountryData
    {
        public Task Delete(int id);
        public Task<country> GetById(int id);
        public Task<country> Save(country entity);
        public Task Update(country entity);
        public Task<IEnumerable<country>> GetAll();
        public Task<country> GetByName(string Name);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
    }
}
