using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ZadatakAPI.Models.DTO
{
    [Index(nameof(Sifra), IsUnique = true)]
    public class ProizvodDTO
    {
        public int Id { get; set; }
        public string Sifra { get; set; }
        public string? Naziv { get; set; }
        public string? Jedinica_mjere { get; set; }
        public decimal Cijena { get; set; }
        public int? Stanje { get; set; }

        public ICollection<StavkaDTO>? Stavke { get; set; }
    }
}
