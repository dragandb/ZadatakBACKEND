using ZadatakAPI.Models;

namespace ZadatakAPI.Core
{
    public interface IStavkaRepository
    {
        IEnumerable<Stavke_racuna> GetAllStavka();
        Stavke_racuna GetStavkaById(int Id);
        Stavke_racuna GetStavkaBezID(int Id);
        void CreateStavka(Stavke_racuna stavka);
        void UpdateStavka(Stavke_racuna stavka);
        void DeleteStavka(Stavke_racuna stavka);
    }
}
