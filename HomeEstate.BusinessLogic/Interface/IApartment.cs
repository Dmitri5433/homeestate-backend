using HomeEstate.Domains.Models.Apartment;
using HomeEstate.Domains.Models.Base;
namespace HomeEstate.BusinessLogic.Interface
{
    public interface IApartment
    {
        List<ApartmentDto> GetAll();
        ApartmentDto? GetById(int id);
        ResponceMsg Create(ApartmentDto apartment);
        ResponceMsg Update(ApartmentDto apartment);
        ResponceMsg Delete(int id);
    }
}
