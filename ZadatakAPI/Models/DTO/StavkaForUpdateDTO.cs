using System.ComponentModel.DataAnnotations;

namespace ZadatakAPI.Models.DTO
{
    public class StavkaForUpdateDTO
    {
        public int Kolicina { get; set; }
        public decimal Cijena { get; set; }
        public int Popust { get; set; }
        public decimal Iznos_popusta { get; set; }
        public decimal Vrijednost { get; set; }

        public int ProizvodId { get; set; }

        public int RacunId { get; set; }
    }
}
