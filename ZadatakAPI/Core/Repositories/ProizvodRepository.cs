using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ZadatakAPI.Data;
using ZadatakAPI.Models;

namespace ZadatakAPI.Core.Repositories
{
    public class ProizvodRepository : GenericRepository<Proizvod>, IProizvodRepository
    {
        public ProizvodRepository(ZadatakAPIDBContext context, ILogger logger, IMapper mapper) : base(context, logger, mapper)
        {
        }

        public override async Task<Proizvod?> GetById(int Id)
        {
            try
            {
                return await _context.Proizvod.AsNoTracking().FirstOrDefaultAsync(x => x.Id == Id);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
