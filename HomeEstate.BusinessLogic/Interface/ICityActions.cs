using HomeEstate.Domains.Models.Base;
using HomeEstate.Domains.Models.City;
namespace HomeEstate.BusinessLogic.Interface
{
    public interface ICityActions
    {
        List<CityDto> GetAll();
        ResponceMsg Create(CityDto city);
        ResponceMsg Delete(int id);
    }
}
