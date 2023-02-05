using Microsoft.AspNetCore.Mvc;
using ZadatakAPI.Core;
using ZadatakAPI.Models;

namespace ZadatakAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RacunController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public RacunController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //CRUD

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _unitOfWork.Racuni.ALL());
        }

        [HttpGet]
        [Route("GetbyId")]
        public async Task<IActionResult> GetID(int id)
        {
            var zaglavlje_Racuna = await _unitOfWork.Racuni.GetById(id);

            if (zaglavlje_Racuna == null) return NotFound();
            return Ok(zaglavlje_Racuna);
        }

        [HttpPost]
        [Route("AddRacun")]
        public async Task<IActionResult> Add(Zaglavlje_racuna zaglavlje_Racuna)
        {
            await _unitOfWork.Racuni.Add(zaglavlje_Racuna);
            await _unitOfWork.CompleteAsync();
            return Ok(zaglavlje_Racuna);
        }

        [HttpDelete]
        [Route("DeleteRacun")]
        public async Task<IActionResult> Delete(int id)
        {
            var zaglavlje_Racuna = await _unitOfWork.Racuni.GetById(id);

            if (zaglavlje_Racuna == null) return NotFound();

            await _unitOfWork.Racuni.Delete(zaglavlje_Racuna);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }

        [HttpPatch]
        [Route("UpdateRacun")]
        public async Task<IActionResult> Update(Zaglavlje_racuna zaglavlje_Racuna)
        {

            var existracun = await _unitOfWork.Racuni.GetById(zaglavlje_Racuna.Id);

            if (existracun == null) return NotFound();


            await _unitOfWork.Racuni.Update(zaglavlje_Racuna);
            await _unitOfWork.CompleteAsync();

            return NoContent();

        }
    }
}
