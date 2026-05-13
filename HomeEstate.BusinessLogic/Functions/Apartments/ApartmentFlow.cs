using HomeEstate.BusinessLogic.Core.Apartments;
using HomeEstate.BusinessLogic.Interface;
using HomeEstate.Domains.Models.Apartment;
using HomeEstate.Domains.Models.Base;
namespace HomeEstate.BusinessLogic.Functions.Apartments
{
    public class ApartmentFlow : ApartmentAction, IApartment
    {
        public List<ApartmentDto> GetAll() => ExecuteGetAllApartmentsAction();
        public ApartmentDto? GetById(int id) => GetApartmentDataByIdAction(id);
        public ResponceMsg Create(ApartmentDto apartment) => ExecuteApartmentCreateAction(apartment);
        public ResponceMsg Update(ApartmentDto apartment) => ExecuteApartmentUpdateAction(apartment);
        public ResponceMsg Delete(int id) => ExecuteApartmentDeleteAction(id);
    }
}
