using Entity.DTO;
using Entity.Model.Security;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Interfaces
{
    public interface IViewController
    {
        Task<IActionResult> Delete(int id);

        Task<ActionResult<ViewDto>>GetById(int id);

        Task<ActionResult<View>> Save([FromBody] ViewDto viewDto);

        Task<IActionResult> Update([FromBody] ViewDto viewDto);
        Task<ActionResult<IEnumerable<ViewDto>>> GetAll();
    }
}
