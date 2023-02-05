using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using ZadatakAPI.Core;
using ZadatakAPI.Data;
using ZadatakAPI.Models;
using ZadatakAPI.Models_DTO;

namespace ZadatakAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KupacController : ControllerBase
    {
        private readonly IUnitOfWork _repository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public KupacController(IUnitOfWork unitOfWork)
        {
            _repository = unitOfWork;
            
        }

        //CRUD

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var kupac = await _repository.Kupci.ALL();

            _logger.LogInformation("Svi kupci.");
            return Ok(kupac);
            //return Ok(await _repository.Kupci.ALL());
        }

        [HttpGet]
        [Route("GetbyId")]
        public async Task<IActionResult> GetID(int id)
        {
            try
            {
                var kupac = await _repository.Kupci.GetById(id);
                if (kupac is null)
                {
                    
                    return NotFound();
                }
                else
                {

                 return Ok(kupac);
                }
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        [Route("AddKupac")]
        public async Task<IActionResult> Add(Kupac kupac)
        {
            await _repository.Kupci.Add(kupac);
            await _repository.CompleteAsync();
            return Ok(kupac);
        }

        [HttpDelete]
        [Route("DeleteKupac")]
        public async Task<IActionResult> Delete(int id)
        {
            var kupac = await _repository.Kupci.GetById(id);

            if (kupac == null) return NotFound();

            await _repository.Kupci.Delete(kupac);
            await _repository.CompleteAsync();

            return NoContent();
        }

        [HttpPatch]
        [Route("UpdateKupac")]
        public async Task<IActionResult> Update(Kupac kupac)
        {
             
            var existkupac = await _repository.Kupci.GetById(kupac.Id);

            if (existkupac == null) return NotFound();

            
            await _repository.Kupci.Update(kupac);
            await _repository.CompleteAsync();

            return NoContent();

        }
        
    }
}
