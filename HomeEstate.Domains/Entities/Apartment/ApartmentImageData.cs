using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeEstate.Domains.Entities.Apartment
{
    public class ApartmentImageData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Url { get; set; }

        public int ApartmentId { get; set; }

        [ForeignKey("ApartmentId")]
        public ApartmentData Apartment { get; set; }
    }
}
