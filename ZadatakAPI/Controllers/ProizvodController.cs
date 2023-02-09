using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ZadatakAPI.Core;
using ZadatakAPI.Models.DTO;
using ZadatakAPI.Models;

namespace ZadatakAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProizvodController : ControllerBase
    {
        private IRepositoryWrapper _repository;
        private ILogger<ProizvodController> _logger;
        private IMapper _mapper;

        public ProizvodController(IRepositoryWrapper repository, ILogger<ProizvodController> logger, IMapper mapper)
        {
            _mapper = mapper;
            _logger = logger;
            _repository = repository;
        }
        //CRUD

        [HttpGet]
        public IActionResult GetAllProizvod()
        {
            try
            {
                var proizvod = _repository.Proizvod.GetAllProizvod();
                _logger.LogInformation("Returned all objects from database.");

                var proizvodResult = _mapper.Map<IEnumerable<ProizvodDTO>>(proizvod);
                return Ok(proizvodResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}", Name = "ProizvodById")]

        public IActionResult GetProizvodById(int id)
        {
            try
            {
                var proizvod = _repository.Proizvod.GetProizvodById(id);
                if (proizvod is null)
                {
                    _logger.LogError($"Object with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInformation($"Returned object with id: {id}");
                    var proizvodResult = _mapper.Map<ProizvodDTO>(proizvod);
                    return Ok(proizvodResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        [Route("Add")]
        public IActionResult CreateProizvod([FromBody] ProizvodForCreationDTO proizvod)
        {
            try
            {
                if (proizvod is null)
                {
                    _logger.LogError("Object sent from client is null.");
                    return BadRequest("Object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid object sent from client.");
                    return BadRequest("Invalid model object");
                }
                var proizvodEntity = _mapper.Map<Proizvod>(proizvod);
                _repository.Proizvod.CreateProizvod(proizvodEntity);
                _repository.Save();
                var createdProizvod = _mapper.Map<ProizvodDTO>(proizvodEntity);
                return CreatedAtRoute("ProizvodById", new { id = createdProizvod.Id }, createdProizvod);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateOwner action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }

        }

        [HttpPut]
        [Route("Update")]
        public IActionResult UpdateProizvod(int id, [FromBody] ProizvodForUpdateDTO proizvod)
        {
            try
            {
                if (proizvod is null)
                {
                    _logger.LogError("Object sent from client is null.");
                    return BadRequest("Object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid object sent from client.");
                    return BadRequest("Invalid model object");
                }
                var proizvodEntity = _repository.Proizvod.GetProizvodById(id);
                if (proizvodEntity is null)
                {
                    _logger.LogError($"Object with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                _mapper.Map(proizvod, proizvodEntity);
                _repository.Proizvod.UpdateProizvod(proizvodEntity);
                _repository.Save();
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete]
        [Route("Remove")]
        public IActionResult DeleteProizvod(int id)
        {
            try
            {
                var proizvod = _repository.Proizvod.GetProizvodById(id);
                if (proizvod == null)
                {
                    _logger.LogError($"Object with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                _repository.Proizvod.DeleteProizvod(proizvod);
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
