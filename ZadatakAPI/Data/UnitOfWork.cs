using AutoMapper;
using ZadatakAPI.Core;
using ZadatakAPI.Core.Repositories;

namespace ZadatakAPI.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private ZadatakAPIDBContext _context;
        private readonly ILogger _logger;
        private IMapper _mapper; 
        public UnitOfWork(ZadatakAPIDBContext context, ILoggerFactory loggerFactory, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
            
            var _logger = loggerFactory.CreateLogger("logs");

            Kupci = new KupacRepository(_context, _logger, _mapper);
            Proizvodi = new ProizvodRepository(_context, _logger, _mapper);
            Racuni = new RacunRepository(_context, _logger, _mapper);
            Stavke = new StavkaRepository(_context, _logger, _mapper);
        }

        public IKupacRepository Kupci { get; private set; }
        public IProizvodRepository Proizvodi { get; private set; }
        public IRacunRepository Racuni { get; private set; }
        public IStavkaRepository Stavke { get; private set; }

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
