using Entity.DTO;
using Entity.Model.Security;

namespace Business.Interface
{
    public interface IUserRoleBusiness
    {
        Task Delete(int id);

        Task<IEnumerable<UserRoleDto>> GetAll();

        Task<UserRoleDto> GetById(int id);

        Task<UserRole>Save(UserRoleDto entity);

        Task Update(UserRoleDto entity);

    }
}
