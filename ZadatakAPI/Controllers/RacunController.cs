using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ZadatakAPI.Core;

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
    }
}
