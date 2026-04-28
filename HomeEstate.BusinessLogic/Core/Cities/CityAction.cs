using HomeEstate.DataAccess.Context;
using HomeEstate.Domains.Entities.City;
using HomeEstate.Domains.Models.Base;
using HomeEstate.Domains.Models.City;

namespace HomeEstate.BusinessLogic.Core.Cities
{
    public class CityAction
    {
        protected List<CityDto> ExecuteGetAllCitiesAction()
        {
            using (var db = new ApartmentContext())
            {
                return db.Cities.Select(c => new CityDto { Id = c.Id, Name = c.Name }).ToList();
            }
        }

        protected ResponceMsg ExecuteCreateCityAction(CityDto city)
        {
            using (var db = new ApartmentContext())
            {
                var existing = db.Cities.FirstOrDefault(c => c.Name == city.Name);
                if (existing != null)
                    return new ResponceMsg { IsSuccess = false, Message = "City already exists." };

                db.Cities.Add(new CityData { Name = city.Name });
                db.SaveChanges();
            }
            return new ResponceMsg { IsSuccess = true, Message = "City created successfully." };
        }

        protected ResponceMsg ExecuteDeleteCityAction(int id)
        {
            using (var db = new ApartmentContext())
            {
                var city = db.Cities.FirstOrDefault(c => c.Id == id);
                if (city == null)
                    return new ResponceMsg { IsSuccess = false, Message = "City not found." };

                db.Cities.Remove(city);
                db.SaveChanges();
            }
            return new ResponceMsg { IsSuccess = true, Message = "City deleted successfully." };
        }
    }
}
