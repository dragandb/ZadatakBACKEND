using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZadatakAPI.Models.DTO
{
    public class RacunForCreationDTO
    {
        [Required]
        [StringLength(255)]
        public string Broj { get; set; }

        [Required]
        public DateTime Datum { get; set; }

        [Required]
        [StringLength(255)]
        public string Napomena { get; set; }

        [Required]
        [ForeignKey("Kupac")]
        public int KupacID { get; set; }

        public virtual Kupac Kupac { get; set; }
    }
}
