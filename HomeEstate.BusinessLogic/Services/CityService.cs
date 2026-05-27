using HomeEstate.BusinessLogic.Interface;
using HomeEstate.DataAccess.Context;
using HomeEstate.Domains.Entities.City;
using HomeEstate.Domains.Models.Base;
using HomeEstate.Domains.Models.City;

namespace HomeEstate.BusinessLogic.Services
{
    public class CityService : ICityService
    {
        private readonly DbSession _db;

        public CityService(DbSession db)
        {
            _db = db;
        }

        public List<CityDto> GetAll()
        {
            return _db.Cities.Select(c => new CityDto { Id = c.Id, Name = c.Name }).ToList();
        }

        public ResponseMessage Create(CityDto city)
        {
            var existing = _db.Cities.FirstOrDefault(c => c.Name == city.Name);
            if (existing != null)
                return new ResponseMessage { IsSuccess = false, Message = "City already exists." };

            _db.Cities.Add(new CityData { Name = city.Name });
            _db.SaveChanges();
            return new ResponseMessage { IsSuccess = true, Message = "City created successfully." };
        }

        public ResponseMessage Delete(int id)
        {
            var city = _db.Cities.FirstOrDefault(c => c.Id == id);
            if (city == null)
                return new ResponseMessage { IsSuccess = false, Message = "City not found." };

            _db.Cities.Remove(city);
            _db.SaveChanges();
            return new ResponseMessage { IsSuccess = true, Message = "City deleted successfully." };
        }
    }
}
