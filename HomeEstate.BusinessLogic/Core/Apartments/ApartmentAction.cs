using AutoMapper;
using HomeEstate.DataAccess.Context;
using HomeEstate.Domains.Entities.Apartment;
using HomeEstate.Domains.Enums;
using HomeEstate.Domains.Models.Apartment;
using HomeEstate.Domains.Models.Base;

namespace HomeEstate.BusinessLogic.Core.Apartments
{
    public class ApartmentAction
    {
        protected readonly IMapper _mapper;

        public ApartmentAction()
        {
            _mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new Mapping.ApartmentProfile());
            }).CreateMapper();
        }

        protected List<ApartmentDto> ExecuteGetAllApartmentsAction()
        {
            List<ApartmentData> data;
            using (var db = new ApartmentContext())
            {
                data = db.Apartments.ToList();
            }
            return _mapper.Map<List<ApartmentDto>>(data);
        }

        protected ApartmentDto? GetApartmentDataByIdAction(int id)
        {
            using (var db = new ApartmentContext())
            {
                var a = db.Apartments.FirstOrDefault(x => x.Id == id);
                if (a == null) return null;
                return _mapper.Map<ApartmentDto>(a);
            }
        }

        protected ResponceMsg ExecuteApartmentCreateAction(ApartmentDto apartment)
        {
            using (var db = new ApartmentContext())
            {
                var existing = db.Apartments.FirstOrDefault(x => x.Name == apartment.Name && x.City == apartment.City);
                if (existing != null)
                    return new ResponceMsg { IsSuccess = false, Message = "An apartment with this name in this city already exists." };

                var newApartment = _mapper.Map<ApartmentData>(apartment);
                newApartment.Status = ApartmentStatus.Available;
                newApartment.CreatedAt = DateTime.UtcNow;
                newApartment.UpdatedAt = DateTime.UtcNow;
                db.Apartments.Add(newApartment);
                db.SaveChanges();
            }
            return new ResponceMsg { IsSuccess = true, Message = "Apartment was successfully created." };
        }

        protected ResponceMsg ExecuteApartmentUpdateAction(ApartmentDto apartment)
        {
            using (var db = new ApartmentContext())
            {
                var existing = db.Apartments.FirstOrDefault(x => x.Id == apartment.Id);
                if (existing == null)
                    return new ResponceMsg { IsSuccess = false, Message = "Apartment not found." };

                _mapper.Map(apartment, existing);
                existing.UpdatedAt = DateTime.UtcNow;
                db.SaveChanges();
            }
            return new ResponceMsg { IsSuccess = true, Message = "Apartment updated successfully." };
        }

        protected ResponceMsg ExecuteApartmentDeleteAction(int id)
        {
            using (var db = new ApartmentContext())
            {
                var existing = db.Apartments.FirstOrDefault(x => x.Id == id);
                if (existing == null)
                    return new ResponceMsg { IsSuccess = false, Message = "Apartment not found." };

                db.Apartments.Remove(existing);
                db.SaveChanges();
            }
            return new ResponceMsg { IsSuccess = true, Message = "Apartment deleted successfully." };
        }
    }
}
