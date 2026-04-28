using HomeEstate.BusinessLogic.Core.Cities;
using HomeEstate.BusinessLogic.Interface;
using HomeEstate.Domains.Models.Base;
using HomeEstate.Domains.Models.City;

namespace HomeEstate.BusinessLogic.Functions.Cities
{
    public class CityFlow : CityAction, ICityActions
    {
        public List<CityDto> GetAllCitiesAction() => ExecuteGetAllCitiesAction();
        public ResponceMsg CreateCityAction(CityDto city) => ExecuteCreateCityAction(city);
        public ResponceMsg DeleteCityAction(int id) => ExecuteDeleteCityAction(id);
    }
}
