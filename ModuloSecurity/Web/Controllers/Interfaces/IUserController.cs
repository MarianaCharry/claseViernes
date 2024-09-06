using Entity.DTO;
using Entity.Model.Security;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Interfaces
{
    public interface IUserController
    {
        Task<IActionResult> Delete(int id);

        Task<ActionResult<UserDto>> GetById(int id);

        Task<ActionResult<User>> Save([FromBody] UserDto userDto);

        Task<IActionResult> Update([FromBody] UserDto userDto);

        Task<ActionResult<IEnumerable<UserDto>>> GetAll();
    }
}
