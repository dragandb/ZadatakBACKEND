using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ZadatakAPI.Models.DTO
{
    [Index(nameof(Sifra), IsUnique = true)]
    public class KupacDTO
    {
        public int Id { get; set; }
        public string Sifra { get; set; }
        public string Naziv { get; set; }
        public string Adresa { get; set; }
        public string Mjesto { get; set; }
    }
}
