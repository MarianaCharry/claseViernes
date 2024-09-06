using Entity.DTO;
using Entity.Model.Security;

namespace Data.Interfaces
{
    public interface IRoleViewData
    {
        public Task Delete(int id);
        public Task<RoleView> GetById(int id);
        public Task<RoleView> Save(RoleView entity);
        public Task Update(RoleView entity);
        public Task<IEnumerable<RoleView>> GetAll();
        public Task<RoleView>GetByName(int id);
        public Task<IEnumerable<DataSelectDto>> GetAllSelect();
    }
}
