using System.ComponentModel.DataAnnotations;

namespace ZadatakAPI.Models.DTO
{
    public class StavkaForCreationDTO
    {
        [Required]
        public int Kolicina { get; set; }

        [Required]
        public decimal Cijena { get; set; }

        [Required]
        public decimal Popust { get; set; }

        [Required]
        public decimal Iznos_popusta { get; set; }

        [Required]
        public decimal Vrijednost { get; set; }
    }
}
