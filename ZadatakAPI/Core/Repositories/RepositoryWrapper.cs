using ZadatakAPI.Data;

namespace ZadatakAPI.Core.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private ZadatakAPIDBContext _repoContext;
        private IKupacRepository _kupac;
        private IProizvodRepository _proizvod;
        public IKupacRepository Kupac
        {
            get
            {
                if (_kupac == null)
                {
                    _kupac = new KupacRepository(_repoContext);
                }
                return _kupac;
            }
        }
        public IProizvodRepository Proizvod
        {
            get
            {
                if (_proizvod == null)
                {
                    _proizvod = new ProizvodRepository(_repoContext);
                }
                return _proizvod;
            }
        }


        public RepositoryWrapper(ZadatakAPIDBContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }
        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}
