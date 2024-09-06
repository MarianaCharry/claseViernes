using Entity.DTO;
using Entity.Model.Security;

namespace Business.Interface
{
    public interface IRoleViewBusiness
    {

        Task Delete(int id);

        Task<IEnumerable<RoleViewDto>> GetAll();

        Task<RoleViewDto> GetById(int id);


        Task<IEnumerable<DataSelectDto>> GetAllSelect();


        Task<RoleView> Save(RoleViewDto entity);

        Task Update(RoleViewDto entity);

    }
}