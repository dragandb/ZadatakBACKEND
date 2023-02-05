using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using System.Security.Cryptography.X509Certificates;
using ZadatakAPI.Data;
using ZadatakAPI.Models;
using ZadatakAPI.Models_DTO;

namespace ZadatakAPI.Core.Repositories
{
    public class KupacRepository : GenericRepository<Kupac>, IKupacRepository
    {
        public KupacRepository(ZadatakAPIDBContext context, ILogger logger, IMapper mapper) : base(context, logger, mapper)
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
