using HomeEstate.BusinessLogic.Functions.Apartments;
using HomeEstate.BusinessLogic.Interface;

namespace HomeEstate.BusinessLogic
{
    public class BusinessLogic
    {
        public BusinessLogic() { }

        public IApartment GetApartmentActions()
        {
            return new ApartmentFlow();
        }
    }
}
