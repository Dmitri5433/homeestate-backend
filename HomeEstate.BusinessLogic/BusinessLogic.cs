using HomeEstate.BusinessLogic.Functions.Apartments;
using HomeEstate.BusinessLogic.Functions.Auth;
using HomeEstate.BusinessLogic.Interface;

namespace HomeEstate.BusinessLogic
{
    public class BusinessLogic
    {
        public BusinessLogic() { }
        public IApartment GetApartmentActions() => new ApartmentFlow();
        public IAuthActions GetAuthActions() => new AuthFlow();
    }
}
