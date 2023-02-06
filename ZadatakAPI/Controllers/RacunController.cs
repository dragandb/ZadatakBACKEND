using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ZadatakAPI.Core;
using ZadatakAPI.Models.DTO;
using ZadatakAPI.Models;

namespace ZadatakAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RacunController : ControllerBase
    {
        private IRepositoryWrapper _repository;
        private ILogger<RacunController> _logger;
        private IMapper _mapper;

        public RacunController(IRepositoryWrapper repository, ILogger<RacunController> logger, IMapper mapper)
        {
            _mapper = mapper;
            _logger = logger;
            _repository = repository;
        }

        //CRUD

        [HttpGet]
        public IActionResult GetAllRacun()
        {
            try
            {
                var racun = _repository.Racun.GetAllRacun();
                _logger.LogInformation("Returned all objects from database.");

                var racunResult = _mapper.Map<IEnumerable<RacunDTO>>(racun);
                return Ok(racunResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}", Name = "RacunById")]
        public IActionResult GetRacunById(int id)
        {
            try
            {
                var racun = _repository.Racun.GetRacunById(id);
                if (racun is null)
                {
                    _logger.LogError($"Object with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInformation($"Returned object with id: {id}");
                    var racunResult = _mapper.Map<RacunDTO>(racun);
                    return Ok(racunResult);
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
        public IActionResult CreateRacun([FromBody] RacunForCreationDTO racun)
        {
            try
            {
                if (racun is null)
                {
                    _logger.LogError("Object sent from client is null.");
                    return BadRequest("Object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid object sent from client.");
                    return BadRequest("Invalid model object");
                }
                var racunEntity = _mapper.Map<Zaglavlje_racuna>(racun);
                _repository.Racun.CreateRacun(racunEntity);
                _repository.Save();
                var createdRacun = _mapper.Map<ProizvodDTO>(racunEntity);
                return CreatedAtRoute("RacunById", new { id = createdRacun.Id }, createdRacun);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateOwner action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut]
        [Route("Update")]
        public IActionResult UpdateRacun(int id, [FromBody] RacunForUpdateDTO racun)
        {
            try
            {
                if (racun is null)
                {
                    _logger.LogError("Object sent from client is null.");
                    return BadRequest("Object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid object sent from client.");
                    return BadRequest("Invalid model object");
                }
                var racunEntity = _repository.Racun.GetRacunById(id);
                if (racunEntity is null)
                {
                    _logger.LogError($"Object with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                _mapper.Map(racun, racunEntity);
                _repository.Racun.UpdateRacun(racunEntity);
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
        public IActionResult DeleteRacun(int id)
        {
            try
            {
                var racun = _repository.Racun.GetRacunById(id);
                if (racun == null)
                {
                    _logger.LogError($"Object with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                _repository.Racun.DeleteRacun(racun);
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
