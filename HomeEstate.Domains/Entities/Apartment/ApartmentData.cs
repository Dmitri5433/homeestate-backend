using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HomeEstate.Domains.Entities.Refs;
using HomeEstate.Domains.Enums;

namespace HomeEstate.Domains.Entities.Apartment
{
    public class ApartmentData : SharedFields
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        public string Category { get; set; }

        public int Rooms { get; set; }

        public double Area { get; set; }

        public decimal Price { get; set; }

        public string? ImageUrl { get; set; }

        public ApartmentStatus Status { get; set; }

        public int CityId { get; set; }

        [ForeignKey("CityId")]
        public City.CityData City { get; set; }

        public ApartmentDescriptionData? Description { get; set; }

        [InverseProperty("Apartment")]
        public List<ApartmentImageData> Images { get; set; }
    }
}
