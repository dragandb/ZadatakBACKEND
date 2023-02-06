using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace ZadatakAPI.Models.DTO
{
    public class StavkaDTO
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

        [Required]
        [ForeignKey("Proizvod")]
        public int ProizvodID { get; set; }

        public virtual Proizvod Proizvod { get; set; }

        [Required]
        [ForeignKey("Zaglavlje_racuna")]
        public int RacunID { get; set; }

        public virtual Zaglavlje_racuna Zaglavlje_racuna { get; set; }
    }
}
