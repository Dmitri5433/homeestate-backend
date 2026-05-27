using HomeEstate.BusinessLogic.Interface;
using HomeEstate.Domains.Models.Apartment;
using Microsoft.AspNetCore.Mvc;

namespace HomeEstate.Api.Controller
{
    [Route("api/apartment")]
    [ApiController]
    public class ApartmentController : ControllerBase
    {
        private readonly IApartmentService _apartmentService;

        public ApartmentController(IApartmentService apartmentService)
        {
            _apartmentService = apartmentService;
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            return Ok(_apartmentService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var apartment = _apartmentService.GetById(id);
            if (apartment == null)
                return NotFound(new { Message = "Apartment not found." });
            return Ok(apartment);
        }

        [HttpPost]
        public IActionResult Create([FromBody] ApartmentDto apartment)
        {
            return Ok(_apartmentService.Create(apartment));
        }

        [HttpPut]
        public IActionResult Update([FromBody] ApartmentDto apartment)
        {
            return Ok(_apartmentService.Update(apartment));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_apartmentService.Delete(id));
        }
    }
}