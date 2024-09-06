using Entity.DTO;
using Entity.Model.Security;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Interfaces
{
    public interface IPersonController
    {
        Task<IActionResult> Delete(int id);

        Task<ActionResult<PersonDto>>GetById(int id);

        Task<ActionResult<Person>> Save([FromBody] PersonDto person);

        Task<IActionResult> Update([FromBody] PersonDto personDto);

        Task<ActionResult<IEnumerable<PersonDto>>> GetAll();

    }
}
