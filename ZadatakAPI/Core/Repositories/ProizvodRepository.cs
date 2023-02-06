using ZadatakAPI.Data;
using ZadatakAPI.Models;

namespace ZadatakAPI.Core.Repositories
{
    public class ProizvodRepository : RepositoryBase<Proizvod>, IProizvodRepository
    {
        public ProizvodRepository(ZadatakAPIDBContext repositoryContext) : base(repositoryContext)
        {
        }

        public IEnumerable<Proizvod> GetAllProizvod()
        {
            return FindAll().OrderBy(x => x.Id).ToList();
        }

        public Proizvod GetProizvodById(int Id)
        {
            return FindByCondition(x => x.Id.Equals(Id))
            .FirstOrDefault();
        }
        public Proizvod GetProizvodBezID(int Id)
        {
            return FindByCondition(x => x.Id.Equals(Id))
            .FirstOrDefault();
        }

        public void CreateProizvod(Proizvod Proizvod)
        {
            Create(Proizvod);
        }

        public void UpdateProizvod(Proizvod Proizvod)
        {
            Update(Proizvod);
        }
        public void DeleteProizvod(Proizvod Proizvod)
        {
            Delete(Proizvod);
        }
    }
}
