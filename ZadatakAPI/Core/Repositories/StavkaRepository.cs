using Microsoft.EntityFrameworkCore;
using ZadatakAPI.Data;
using ZadatakAPI.Models;

namespace ZadatakAPI.Core.Repositories
{
    public class StavkaRepository : GenericRepository<Stavke_racuna>, IStavkaRepository
    {
        public StavkaRepository(ZadatakAPIDBContext context, ILogger logger) : base(context, logger)
        {
        }

        public override async Task<Stavke_racuna?> GetById(int Id)
        {
            try
            {
                return await _context.Stavke_Racuna.AsNoTracking().FirstOrDefaultAsync(x => x.Id == Id);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
