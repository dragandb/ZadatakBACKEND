using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ZadatakAPI.Models.DTO
{
    [Index(nameof(Broj), IsUnique = true)]
    public class RacunDTO
    {
        public int Id { get; set; }
        public string Broj { get; set; }
        public DateTime Datum { get; set; }
        public string? Napomena { get; set; }
        public decimal? Ukupno { get; set; }
        public decimal? UkupnoPopust { get; set; }
        public decimal? Total { get; set; }

        public ICollection<StavkaDTO>? Stavke { get; set; }

        public int KupacId { get; set; }
        public KupacDTO? Kupac { get; set; }
    }
}
