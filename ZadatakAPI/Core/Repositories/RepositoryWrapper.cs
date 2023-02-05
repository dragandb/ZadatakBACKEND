using ZadatakAPI.Data;

namespace ZadatakAPI.Core.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private ZadatakAPIDBContext _repoContext;
        private IKupacRepository _kupac;
        
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
