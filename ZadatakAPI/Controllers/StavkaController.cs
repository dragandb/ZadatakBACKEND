using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ZadatakAPI.Core;
using ZadatakAPI.Models.DTO;
using ZadatakAPI.Models;

namespace ZadatakAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StavkaController : ControllerBase
    {
        private IRepositoryWrapper _repository;
        private ILogger<StavkaController> _logger;
        private IMapper _mapper;

        public StavkaController(IRepositoryWrapper repository, ILogger<StavkaController> logger, IMapper mapper)
        {
            _mapper = mapper;
            _logger = logger;
            _repository = repository;
        }


        //CRUD

        [HttpGet]
        public IActionResult GetAllStavka()
        {
            try
            {
                var stavka = _repository.Stavka.GetAllStavka();
                _logger.LogInformation("Returned all objects from database.");

                var stavkaResult = _mapper.Map<IEnumerable<StavkaDTO>>(stavka);
                return Ok(stavkaResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}", Name = "StavkaById")]
        public IActionResult GetStavkaById(int id)
        {
            try
            {
                var stavka = _repository.Stavka.GetStavkaById(id);
                if (stavka is null)
                {
                    _logger.LogError($"Object with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInformation($"Returned object with id: {id}");
                    var stavkaResult = _mapper.Map<StavkaDTO>(stavka);
                    return Ok(stavkaResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult CreateStavka([FromBody] StavkaForCreationDTO stavka)
        {
            try
            {
                if (stavka is null)
                {
                    _logger.LogError("Object sent from client is null.");
                    return BadRequest("Object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid object sent from client.");
                    return BadRequest("Invalid model object");
                }
                var stavkaEntity = _mapper.Map<Stavke_racuna>(stavka);
                _repository.Stavka.CreateStavka(stavkaEntity);
                _repository.Save();
                var createdStavka = _mapper.Map<StavkaDTO>(stavkaEntity);
                return CreatedAtRoute("StavkaById", new { id = createdStavka.Id }, createdStavka);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateOwner action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStavka(int id, [FromBody] StavkaForUpdateDTO stavka)
        {
            try
            {
                if (stavka is null)
                {
                    _logger.LogError("Object sent from client is null.");
                    return BadRequest("Object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid object sent from client.");
                    return BadRequest("Invalid model object");
                }
                var stavkaEntity = _repository.Stavka.GetStavkaById(id);
                if (stavkaEntity is null)
                {
                    _logger.LogError($"Object with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                _mapper.Map(stavka, stavkaEntity);
                _repository.Stavka.UpdateStavka(stavkaEntity);
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
        public IActionResult DeleteStavka(int id)
        {
            try
            {
                var stavka = _repository.Stavka.GetStavkaById(id);
                if (stavka == null)
                {
                    _logger.LogError($"Object with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                _repository.Stavka.DeleteStavka(stavka);
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
