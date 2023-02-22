using ZadatakAPI.Models;

namespace ZadatakAPI.Core
{
    public interface IProizvodRepository
    {
        IEnumerable<Proizvod> GetAllProizvod();
        Proizvod GetProizvodById(int Id);
        Proizvod GetProizvodBySifra(string Sifra);
        Proizvod GetProizvodByNaziv(string Naziv);
        void CreateProizvod(Proizvod proizvod);
        void UpdateProizvod(Proizvod proizvod);
        void DeleteProizvod(Proizvod proizvod);
    }
}
