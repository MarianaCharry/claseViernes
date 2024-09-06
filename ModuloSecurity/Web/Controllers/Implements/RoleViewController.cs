using Business.Interface;
using Entity.DTO;
using Entity.Model.Security;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Implements
{

    [ApiController]
    [Route("[controller]")]

    public class RoleViewController : ControllerBase
    {
        private readonly IRoleViewBusiness _roleViewBusiness;

        public RoleViewController(IRoleViewBusiness roleViewBusiness)
        {

            _roleViewBusiness = roleViewBusiness;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoleViewDto>>> GetAll()
        {
            var result = await _roleViewBusiness.GetAll();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<RoleViewDto>> GetById(int id)
        {
            var result = await _roleViewBusiness.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult<RoleView>> Save([FromBody] RoleViewDto entity)
        {
            if (entity == null)
            {
                return BadRequest("Entity is null");
            }
            var result = await _roleViewBusiness.Save(entity);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] RoleViewDto entity)
        {
            if (entity != null || entity.Id == 0)
            {
                return BadRequest();
            }
            await _roleViewBusiness.Update(entity);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _roleViewBusiness.Delete(id);
            return NoContent();
        }
    }
}