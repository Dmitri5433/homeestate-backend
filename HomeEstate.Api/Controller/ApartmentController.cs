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

        // GET api/apartment/getAll
        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var apartments = _apartment.GetAllApartmentsAction();
            return Ok(apartments);
        }

        // GET api/apartment/id?id=1
        [HttpGet("id")]
        public IActionResult GetById(int id)
        {
            var apartment = _apartment.GetApartmentByIdAction(id);
            if (apartment == null)
                return NotFound(new { Message = "Apartment not found." });

            return Ok(apartment);
        }

        // POST api/apartment
        [HttpPost]
        public IActionResult Create([FromBody] ApartmentDto apartment)
        {
            var result = _apartment.ResponceApartmentCreateAction(apartment);
            return Ok(result);
        }

        // PUT api/apartment
        [HttpPut]
        public IActionResult Update([FromBody] ApartmentDto apartment)
        {
            var result = _apartment.ResponceApartmentUpdateAction(apartment);
            return Ok(result);
        }

        // DELETE api/apartment/id?id=1
        [HttpDelete("id")]
        public IActionResult Delete(int id)
        {
            var result = _apartment.ResponceApartmentDeleteAction(id);
            return Ok(result);
        }
    }
}
