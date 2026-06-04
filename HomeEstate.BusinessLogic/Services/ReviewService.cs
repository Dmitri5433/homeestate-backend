using System;
using System.Collections.Generic;
using System.Linq;
using HomeEstate.BusinessLogic.Interface;
using HomeEstate.DataAccess.Context;
using HomeEstate.Domains.Entities.Apartment;
using HomeEstate.Domains.Models.Apartment;
using HomeEstate.Domains.Models.Base;
using Microsoft.EntityFrameworkCore;

namespace HomeEstate.BusinessLogic.Services
{
    public class ReviewService : IReviewService
    {
        private readonly DbSession _db;

        public ReviewService(DbSession db)
        {
            _db = db;
        }

        public List<ReviewDto> GetByApartment(int apartmentId)
        {
            return _db.Reviews
                .Include(r => r.User)
                .Where(r => r.ApartmentId == apartmentId)
                .OrderByDescending(r => r.CreatedAt)
                .Select(r => new ReviewDto
                {
                    Id = r.Id,
                    Text = r.Text,
                    Rating = r.Rating,
                    UserName = r.User.UserName,
                    CreatedAt = r.CreatedAt,
                    ApartmentId = r.ApartmentId
                })
                .ToList();
        }

        public ResponseMessage Create(CreateReviewDto dto, int userId)
        {
            if (string.IsNullOrWhiteSpace(dto.Text))
                return new ResponseMessage { IsSuccess = false, Message = "Текст отзыва не может быть пустым." };

            if (dto.Rating < 1 || dto.Rating > 5)
                return new ResponseMessage { IsSuccess = false, Message = "Оценка должна быть от 1 до 5." };

            var apartment = _db.Apartments.FirstOrDefault(a => a.Id == dto.ApartmentId);
            if (apartment == null)
                return new ResponseMessage { IsSuccess = false, Message = "Квартира не найдена." };

            var review = new ReviewData
            {
                Text = dto.Text,
                Rating = dto.Rating,
                ApartmentId = dto.ApartmentId,
                UserId = userId,
                CreatedAt = DateTime.UtcNow
            };

            _db.Reviews.Add(review);
            _db.SaveChanges();

            return new ResponseMessage { IsSuccess = true, Message = "Отзыв успешно добавлен." };
        }
    }
}
