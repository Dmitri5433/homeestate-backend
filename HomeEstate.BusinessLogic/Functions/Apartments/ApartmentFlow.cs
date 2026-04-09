using HomeEstate.BusinessLogic.Core.Apartments;
using HomeEstate.BusinessLogic.Interface;
using HomeEstate.Domains.Models.Apartment;
using HomeEstate.Domains.Models.Base;

namespace HomeEstate.BusinessLogic.Functions.Apartments
{
    public class ApartmentFlow : ApartmentAction, IApartment
    {
        public List<ApartmentDto> GetAllApartmentsAction()
        {
            return ExecuteGetAllApartmentsAction();
        }

        public ApartmentDto GetApartmentByIdAction(int id)
        {
            return GetApartmentDataByIdAction(id);
        }

        public ResponceMsg ResponceApartmentCreateAction(ApartmentDto apartment)
        {
            return ExecuteApartmentCreateAction(apartment);
        }

        public ResponceMsg ResponceApartmentUpdateAction(ApartmentDto apartment)
        {
            return ExecuteApartmentUpdateAction(apartment);
        }

        public ResponceMsg ResponceApartmentDeleteAction(int id)
        {
            return ExecuteApartmentDeleteAction(id);
        }
    }
}
