using Entity.DTO;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface ICityData
    {

        public Task Delete(int id);
        public Task<city> GetById(int id);
        public Task<city> Save(city entity);
        public Task Update(city entity);
        public Task<IEnumerable<city>> GetAll();
        public Task<city> GetByName(string name);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
    }
}
