using HomeEstate.Domains.Models.Apartment;
using HomeEstate.Domains.Models.Base;

namespace HomeEstate.BusinessLogic.Interface
{
    public interface IApartment
    {
        List<ApartmentDto> GetAllApartmentsAction();
        ApartmentDto GetApartmentByIdAction(int id);
        ResponceMsg ResponceApartmentCreateAction(ApartmentDto apartment);
        ResponceMsg ResponceApartmentUpdateAction(ApartmentDto apartment);
        ResponceMsg ResponceApartmentDeleteAction(int id);
    }
}
