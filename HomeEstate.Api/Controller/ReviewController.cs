using HomeEstate.Api.Filters;
using HomeEstate.BusinessLogic.Interface;
using HomeEstate.Domains.Models.Apartment;
using Microsoft.AspNetCore.Mvc;

namespace HomeEstate.Api.Controller
{
    [Route("api/review")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpGet("{apartmentId}")]
        public IActionResult GetByApartment(int apartmentId) =>
            Ok(_reviewService.GetByApartment(apartmentId));

        [HttpPost]
        [AuthRequired]
        public IActionResult Create([FromBody] CreateReviewDto dto)
        {
            var userId = (int)HttpContext.Items["UserId"];
            return Ok(_reviewService.Create(dto, userId));
        }
    }
}
