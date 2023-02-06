using System.ComponentModel.DataAnnotations;

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
    }
}
