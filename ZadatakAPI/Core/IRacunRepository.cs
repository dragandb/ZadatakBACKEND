using ZadatakAPI.Models;

namespace ZadatakAPI.Core
{
    public interface IRacunRepository
    {
        IEnumerable<Zaglavlje_racuna> GetAllRacun();
        Zaglavlje_racuna GetRacunById(int Id);
        Zaglavlje_racuna GetRacunBezID(int Id);
        void CreateRacun(Zaglavlje_racuna racun);
        void UpdateRacun(Zaglavlje_racuna racun);
        void DeleteRacun(Zaglavlje_racuna racun);
    }
}
