using Entity.DTO;
using Entity.Model.Security;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Interfaces
{
    public interface IRoleController
    {
        Task<IActionResult>Delete(int id);

        Task<ActionResult<RoleDto>>GetById(int id);

        Task<ActionResult<Role>> Save([FromBody] RoleDto roleDto);
    
        Task<IActionResult> Update([FromBody] RoleDto roleDto);

        Task<ActionResult<IEnumerable<RoleDto>>>GetAll();
    }
}
