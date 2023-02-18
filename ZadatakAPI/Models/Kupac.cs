using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace ZadatakAPI.Models
{
    [Index(nameof(Sifra), IsUnique = true)]
    public class Kupac
    {
        public int Id { get; set; }
        public string Sifra { get; set; }
        public string? Naziv { get; set; }
        public string? Adresa { get; set; }
        public string? Mjesto { get; set; }

        public ICollection<Zaglavlje_racuna>? Racuni { get; set; }
    }
}
