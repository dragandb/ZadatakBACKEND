using ZadatakAPI.Data;
using ZadatakAPI.Models;

namespace ZadatakAPI.Core.Repositories
{
    public class KupacRepository : RepositoryBase<Kupac>, IKupacRepository
    {
        public KupacRepository(ZadatakAPIDBContext repositoryContext) : base(repositoryContext)
        {
        }

        public IEnumerable<Kupac> GetAllKupac()
        {
            return FindAll().OrderBy(x => x.Id).ToList();
        }

        public Kupac GetKupacById(int Id)
        {
            return FindByCondition(x => x.Id.Equals(Id))
            .FirstOrDefault();
        }
        public Kupac GetKupacBezID(int Id)
        {
            return FindByCondition(x => x.Id.Equals(Id))
            .FirstOrDefault();
        }
    }
}
