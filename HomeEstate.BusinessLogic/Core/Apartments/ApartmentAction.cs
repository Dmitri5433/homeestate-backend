using HomeEstate.DataAccess.Context;
using HomeEstate.Domains.Entities.Apartment;
using HomeEstate.Domains.Enums;
using HomeEstate.Domains.Models.Apartment;
using HomeEstate.Domains.Models.Base;
using Microsoft.EntityFrameworkCore;

namespace HomeEstate.BusinessLogic.Core.Apartments
{
    public class ApartmentAction
    {
        protected readonly DbSession _db;

        public ApartmentAction(DbSession db)
        {
            _db = db;
        }

        private ApartmentDto MapToDto(ApartmentData a)
        {
            return new ApartmentDto
            {
                Id       = a.Id,
                Name     = a.Name,
                City     = a.City?.Name ?? "",
                Category = a.Category,
                Rooms    = a.Rooms,
                Area     = a.Area,
                Price    = a.Price,
                ImageUrl = a.ImageUrl,
                Images   = a.Images?.Select(img => img.Url).ToList() ?? new List<string>()
            };
        }

        private ApartmentData MapToEntity(ApartmentDto dto)
        {
            return new ApartmentData
            {
                Id       = dto.Id,
                Name     = dto.Name,
                Category = dto.Category,
                Rooms    = dto.Rooms,
                Area     = dto.Area,
                Price    = dto.Price,
                ImageUrl = dto.ImageUrl
            };
        }

        protected List<ApartmentDto> ExecuteGetAllApartmentsAction()
        {
            return _db.Apartments.ToList().Select(MapToDto).ToList();
        }

        protected ApartmentDto? GetApartmentDataByIdAction(int id)
        {
            var a = _db.Apartments.FirstOrDefault(x => x.Id == id);
            if (a == null) return null;
            return MapToDto(a);
        }

        protected ResponceMsg ExecuteApartmentCreateAction(ApartmentDto apartment)
        {
            var existing = _db.Apartments.FirstOrDefault(x => x.Name == apartment.Name);
            if (existing != null)
                return new ResponceMsg { IsSuccess = false, Message = "An apartment with this name already exists." };

            var city = _db.Cities.FirstOrDefault(x => x.Name == apartment.City);
            if (city == null)
            {
                city = new HomeEstate.Domains.Entities.City.CityData { Name = apartment.City };
                _db.Cities.Add(city);
                _db.SaveChanges();
            }

            var newApartment = MapToEntity(apartment);
            newApartment.CityId    = city.Id;
            newApartment.Status    = ApartmentStatus.Available;
            newApartment.CreatedAt = DateTime.UtcNow;
            newApartment.UpdatedAt = DateTime.UtcNow;

            _db.Apartments.Add(newApartment);
            _db.SaveChanges();
            return new ResponceMsg { IsSuccess = true, Message = "Apartment was successfully created." };
        }

        protected ResponceMsg ExecuteApartmentUpdateAction(ApartmentDto apartment)
        {
            var existing = _db.Apartments.FirstOrDefault(x => x.Id == apartment.Id);
            if (existing == null)
                return new ResponceMsg { IsSuccess = false, Message = "Apartment not found." };

            existing.Name      = apartment.Name;
            existing.Category  = apartment.Category;
            existing.Rooms     = apartment.Rooms;
            existing.Area      = apartment.Area;
            existing.Price     = apartment.Price;
            existing.ImageUrl  = apartment.ImageUrl;
            existing.UpdatedAt = DateTime.UtcNow;

            _db.SaveChanges();
            return new ResponceMsg { IsSuccess = true, Message = "Apartment updated successfully." };
        }

        protected ResponceMsg ExecuteApartmentDeleteAction(int id)
        {
            var existing = _db.Apartments.FirstOrDefault(x => x.Id == id);
            if (existing == null)
                return new ResponceMsg { IsSuccess = false, Message = "Apartment not found." };

            _db.Apartments.Remove(existing);
            _db.SaveChanges();
            return new ResponceMsg { IsSuccess = true, Message = "Apartment deleted successfully." };
        }
    }
}