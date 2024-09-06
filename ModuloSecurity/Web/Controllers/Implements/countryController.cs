using Business.Interface;
using Entity.DTO;
using Entity.Model.Security;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Implements
{
    [ApiController]
    [Route("[controller]")]

    public class countryController:ControllerBase
    {
        private readonly ICountryBusiness _countryBusiness;

        public countryController(ICountryBusiness countryBusiness)
        {

            _countryBusiness = countryBusiness;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<countryDto>>> GetAll()
        {
            var result = await _countryBusiness.GetAll();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<countryDto>> GetById(int id)
        {
            var result = await _countryBusiness.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult<country>> Save([FromBody] countryDto entity)
        {
            if (entity == null)
            {
                return BadRequest("Entity is null");
            }
            var result = await _countryBusiness.Save(entity);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] countryDto entity)
        {
            if (entity != null || entity.Id == 0)
            {
                return BadRequest();
            }
            await _countryBusiness.Update(entity);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _countryBusiness.Delete(id);
            return NoContent();
        }
    }
}
