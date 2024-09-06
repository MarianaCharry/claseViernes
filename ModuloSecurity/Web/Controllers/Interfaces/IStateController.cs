using Entity.DTO;
using Entity.Model.Security;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Interfaces
{
    public interface IStateController
    {
        Task<IActionResult> Delete(int id);

        Task<ActionResult<stateDto>> GetById(int id);

        Task<ActionResult<state>> Save([FromBody] stateDto stateDto);

        Task<IActionResult> Update([FromBody] stateDto stateDto);

        Task<ActionResult<IEnumerable<stateDto>>> GetAll();
    }
}
