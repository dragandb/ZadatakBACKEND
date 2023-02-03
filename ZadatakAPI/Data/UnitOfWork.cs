using ZadatakAPI.Core;
using ZadatakAPI.Core.Repositories;

namespace ZadatakAPI.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private ZadatakAPIDBContext _context;
        private readonly ILogger _logger;

        public UnitOfWork(ZadatakAPIDBContext context, ILoggerFactory loggerFactory)
        {
            _context= context;
            var _logger = loggerFactory.CreateLogger("logs");

            Kupci = new KupacRepository(_context, _logger);
            Proizvodi = new ProizvodRepository(_context, _logger);
        }

        public IKupacRepository Kupci { get; private set; }
        public IProizvodRepository Proizvodi { get; private set; }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
