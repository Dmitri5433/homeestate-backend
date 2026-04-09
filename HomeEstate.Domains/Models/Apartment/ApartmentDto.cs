namespace HomeEstate.Domains.Models.Apartment
{
    public class ApartmentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Category { get; set; }
        public int Rooms { get; set; }
        public double Area { get; set; }
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
    }
}
