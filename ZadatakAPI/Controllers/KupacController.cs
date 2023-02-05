using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ZadatakAPI.Core;
using ZadatakAPI.Models;
using ZadatakAPI.Models.DTO;

namespace ZadatakAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]
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
        public IActionResult GetAllOwners()
        {
            try
            {
                var kupac = _repository.Kupac.GetAllKupac();
                _logger.LogInformation("Returned all owners from database.");

                //var kupacResult = _mapper.Map<IEnumerable<KupacDTO>>(kupac);
                return Ok(kupac);
            }
            catch (Exception)
            {
                _logger.LogError("Something went wrong inside GetAllKupac action.");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet]
        [Route("GetbyId")]
        public IActionResult GetKupacById(int id)
        {
            try
            {
                var kupac = _repository.Kupac.GetKupacById(id);
                if (kupac is null)
                {
                    _logger.LogError($"Owner with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInformation($"Returned owner with id: {id}");
                    var kupacResult = _mapper.Map<Kupac>(kupac);
                    return Ok(kupacResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetOwnerById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet]
        [Route("GetbyBEZid")]
        public IActionResult GetKupacBezID(int id)
        {
            try
            {
                var kupac = _repository.Kupac.GetKupacBezID(id);
                if (kupac is null)
                {
                    _logger.LogError($"Owner with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInformation($"Returned owner with id: {id}");
                    var kupacResult = _mapper.Map<KupacBezIdDTO>(kupac);
                    return Ok(kupacResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetOwnerById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

    }
}
