using ZadatakAPI.Models;

namespace ZadatakAPI.Core
{
    public interface IProizvodRepository
    {
        IEnumerable<Proizvod> GetAllProizvod();
        Proizvod GetProizvodById(int Id);
        Proizvod GetProizvodBezID(int Id);
        void CreateProizvod(Proizvod kupac);
        void UpdateProizvod(Proizvod kupac);
        void DeleteProizvod(Proizvod kupac);
    }
}
