using System.ComponentModel.DataAnnotations;

namespace ZadatakAPI.Models.DTO
{
    public class ProizvodForUpdateDTO
    {
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
