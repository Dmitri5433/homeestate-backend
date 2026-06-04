using System.Collections.Generic;
using HomeEstate.Domains.Models.Apartment;
using HomeEstate.Domains.Models.Base;

namespace HomeEstate.BusinessLogic.Interface
{
    public interface IReviewService
    {
        List<ReviewDto> GetByApartment(int apartmentId);
        ResponseMessage Create(CreateReviewDto dto, int userId);
    }
}
