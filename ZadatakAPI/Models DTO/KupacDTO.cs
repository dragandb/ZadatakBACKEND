using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ZadatakAPI.Models_DTO
{
    [Index(nameof(Sifra), IsUnique = true)]
    public class KupacDTO
    {
        [Required]
        [StringLength(50)]
        public string Sifra { get; set; }

        [Required]
        [StringLength(50)]
        public string Naziv { get; set; }

        [Required]
        [StringLength(255)]
        public string Adresa { get; set; }

        [Required]
        [StringLength(255)]
        public string Mjesto { get; set; }
    }
}
