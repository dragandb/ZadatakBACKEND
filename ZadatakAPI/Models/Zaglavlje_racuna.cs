using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ZadatakAPI.Models
{
    [Index(nameof(Broj), IsUnique = true)]
    public class Zaglavlje_racuna
    {
        [Key]
        public int RacunID { get; set; }

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
