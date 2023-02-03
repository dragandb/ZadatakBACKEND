using Microsoft.EntityFrameworkCore;
using ZadatakAPI.Data;
using ZadatakAPI.Models;

namespace ZadatakAPI.Core.Repositories
{
    public class RacunRepository : GenericRepository<Zaglavlje_racuna>, IRacunRepository
    {
        public RacunRepository(ZadatakAPIDBContext context, ILogger logger) : base(context, logger)
        {
        }
        public override async Task<Zaglavlje_racuna?> GetById(int Id)
        {
            try
            {
                return await _context.Zaglavlje_Racuna.AsNoTracking().FirstOrDefaultAsync(x => x.Id == Id);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
