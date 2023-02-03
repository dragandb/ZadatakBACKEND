using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZadatakAPI.Data;
using ZadatakAPI.Models;

namespace ZadatakAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KupacController : ControllerBase
    {
        private readonly ZadatakAPIDBContext _context;

        public KupacController(ZadatakAPIDBContext context)
        {
            _context = context;
        }

        //CRUD

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _context.Kupac.ToArrayAsync());
        }

        [HttpGet]
        [Route("GetbyId")]
        public async Task<IActionResult> GetID(int id)
        {
            var kupac = await _context.Kupac.FirstOrDefaultAsync(x => x.KupacID == id);

            if (kupac == null) return NotFound();
            return Ok(kupac);
        }

        [HttpPost]
        [Route("AddKupac")]
        public async Task<IActionResult> AddKupac(Kupac kupac)
        {
            _context.Kupac.Add(kupac);

            await _context.SaveChangesAsync();
            return Ok(kupac);
        }

        [HttpDelete]
        [Route("DeleteKupac")]
        public async Task<IActionResult> DeleteKupac(int id)
        {
            var kupac = await _context.Kupac.FirstOrDefaultAsync(x => x.KupacID == id);

            if (kupac == null) return NotFound();

            _context.Remove(kupac);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPatch]
        [Route("UpdateKupac")]
        public async Task<IActionResult> UpdateKupac(Kupac kupac)
        {
            var existkupac = await _context.Kupac.FirstOrDefaultAsync(x => x.KupacID == kupac.KupacID);

            if (existkupac == null) return NotFound();

            existkupac.Sifra = kupac.Sifra;
            existkupac.Naziv = kupac.Naziv;
            existkupac.Adresa = kupac.Adresa;
            existkupac.Mjesto = kupac.Mjesto;

            await _context.SaveChangesAsync();
            return NoContent();
            
        }
    }
}
