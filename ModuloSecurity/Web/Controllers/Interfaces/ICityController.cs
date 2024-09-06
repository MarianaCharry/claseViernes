using Entity.DTO;
using Entity.Model.Security;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Interfaces
{
    public interface ICityController
    {
        Task<IActionResult> Delete(int id);

        Task<ActionResult<cityDto>> GetById(int id);

        Task<ActionResult<city>> Save([FromBody] cityDto cityDto);

        Task<IActionResult> Update([FromBody] cityDto cityDto);

        Task<ActionResult<IEnumerable<cityDto>>> GetAll();
    }
}
