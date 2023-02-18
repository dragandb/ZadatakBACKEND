using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;

namespace ZadatakAPI.Models
{
    [Index(nameof(Sifra), IsUnique = true)]
    public class Proizvod
    {
        public int Id { get; set; }
        public string Sifra { get; set; }
        public string? Naziv { get; set; }
        public string? Jedinica_mjere { get; set; }
        public decimal Cijena { get; set; }
        public string? Stanje { get; set; }

        public ICollection<Stavke_racuna>? Stavke { get; set; }
    }
}
