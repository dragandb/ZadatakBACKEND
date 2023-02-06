using ZadatakAPI.Data;

namespace ZadatakAPI.Core.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private ZadatakAPIDBContext _repoContext;
        private IKupacRepository _kupac;
        private IProizvodRepository _proizvod;
        private IRacunRepository _racun;
        private IStavkaRepository _stavka;

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
        public IRacunRepository Racun
        {
            get
            {
                if (_racun == null)
                {
                    _racun = new RacunRepository(_repoContext);
                }
                return _racun;
            }
        }
        public IStavkaRepository Stavka
        {
            get
            {
                if (_stavka == null)
                {
                    _stavka = new StavkaRepository(_repoContext);
                }
                return _stavka;
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
