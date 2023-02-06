using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ZadatakAPI.Core;

namespace ZadatakAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
    }
}
