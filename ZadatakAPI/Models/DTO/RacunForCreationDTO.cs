using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZadatakAPI.Models.DTO
{
    public class RacunForCreationDTO
    {
        public string Broj { get; set; }
        public DateTime Datum { get; set; }
        public string? Napomena { get; set; }

        public int KupacId { get; set; }

    }
}
