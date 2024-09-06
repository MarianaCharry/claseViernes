using Entity.DTO;
using Entity.Model.Security;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Interfaces
{
    public interface IModuloController
    {
        Task<IActionResult>Delete(int id);

        Task<ActionResult<ModuloDto>>GetById(int id);

        Task<ActionResult<Modulo>> Save([FromBody]ModuloDto moduloDto);

        Task<IActionResult> Update([FromBody]ModuloDto moduloDto);

        Task<ActionResult<IEnumerable<ModuloDto>>> GetAll();
    }
}