using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ZadatakAPI.Models.DTO
{
    [Index(nameof(Broj), IsUnique = true)]
    public class RacunDTO
    {
        [Key]
        public int Id { get; set; }

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
