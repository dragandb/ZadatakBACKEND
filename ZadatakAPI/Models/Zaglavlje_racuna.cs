using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ZadatakAPI.Models
{
    [Index(nameof(Broj), IsUnique = true)]
    public class Zaglavlje_racuna
    {
        public int Id { get; set; }
        public string Broj { get; set; }
        public DateTime Datum { get; set; }
        public string? Napomena { get; set; }

        public decimal? Ukupno { get; set; }
        public decimal? UkupnoPopust { get; set; }
        public decimal? Total { get; set; }

        public ICollection<Stavke_racuna>? Stavke { get; set; }

        [ForeignKey(nameof(Kupac))]
        public int KupacId { get; set; }
        public Kupac? Kupac { get; set; }
    }
}
