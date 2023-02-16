using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace ZadatakAPI.Models.DTO
{
    public class StavkaDTO
    {
        public int Id { get; set; }
        public int Kolicina { get; set; }
        public decimal Cijena { get; set; }
        public decimal Popust { get; set; }
        public decimal Iznos_popusta { get; set; }
        public decimal Vrijednost { get; set; }

    }
}
