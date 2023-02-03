using Microsoft.AspNetCore.Mvc;
using ZadatakAPI.Core;
using ZadatakAPI.Models;

namespace ZadatakAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StavkaController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public StavkaController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //CRUD

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _unitOfWork.Stavke.ALL());
        }

        [HttpGet]
        [Route("GetbyId")]
        public async Task<IActionResult> GetID(int id)
        {
            var stavke_Racuna = await _unitOfWork.Stavke.GetById(id);

            if (stavke_Racuna == null) return NotFound();
            return Ok(stavke_Racuna);
        }

        [HttpPost]
        [Route("AddStavka")]
        public async Task<IActionResult> Add(Stavke_racuna stavke_Racuna)
        {
            await _unitOfWork.Stavke.Add(stavke_Racuna);
            await _unitOfWork.CompleteAsync();
            return Ok(stavke_Racuna);
        }

        [HttpDelete]
        [Route("DeleteStavka")]
        public async Task<IActionResult> Delete(int id)
        {
            var stavke_Racuna = await _unitOfWork.Stavke.GetById(id);

            if (stavke_Racuna == null) return NotFound();

            await _unitOfWork.Stavke.Delete(stavke_Racuna);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }

        [HttpPatch]
        [Route("UpdateStavka")]
        public async Task<IActionResult> Update(Stavke_racuna stavke_Racuna)
        {

            var existstavka = await _unitOfWork.Stavke.GetById(stavke_Racuna.Id);

            if (existstavka == null) return NotFound();


            await _unitOfWork.Stavke.Update(stavke_Racuna);
            await _unitOfWork.CompleteAsync();

            return NoContent();

        }
    }
}
