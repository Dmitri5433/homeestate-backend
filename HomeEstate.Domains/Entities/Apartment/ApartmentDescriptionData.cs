using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeEstate.Domains.Entities.Apartment
{
    public class ApartmentDescriptionData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(500)]
        public string? FullDescription { get; set; }

        public string? Address { get; set; }

        public int YearBuilt { get; set; }

        public bool HasParking { get; set; }

        public bool HasElevator { get; set; }

        public int ApartmentId { get; set; }

        [ForeignKey("ApartmentId")]
        public ApartmentData Apartment { get; set; }
    }
}
