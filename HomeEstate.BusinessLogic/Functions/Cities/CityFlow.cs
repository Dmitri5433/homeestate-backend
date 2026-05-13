using HomeEstate.BusinessLogic.Core.Cities;
using HomeEstate.BusinessLogic.Interface;
using HomeEstate.Domains.Models.Base;
using HomeEstate.Domains.Models.City;
namespace HomeEstate.BusinessLogic.Functions.Cities
{
    public class CityFlow : CityAction, ICityActions
    {
        public List<CityDto> GetAll() => ExecuteGetAllCitiesAction();
        public ResponceMsg Create(CityDto city) => ExecuteCreateCityAction(city);
        public ResponceMsg Delete(int id) => ExecuteDeleteCityAction(id);
    }
}
