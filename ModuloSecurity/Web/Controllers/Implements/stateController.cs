using Business.Interface;
using Entity.DTO;
using Entity.Model.Security;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Implements
{
    [ApiController]
    [Route("[controller]")]

    public class stateController:ControllerBase
    {
        private readonly IStateBusiness _stateBusiness;

        public stateController(IStateBusiness stateBusiness)
        {

            _stateBusiness = stateBusiness;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<stateDto>>> GetAll()
        {
            var result = await _stateBusiness.GetAll();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<stateDto>> GetById(int id)
        {
            var result = await _stateBusiness.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult<state>> Save([FromBody] stateDto entity)
        {
            if (entity == null)
            {
                return BadRequest("Entity is null");
            }
            var result = await _stateBusiness.Save(entity);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] stateDto entity)
        {
            if (entity != null || entity.Id == 0)
            {
                return BadRequest();
            }
            await _stateBusiness.Update(entity);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _stateBusiness.Delete(id);
            return NoContent();
        }
    }
}
