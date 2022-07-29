using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvestmentsController : ControllerBase
    {
        private readonly IRepoManager _repo;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public InvestmentsController(IRepoManager repo, ILoggerManager logger, IMapper mapper)
        {
            _repo = repo;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var investments = await _repo.Investment.GetAll(trackChanges: false);
                return Ok(investments);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetAll)} action {ex}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateInvestment(InvestmentForCreationDto investment)
        {
            if (investment == null)
            {
                _logger.LogError("Investment is null");
                return BadRequest();
            }
            var transaction = _mapper.Map<Investment>(investment);
            _repo.Investment.CreateTransaction(transaction);
            await _repo.SaveAsync();
            return Ok("Success");
        }
    }
}
