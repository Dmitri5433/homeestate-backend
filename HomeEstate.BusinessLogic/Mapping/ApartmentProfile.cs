using AutoMapper;
using HomeEstate.Domains.Entities.Apartment;
using HomeEstate.Domains.Models.Apartment;

namespace HomeEstate.BusinessLogic.Mapping
{
    public class ApartmentProfile : Profile
    {
        public ApartmentProfile()
        {
            CreateMap<ApartmentData, ApartmentDto>();
            CreateMap<ApartmentDto, ApartmentData>()
                .ForMember(dest => dest.Status, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore());
        }
    }
}
