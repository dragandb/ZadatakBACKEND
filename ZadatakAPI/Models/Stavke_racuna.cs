using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ZadatakAPI.Models
{
    
    public class Stavke_racuna
    {
        public int Id { get; set; }
        public int Kolicina { get; set; }
        public decimal Cijena { get; set; }
        public int Popust { get; set; }
        public decimal Iznos_popusta { get; set; }
        public decimal Vrijednost { get; set; }

        [ForeignKey(nameof(Proizvod))]
        public int ProizvodId { get; set; }
        public Proizvod? Proizvod { get; set; }

        [ForeignKey(nameof(Zaglavlje_Racuna))]
        public int RacunId { get; set; }
        public Zaglavlje_racuna? Zaglavlje_Racuna { get; set; }

    }
}
