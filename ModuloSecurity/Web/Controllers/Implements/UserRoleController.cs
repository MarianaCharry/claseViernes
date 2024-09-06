using Business.Interface;
using Entity.DTO;
using Entity.Model.Security;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Implements
{

    [ApiController]
    [Route("[controller]")]

    public class UserRoleController : ControllerBase
    {
        private readonly IUserRoleBusiness _userRoleBusiness;

        public UserRoleController(IUserRoleBusiness userRoleBusiness)
        {

            _userRoleBusiness = userRoleBusiness;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserRoleDto>>> GetAll()
        {
            var result = await _userRoleBusiness.GetAll();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<UserRoleDto>> GetById(int id)
        {
            var result = await _userRoleBusiness.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult<UserRole>> Save([FromBody] UserRoleDto entity)
        {
            if (entity == null)
            {
                return BadRequest("Entity is null");
            }
            var result = await _userRoleBusiness.Save(entity);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] UserRoleDto entity)
        {
            if (entity != null || entity.Id == 0)
            {
                return BadRequest();
            }
            await _userRoleBusiness.Update(entity);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _userRoleBusiness.Delete(id);
            return NoContent();
        }
    }
}
