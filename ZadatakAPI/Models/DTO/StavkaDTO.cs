using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace ZadatakAPI.Models.DTO
{
    public class StavkaDTO
    {
        public int Id { get; set; }
        public int Kolicina { get; set; }
        public decimal Cijena { get; set; }
        public int Popust { get; set; }
        public decimal Iznos_popusta { get; set; }
        public decimal Vrijednost { get; set; }

        public int ProizvodId { get; set; }
        public ProizvodDTO? Proizvod { get; set; }

        public int RacunId { get; set; }
        public RacunDTO? Zaglavlje_Racuna { get; set; }

    }
}
