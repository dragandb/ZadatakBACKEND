using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZadatakAPI.Core;
using ZadatakAPI.Data;
using ZadatakAPI.Models;

namespace ZadatakAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KupacController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public KupacController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //CRUD

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _unitOfWork.Kupci.ALL());
        }

        [HttpGet]
        [Route("GetbyId")]
        public async Task<IActionResult> GetID(int id)
        {
            var kupac = await _unitOfWork.Kupci.GetById(id);

            if (kupac == null) return NotFound();
            return Ok(kupac);
        }

        [HttpPost]
        [Route("AddKupac")]
        public async Task<IActionResult> Add(Kupac kupac)
        {
            await _unitOfWork.Kupci.Add(kupac);
            await _unitOfWork.CompleteAsync();
            return Ok(kupac);
        }

        [HttpDelete]
        [Route("DeleteKupac")]
        public async Task<IActionResult> Delete(int id)
        {
            var kupac = await _unitOfWork.Kupci.GetById(id);

            if (kupac == null) return NotFound();

            await _unitOfWork.Kupci.Delete(kupac);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }

        [HttpPatch]
        [Route("UpdateKupac")]
        public async Task<IActionResult> Update(Kupac kupac)
        {
             
            var existkupac = await _unitOfWork.Kupci.GetById(kupac.Id);

            if (existkupac == null) return NotFound();

            
            await _unitOfWork.Kupci.Update(kupac);
            await _unitOfWork.CompleteAsync();

            return NoContent();

        }
    }
}
