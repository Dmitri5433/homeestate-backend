using HomeEstate.BusinessLogic.Interface;
using HomeEstate.Domains.Models.City;
using Microsoft.AspNetCore.Mvc;

namespace HomeEstate.Api.Controller
{
    [Route("api/city")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityService _cityService;

        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }

        [HttpGet("getAll")]
        public IActionResult GetAll() => Ok(_cityService.GetAll());

        [HttpPost]
        public IActionResult Create([FromBody] CityDto city) => Ok(_cityService.Create(city));

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) => Ok(_cityService.Delete(id));
    }
}