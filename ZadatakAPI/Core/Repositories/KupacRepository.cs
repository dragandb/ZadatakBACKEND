using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using ZadatakAPI.Data;
using ZadatakAPI.Models;

namespace ZadatakAPI.Core.Repositories
{
    public class KupacRepository : GenericRepository<Kupac>, IKupacRepository
    {
        public KupacRepository(ZadatakAPIDBContext context, ILogger logger) : base(context, logger)
        {

        }

        public override async Task<Kupac?> GetById(int Id)
        {
            try
            {
                return await _context.Kupac.AsNoTracking ().FirstOrDefaultAsync(x => x.Id == Id);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
