using System.Collections.Generic;

namespace HomeEstate.Domains.Models.Apartment
{
    public class ApartmentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CityId { get; set; }
        public string City { get; set; }
        public string Category { get; set; }
        public int Rooms { get; set; }
        public double Area { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public List<string> Images { get; set; } = new List<string>();

        // Расширенное описание
        public string Description { get; set; }
        public string District { get; set; }
        public int Floor { get; set; }
        public int Entrance { get; set; }
        public int TotalFloors { get; set; }
        public bool HasParking { get; set; }
        public bool HasElevator { get; set; }

        // Отзывы
        public List<ReviewDto> Reviews { get; set; } = new List<ReviewDto>();
    }
}
