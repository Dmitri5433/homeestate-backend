using HomeEstate.Domains.Models.Base;
using HomeEstate.Domains.Models.City;
namespace HomeEstate.BusinessLogic.Interface
{
    public interface ICityService
    {
        List<CityDto> GetAll();
        ResponseMessage Create(CityDto city);
        ResponseMessage Delete(int id);
    }
}
