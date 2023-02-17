using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ZadatakAPI.Models
{
    
    public class Stavke_racuna
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Kolicina { get; set; }

        [Required]
        public decimal Cijena { get; set; }

        [Required]
        public decimal Popust { get; set; }

        [Required]
        public decimal Iznos_popusta { get; set; }

        [Required]
        public decimal Vrijednost { get; set; }

        [ForeignKey(nameof(Proizvod))]
        public int ProizvodId { get; set; }
        public Proizvod? Proizvod { get; set; }

        [ForeignKey(nameof(Zaglavlje_Racuna))]
        public int RacunId { get; set; }
        public Zaglavlje_racuna? Zaglavlje_Racuna { get; set; }

    }
}
