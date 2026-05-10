using HomeEstate.BusinessLogic.Functions.Apartments;
using HomeEstate.BusinessLogic.Functions.Auth;
using HomeEstate.BusinessLogic.Functions.Cities;
using HomeEstate.BusinessLogic.Interface;
using HomeEstate.DataAccess.Context;

namespace HomeEstate.BusinessLogic
{
    public class BusinessLogic
    {
        private readonly DbSession _dbSession;

        public BusinessLogic(DbSession dbSession)
        {
            _dbSession = dbSession;
        }

        public IApartment GetApartmentActions() => new ApartmentFlow(_dbSession);
        public IAuthActions GetAuthActions() => new AuthFlow(_dbSession);
        public ICityActions GetCityActions() => new CityFlow(_dbSession);
    }
}