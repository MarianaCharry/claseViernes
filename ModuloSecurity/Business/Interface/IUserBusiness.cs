using Entity.DTO;
using Entity.Model.Security;

namespace Business.Interface
{
    public interface IUserBusiness
    {
        Task Delete (int id);
        Task<IEnumerable<UserDto>> GetAll();

        Task<UserDto> GetById (int id);

        Task<User>Save(UserDto entity);

        Task Update(UserDto entity);

    }
}
