using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ZadatakAPI.Models
{
    [Index(nameof(Sifra), IsUnique = true)]
    public class Kupac
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Sifra { get; set; }

        [Required]
        [StringLength(50)]
        public string Naziv { get; set; }

        [Required]
        [StringLength(100)]
        public string Adresa { get; set; }

        [Required]
        [StringLength(100)]
        public string Mjesto { get; set; }
    }
}
