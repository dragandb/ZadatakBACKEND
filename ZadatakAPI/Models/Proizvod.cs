using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZadatakAPI.Models
{
    [Index(nameof(Sifra), IsUnique = true)]
    public class Proizvod
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
        [StringLength(20)]
        public string Jedinica_mjere { get; set; }

        [Required]
        public decimal Cijena { get; set; }

        [Required]
        [StringLength(20)]
        public string Stanje { get; set; }
    }
}
