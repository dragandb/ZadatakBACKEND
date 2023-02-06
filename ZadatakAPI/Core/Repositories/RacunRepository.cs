using ZadatakAPI.Data;
using ZadatakAPI.Models;

namespace ZadatakAPI.Core.Repositories
{
    public class RacunRepository : RepositoryBase<Zaglavlje_racuna>, IRacunRepository
    {
        public RacunRepository(ZadatakAPIDBContext repositoryContext) : base(repositoryContext)
        {
        }
        public IEnumerable<Zaglavlje_racuna> GetAllRacun()
        {
            return FindAll().OrderBy(x => x.Id).ToList();
        }

        public Zaglavlje_racuna GetRacunById(int Id)
        {
            return FindByCondition(x => x.Id.Equals(Id))
            .FirstOrDefault();
        }
        public Zaglavlje_racuna GetRacunBezID(int Id)
        {
            return FindByCondition(x => x.Id.Equals(Id))
            .FirstOrDefault();
        }

        public void CreateRacun(Zaglavlje_racuna racun)
        {
            Create(racun);
        }

        public void UpdateRacun(Zaglavlje_racuna racun)
        {
            Update(racun);
        }
        public void DeleteRacun(Zaglavlje_racuna racun)
        {
            Delete(racun);
        }
    }
}
