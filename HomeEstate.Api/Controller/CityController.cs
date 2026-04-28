using HomeEstate.BusinessLogic.Interface;
using HomeEstate.Domains.Models.City;
using Microsoft.AspNetCore.Mvc;

namespace HomeEstate.Api.Controller
{
    [Route("api/city")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityActions _city;

        public CityController()
        {
            _city = new BusinessLogic.BusinessLogic().GetCityActions();
        }

        [HttpGet("getAll")]
        public IActionResult GetAll() => Ok(_city.GetAllCitiesAction());

        [HttpPost]
        public IActionResult Create([FromBody] CityDto city) => Ok(_city.CreateCityAction(city));

        [HttpDelete("id")]
        public IActionResult Delete(int id) => Ok(_city.DeleteCityAction(id));
    }
}
