using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ZadatakAPI.Models;

namespace ZadatakAPI.Data
{
    public class ZadatakAPIDBContext : IdentityDbContext
    {
        public ZadatakAPIDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Kupac> Kupac { get; set; }

        public DbSet<Proizvod> Proizvod { get; set; }

        public DbSet<Zaglavlje_racuna> Zaglavlje_Racuna { get; set; }

        public DbSet<Stavke_racuna> Stavke_Racuna { get; set; }
    }
}
