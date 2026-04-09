using HomeEstate.DataAccess.Context;
using HomeEstate.Domains.Entities.Apartment;
using HomeEstate.Domains.Enums;
using HomeEstate.Domains.Models.Apartment;
using HomeEstate.Domains.Models.Base;

namespace HomeEstate.BusinessLogic.Core.Apartments
{
    public class ApartmentAction
    {
        // READ ALL
        protected List<ApartmentDto> ExecuteGetAllApartmentsAction()
        {
            List<ApartmentData> data;

            using (var db = new ApartmentContext())
            {
                data = db.Apartments.ToList();
            }

            var result = new List<ApartmentDto>();
            foreach (var a in data)
            {
                result.Add(MapToDto(a));
            }

            return result;
        }

        // READ BY ID
        protected ApartmentDto GetApartmentDataByIdAction(int id)
        {
            using (var db = new ApartmentContext())
            {
                var a = db.Apartments.FirstOrDefault(x => x.Id == id);
                if (a == null)
                    return null;

                return MapToDto(a);
            }
        }

        // CREATE
        protected ResponceMsg ExecuteApartmentCreateAction(ApartmentDto apartment)
        {
            using (var db = new ApartmentContext())
            {
                var existing = db.Apartments
                    .FirstOrDefault(x => x.Name == apartment.Name && x.City == apartment.City);

                if (existing != null)
                {
                    return new ResponceMsg
                    {
                        IsSuccess = false,
                        Message = "An apartment with this name in this city already exists."
                    };
                }

                var newApartment = new ApartmentData
                {
                    Name = apartment.Name,
                    City = apartment.City,
                    Category = apartment.Category,
                    Rooms = apartment.Rooms,
                    Area = apartment.Area,
                    Price = apartment.Price,
                    ImageUrl = apartment.ImageUrl,
                    Status = ApartmentStatus.Available,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                };

                db.Apartments.Add(newApartment);
                db.SaveChanges();
            }

            return new ResponceMsg
            {
                IsSuccess = true,
                Message = "Apartment was successfully created."
            };
        }

        // UPDATE
        protected ResponceMsg ExecuteApartmentUpdateAction(ApartmentDto apartment)
        {
            using (var db = new ApartmentContext())
            {
                var existing = db.Apartments.FirstOrDefault(x => x.Id == apartment.Id);
                if (existing == null)
                {
                    return new ResponceMsg
                    {
                        IsSuccess = false,
                        Message = "Apartment not found."
                    };
                }

                existing.Name = apartment.Name;
                existing.City = apartment.City;
                existing.Category = apartment.Category;
                existing.Rooms = apartment.Rooms;
                existing.Area = apartment.Area;
                existing.Price = apartment.Price;
                existing.ImageUrl = apartment.ImageUrl;
                existing.UpdatedAt = DateTime.UtcNow;

                db.SaveChanges();
            }

            return new ResponceMsg
            {
                IsSuccess = true,
                Message = "Apartment updated successfully."
            };
        }

        // DELETE
        protected ResponceMsg ExecuteApartmentDeleteAction(int id)
        {
            using (var db = new ApartmentContext())
            {
                var existing = db.Apartments.FirstOrDefault(x => x.Id == id);
                if (existing == null)
                {
                    return new ResponceMsg
                    {
                        IsSuccess = false,
                        Message = "Apartment not found."
                    };
                }

                db.Apartments.Remove(existing);
                db.SaveChanges();
            }

            return new ResponceMsg
            {
                IsSuccess = true,
                Message = "Apartment deleted successfully."
            };
        }

        // MAPPER
        private ApartmentDto MapToDto(ApartmentData a)
        {
            return new ApartmentDto
            {
                Id = a.Id,
                Name = a.Name,
                City = a.City,
                Category = a.Category,
                Rooms = a.Rooms,
                Area = a.Area,
                Price = a.Price,
                ImageUrl = a.ImageUrl
            };
        }
    }
}
