using System.ComponentModel.DataAnnotations;

namespace ZadatakAPI.Models.DTO
{
    public class RacunForUpdateDTO
    {
        public string Broj { get; set; }
        public DateTime Datum { get; set; }
        public string? Napomena { get; set; }

        public int KupacId { get; set; }
    }
}
