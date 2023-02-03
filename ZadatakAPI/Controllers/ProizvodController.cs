using Microsoft.AspNetCore.Mvc;
using ZadatakAPI.Core;
using ZadatakAPI.Models;

namespace ZadatakAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProizvodController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProizvodController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //CRUD

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _unitOfWork.Proizvodi.ALL());
        }

        [HttpGet]
        [Route("GetbyId")]
        public async Task<IActionResult> GetID(int id)
        {
            var proizvod = await _unitOfWork.Proizvodi.GetById(id);

            if (proizvod == null) return NotFound();
            return Ok(proizvod);
        }

        [HttpPost]
        [Route("AddProizvod")]
        public async Task<IActionResult> Add(Proizvod proizvod)
        {
            await _unitOfWork.Proizvodi.Add(proizvod);
            await _unitOfWork.CompleteAsync();
            return Ok(proizvod);
        }

        [HttpDelete]
        [Route("DeleteProizvod")]
        public async Task<IActionResult> Delete(int id)
        {
            var proizvod = await _unitOfWork.Proizvodi.GetById(id);

            if (proizvod == null) return NotFound();

            await _unitOfWork.Proizvodi.Delete(proizvod);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }

        [HttpPatch]
        [Route("UpdateProizvod")]
        public async Task<IActionResult> Update(Proizvod proizvod)
        {

            var existproizvod = await _unitOfWork.Proizvodi.GetById(proizvod.Id);

            if (existproizvod == null) return NotFound();


            await _unitOfWork.Proizvodi.Update(proizvod);
            await _unitOfWork.CompleteAsync();

            return NoContent();

        }
    }
}
