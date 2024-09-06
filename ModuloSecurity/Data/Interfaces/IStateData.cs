using Entity.DTO;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IStateData
    {
        public Task Delete(int id);
        public Task<state> GetById(int id);
        public Task<state> Save(state entity);
        public Task Update(state entity);
        public Task<IEnumerable<state>> GetAll();
        public Task<state> GetByName(string name);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
    }
}
