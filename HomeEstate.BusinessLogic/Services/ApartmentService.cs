using System;
using System.Collections.Generic;
using System.Linq;
using HomeEstate.BusinessLogic.Interface;
using HomeEstate.DataAccess.Context;
using HomeEstate.Domains.Entities.Apartment;
using HomeEstate.Domains.Enums;
using HomeEstate.Domains.Models.Apartment;
using HomeEstate.Domains.Models.Base;
using Microsoft.EntityFrameworkCore;

namespace HomeEstate.BusinessLogic.Services
{
    public class ApartmentService : IApartmentService
    {
        private readonly DbSession _db;

        public ApartmentService(DbSession db)
        {
            _db = db;
        }

        private ApartmentDto MapToDto(ApartmentData a)
        {
            return new ApartmentDto
            {
                Id = a.Id,
                Name = a.Name,
                City = a.City?.Name ?? "",
                Category = a.Category,
                Rooms = a.Rooms,
                Area = a.Area,
                Price = a.Price,
                ImageUrl = a.ImageUrl,
                Images = a.Images?.Select(img => img.Url).ToList() ?? new List<string>(),

                // Расширенное описание
                Description = a.Description?.Description ?? "",
                District = a.Description?.District ?? "",
                Floor = a.Description?.Floor ?? 0,
                Entrance = a.Description?.Entrance ?? 0,
                TotalFloors = a.Description?.TotalFloors ?? 0,
                HasParking = a.Description?.HasParking ?? false,
                HasElevator = a.Description?.HasElevator ?? false,

                // Отзывы
                Reviews = a.Reviews?
                    .OrderByDescending(r => r.CreatedAt)
                    .Select(r => new ReviewDto
                    {
                        Id = r.Id,
                        Text = r.Text,
                        Rating = r.Rating,
                        UserName = r.User?.UserName ?? "",
                        CreatedAt = r.CreatedAt,
                        ApartmentId = r.ApartmentId
                    }).ToList() ?? new List<ReviewDto>()
            };
        }

        private ApartmentData MapToEntity(ApartmentDto dto)
        {
            return new ApartmentData
            {
                Id = dto.Id,
                Name = dto.Name,
                Category = dto.Category,
                Rooms = dto.Rooms,
                Area = dto.Area,
                Price = dto.Price,
                ImageUrl = dto.ImageUrl
            };
        }

        public List<ApartmentDto> GetAll()
        {
            return _db.Apartments
                .Include(a => a.City)
                .Include(a => a.Images)
                .Include(a => a.Description)
                .ToList()
                .Select(MapToDto)
                .ToList();
        }

        public ApartmentDto GetById(int id)
        {
            var a = _db.Apartments
                .Include(x => x.City)
                .Include(x => x.Images)
                .Include(x => x.Description)
                .Include(x => x.Reviews).ThenInclude(r => r.User)
                .FirstOrDefault(x => x.Id == id);
            if (a == null) return null;
            return MapToDto(a);
        }

        public ResponseMessage Create(ApartmentDto apartment)
        {
            var existing = _db.Apartments.FirstOrDefault(x => x.Name == apartment.Name);
            if (existing != null)
                return new ResponseMessage { IsSuccess = false, Message = "An apartment with this name already exists." };

            var city = _db.Cities.FirstOrDefault(x => x.Name == apartment.City);
            if (city == null)
            {
                city = new HomeEstate.Domains.Entities.City.CityData { Name = apartment.City };
                _db.Cities.Add(city);
                _db.SaveChanges();
            }

            var newApartment = MapToEntity(apartment);
            newApartment.CityId = city.Id;
            newApartment.Status = ApartmentStatus.Available;
            newApartment.CreatedAt = DateTime.UtcNow;
            newApartment.UpdatedAt = DateTime.UtcNow;

            _db.Apartments.Add(newApartment);
            _db.SaveChanges();

            // Сохраняем описание
            var desc = new ApartmentDescriptionData
            {
                ApartmentId = newApartment.Id,
                Description = apartment.Description ?? "",
                District = apartment.District ?? "",
                Floor = apartment.Floor,
                Entrance = apartment.Entrance,
                TotalFloors = apartment.TotalFloors,
                HasParking = apartment.HasParking,
                HasElevator = apartment.HasElevator
            };
            _db.ApartmentDescriptions.Add(desc);
            _db.SaveChanges();

            return new ResponseMessage { IsSuccess = true, Message = "Apartment was successfully created." };
        }

        public ResponseMessage Update(ApartmentDto apartment)
        {
            var existing = _db.Apartments
                .Include(a => a.Description)
                .FirstOrDefault(x => x.Id == apartment.Id);
            if (existing == null)
                return new ResponseMessage { IsSuccess = false, Message = "Apartment not found." };

            existing.Name = apartment.Name;
            existing.Category = apartment.Category;
            existing.Rooms = apartment.Rooms;
            existing.Area = apartment.Area;
            existing.Price = apartment.Price;
            existing.ImageUrl = apartment.ImageUrl;
            existing.UpdatedAt = DateTime.UtcNow;

            // Обновляем описание
            if (existing.Description == null)
            {
                existing.Description = new ApartmentDescriptionData { ApartmentId = existing.Id };
                _db.ApartmentDescriptions.Add(existing.Description);
            }
            existing.Description.Description = apartment.Description ?? "";
            existing.Description.District = apartment.District ?? "";
            existing.Description.Floor = apartment.Floor;
            existing.Description.Entrance = apartment.Entrance;
            existing.Description.TotalFloors = apartment.TotalFloors;
            existing.Description.HasParking = apartment.HasParking;
            existing.Description.HasElevator = apartment.HasElevator;

            _db.SaveChanges();
            return new ResponseMessage { IsSuccess = true, Message = "Apartment updated successfully." };
        }

        public ResponseMessage Delete(int id)
        {
            var existing = _db.Apartments
                .Include(a => a.Description)
                .Include(a => a.Reviews)
                .Include(a => a.Images)
                .FirstOrDefault(x => x.Id == id);

            if (existing == null)
                return new ResponseMessage { IsSuccess = false, Message = "Apartment not found." };

            if (existing.Description != null)
                _db.ApartmentDescriptions.Remove(existing.Description);

            if (existing.Reviews != null && existing.Reviews.Any())
                _db.Reviews.RemoveRange(existing.Reviews);

            _db.Apartments.Remove(existing);
            _db.SaveChanges();
            return new ResponseMessage { IsSuccess = true, Message = "Apartment deleted successfully." };
        }
    }
}
