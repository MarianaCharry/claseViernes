using Entity.DTO;
using Entity.Model.Security;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Interfaces
{
    public interface ICountryController
    {
        Task<IActionResult> Delete(int id);

        Task<ActionResult<countryDto>> GetById(int id);

        Task<ActionResult<country>> Save([FromBody] countryDto countryDto);

        Task<IActionResult> Update([FromBody] countryDto countryDto);

        Task<ActionResult<IEnumerable<countryDto>>> GetAll();
    }
}
