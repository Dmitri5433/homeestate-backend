using HomeEstate.Domains.Models.Apartment;
using HomeEstate.Domains.Models.Base;
namespace HomeEstate.BusinessLogic.Interface
{
    public interface IApartmentService
    {
        List<ApartmentDto> GetAll();
        ApartmentDto GetById(int id);
        ResponseMessage Create(ApartmentDto apartment);
        ResponseMessage Update(ApartmentDto apartment);
        ResponseMessage Delete(int id);
    }
}
