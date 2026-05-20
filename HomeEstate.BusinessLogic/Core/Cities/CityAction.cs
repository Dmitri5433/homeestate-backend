using HomeEstate.DataAccess.Context;
using HomeEstate.Domains.Entities.City;
using HomeEstate.Domains.Models.Base;
using HomeEstate.Domains.Models.City;

namespace HomeEstate.BusinessLogic.Core.Cities
{
    public class CityAction
    {
        protected readonly DbSession _db;

        public CityAction(DbSession db)
        {
            _db = db;
        }

        protected List<CityDto> ExecuteGetAllCitiesAction()
        {
            return _db.Cities.Select(c => new CityDto { Id = c.Id, Name = c.Name }).ToList();
        }

        protected ResponceMsg ExecuteCreateCityAction(CityDto city)
        {
            var existing = _db.Cities.FirstOrDefault(c => c.Name == city.Name);
            if (existing != null)
                return new ResponceMsg { IsSuccess = false, Message = "City already exists." };

            _db.Cities.Add(new CityData { Name = city.Name });
            _db.SaveChanges();
            return new ResponceMsg { IsSuccess = true, Message = "City created successfully." };
        }

        protected ResponceMsg ExecuteDeleteCityAction(int id)
        {
            var city = _db.Cities.FirstOrDefault(c => c.Id == id);
            if (city == null)
                return new ResponceMsg { IsSuccess = false, Message = "City not found." };

            _db.Cities.Remove(city);
            _db.SaveChanges();
            return new ResponceMsg { IsSuccess = true, Message = "City deleted successfully." };
        }
    }
}