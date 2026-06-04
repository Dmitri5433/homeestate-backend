using System;

namespace HomeEstate.Domains.Models.Apartment
{
    public class ReviewDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int Rating { get; set; }
        public string UserName { get; set; }
        public DateTime CreatedAt { get; set; }
        public int ApartmentId { get; set; }
    }

    public class CreateReviewDto
    {
        public string Text { get; set; }
        public int Rating { get; set; }
        public int ApartmentId { get; set; }
    }
}
