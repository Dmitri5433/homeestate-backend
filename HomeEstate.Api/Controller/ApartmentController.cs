using HomeEstate.BusinessLogic.Interface;
using HomeEstate.Domains.Models.Apartment;
using Microsoft.AspNetCore.Mvc;

namespace HomeEstate.Api.Controller
{
    [Route("api/apartment")]
    [ApiController]
    public class ApartmentController : ControllerBase
    {
        private readonly IApartment _apartmentService;

        public ApartmentController(IApartment apartmentService)
        {
            _apartmentService = apartmentService;
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            return Ok(_apartmentService.GetAllApartmentsAction());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var apartment = _apartmentService.GetApartmentByIdAction(id);
            if (apartment == null)
                return NotFound(new { Message = "Apartment not found." });
            return Ok(apartment);
        }

        [HttpPost]
        public IActionResult Create([FromBody] ApartmentDto apartment)
        {
            return Ok(_apartmentService.ResponceApartmentCreateAction(apartment));
        }

        [HttpPut]
        public IActionResult Update([FromBody] ApartmentDto apartment)
        {
            return Ok(_apartmentService.ResponceApartmentUpdateAction(apartment));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_apartmentService.ResponceApartmentDeleteAction(id));
        }
    }
}