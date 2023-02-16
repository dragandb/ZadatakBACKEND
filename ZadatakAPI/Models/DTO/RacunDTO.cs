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
        public string Napomena { get; set; }

    }
}
