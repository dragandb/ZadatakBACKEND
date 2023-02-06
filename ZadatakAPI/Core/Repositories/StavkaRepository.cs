using ZadatakAPI.Data;
using ZadatakAPI.Models;

namespace ZadatakAPI.Core.Repositories
{
    public class StavkaRepository : RepositoryBase<Stavke_racuna>, IStavkaRepository
    {
        public StavkaRepository(ZadatakAPIDBContext repositoryContext) : base(repositoryContext)
        {
        }

        public IEnumerable<Stavke_racuna> GetAllStavka()
        {
            return FindAll().OrderBy(x => x.Id).ToList();
        }

        public Stavke_racuna GetStavkaById(int Id)
        {
            return FindByCondition(x => x.Id.Equals(Id))
            .FirstOrDefault();
        }
        public Stavke_racuna GetStavkaBezID(int Id)
        {
            return FindByCondition(x => x.Id.Equals(Id))
            .FirstOrDefault();
        }

        public void CreateStavka(Stavke_racuna stavka)
        {
            Create(stavka);
        }

        public void UpdateStavka(Stavke_racuna stavka)
        {
            Update(stavka);
        }
        public void DeleteStavka(Stavke_racuna stavka)
        {
            Delete(stavka);
        }
    }
}
