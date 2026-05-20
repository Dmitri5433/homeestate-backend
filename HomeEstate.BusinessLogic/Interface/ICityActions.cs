using HomeEstate.Domains.Models.Base;
using HomeEstate.Domains.Models.City;

namespace HomeEstate.BusinessLogic.Interface
{
    public interface ICityActions
    {
        List<CityDto> GetAllCitiesAction();
        ResponceMsg CreateCityAction(CityDto city);
        ResponceMsg DeleteCityAction(int id);
    }
}
