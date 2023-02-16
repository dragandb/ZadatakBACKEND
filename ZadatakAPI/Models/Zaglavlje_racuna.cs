using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ZadatakAPI.Models
{
    [Index(nameof(Broj), IsUnique = true)]
    public class Zaglavlje_racuna
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

        [ForeignKey(nameof(Kupac))]
        public int KupacId { get; set; }
        public Kupac? Kupac { get; set; }
    }
}
