using Entity.DTO;
using Entity.Model.Security;

namespace Data.Interfaces
{
    public interface IRoleData
    {
        Task Delete(int id);
        Task<Role> GetById(int id);
        Task<Role> Save(Role entity);
        Task Update(Role entity);
        Task<IEnumerable<Role>> GetAll();
        Task<Role>GetByName(string name);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
    }
}
