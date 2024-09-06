using Entity.DTO;
using Entity.Model.Security;

namespace Data.Interfaces
{
    public interface IUserRoleData
    {
        public Task Delete(int id);

        public Task<UserRole> GetById(int id);

        public Task<UserRole> Save(UserRole entity);

        public Task Update(UserRole entity);

        public Task<IEnumerable<UserRole>> GetAll();

        public Task<UserRole>GetByName(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
    }
}
