using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HomeEstate.Domains.Entities.User;

namespace HomeEstate.Domains.Entities.Apartment
{
    public class ReviewData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }

        public int Rating { get; set; } // 1-5

        public DateTime CreatedAt { get; set; }

        public int ApartmentId { get; set; }

        [ForeignKey("ApartmentId")]
        public ApartmentData Apartment { get; set; }

        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public UserData User { get; set; }
    }
}
