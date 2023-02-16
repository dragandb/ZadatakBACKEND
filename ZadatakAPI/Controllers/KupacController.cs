using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ZadatakAPI.Core;
using ZadatakAPI.Models;
using ZadatakAPI.Models.DTO;

namespace ZadatakAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KupacController : ControllerBase
    {

        private IRepositoryWrapper _repository;
        private ILogger<KupacController> _logger;
        private IMapper _mapper;

        public KupacController(IRepositoryWrapper repository, ILogger<KupacController> logger, IMapper mapper)
        {
            _mapper = mapper;
            _logger = logger;
            _repository = repository;
        }

        //CRUD

        [HttpGet]
        public IActionResult GetAllKupac()
        {
            try
            {
                var kupac = _repository.Kupac.GetAllKupac();
                _logger.LogInformation("Returned all objects from database.");

                var kupacResult = _mapper.Map<IEnumerable<KupacDTO>>(kupac);
                return Ok(kupacResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}", Name = "KupacById")]
        
        public IActionResult GetKupacById(int id)
        {
            try
            {
                var kupac = _repository.Kupac.GetKupacById(id);
                if (kupac is null)
                {
                    _logger.LogError($"Object with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInformation($"Returned object with id: {id}");
                    var kupacResult = _mapper.Map<KupacDTO>(kupac);
                    return Ok(kupacResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet]
        [Route("GetbyBezId")]
        public IActionResult GetKupacBezID(int id)
        {
            try
            {
                var kupac = _repository.Kupac.GetKupacBezID(id);
                if (kupac is null)
                {
                    _logger.LogError($"Object with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInformation($"Returned object with id: {id}");
                    var kupacResult = _mapper.Map<KupacBezIdDTO>(kupac);
                    return Ok(kupacResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult CreateKupac([FromBody] KupacForCreationDTO kupac)
        {
            try
            {
                if (kupac is null)
                {
                    _logger.LogError("Object sent from client is null.");
                    return BadRequest("Object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid object sent from client.");
                    return BadRequest("Invalid model object");
                }
                var kupacEntity = _mapper.Map<Kupac>(kupac);
                _repository.Kupac.CreateKupac(kupacEntity);
                _repository.Save();
                var createdKupac = _mapper.Map<KupacDTO>(kupacEntity);
                return CreatedAtRoute("KupacById", new { id = createdKupac.Id }, createdKupac);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }

        }

        [HttpPut("{id}")]
        public IActionResult UpdateKupac(int id, [FromBody] KupacForUpdateDTO kupac)
        {
            try
            {
                if (kupac is null)
                {
                    _logger.LogError("Object sent from client is null.");
                    return BadRequest("Object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid object sent from client.");
                    return BadRequest("Invalid model object");
                }
                var kupacEntity = _repository.Kupac.GetKupacById(id);
                if (kupacEntity is null)
                {
                    _logger.LogError($"Object with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                _mapper.Map(kupac, kupacEntity);
                _repository.Kupac.UpdateKupac(kupacEntity);
                _repository.Save();
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteKupac(int id)
        {
            try
            {
                var kupac = _repository.Kupac.GetKupacById(id);
                if (kupac == null)
                {
                    _logger.LogError($"Object with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                _repository.Kupac.DeleteKupac(kupac);
                _repository.Save();
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
