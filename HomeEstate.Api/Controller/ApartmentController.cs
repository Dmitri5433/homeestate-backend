using HomeEstate.BusinessLogic.Interface;
using HomeEstate.Domains.Models.Apartment;
using Microsoft.AspNetCore.Mvc;

namespace HomeEstate.Api.Controller
{
    [Route("api/apartment")]
    [ApiController]
    public class ApartmentController : ControllerBase
    {
        private readonly IApartment _apartment;

        public ApartmentController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _apartment = bl.GetApartmentActions();
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var apartments = _apartment.GetAllApartmentsAction();
            return Ok(apartments);
        }

        [HttpGet("id")]
        public IActionResult GetById(int id)
        {
            var apartment = _apartment.GetApartmentByIdAction(id);
            if (apartment == null)
                return NotFound(new { Message = "Apartment not found." });

            return Ok(apartment);
        }

        [HttpPost]
        public IActionResult Create([FromBody] ApartmentDto apartment)
        {
            var result = _apartment.ResponceApartmentCreateAction(apartment);
            return Ok(result);
        }

        [HttpPut]
        public IActionResult Update([FromBody] ApartmentDto apartment)
        {
            var result = _apartment.ResponceApartmentUpdateAction(apartment);
            return Ok(result);
        }

        [HttpDelete("id")]
        public IActionResult Delete(int id)
        {
            var result = _apartment.ResponceApartmentDeleteAction(id);
            return Ok(result);
        }
    }
}