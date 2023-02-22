using ZadatakAPI.Models;

namespace ZadatakAPI.Core
{
    public interface IKupacRepository
    {
        IEnumerable<Kupac> GetAllKupac();
        Kupac GetKupacById(int Id);
        Kupac GetKupacBySifra(string Sifra);
        Kupac GetKupacByNaziv(string Naziv);
        void CreateKupac(Kupac kupac);
        void UpdateKupac(Kupac kupac);
        void DeleteKupac(Kupac kupac);
    }
}
