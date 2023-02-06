using ZadatakAPI.Models;

namespace ZadatakAPI.Core
{
    public interface IKupacRepository
    {
        IEnumerable<Kupac> GetAllKupac();
        Kupac GetKupacById(int Id);
        Kupac GetKupacBezID(int Id);
        void CreateKupac(Kupac kupac);
        void UpdateKupac(Kupac kupac);
        void DeleteKupac(Kupac kupac);
    }
}
