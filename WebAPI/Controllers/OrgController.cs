using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrgController : ControllerBase
    {
        private readonly IRepoManager _repo;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public OrgController(IRepoManager repo, ILoggerManager logger, IMapper mapper)
        {
            _repo = repo;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrgs()
        {
            try
            {
                var organizations = await _repo.Organization.GetAllOrganizations(trackChanges: false);
                //var companiesDto = _mapper.Map<IEnumerable<CompanyDto>>(companies);
                return Ok(organizations);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetOrgs)} action {ex}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}", Name = "OrganizationById")]
        public async Task<IActionResult> GetOrg(Guid id)
        {
            var org = await _repo.Organization.GetOrganization(id, trackChanges: false);
            if (org == null)
            {
                _logger.LogInfo($"Organization with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            else
            {
                //var companyDto = _mapper.Map<CompanyDto>(company);
                return Ok(org);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateOraganize([FromBody] OrgForCreationDto org)
        {
            if (org == null)
            {
                _logger.LogError("OrgForCreationDto object sent from client is null");
                return BadRequest("OrgForCreationDto object is null");
            }
            var orgEntity = _mapper.Map<Organization>(org);

            _repo.Organization.CreateOrganization(orgEntity);
            await _repo.SaveAsync();

            var orgToReturn = _mapper.Map<Organization>(orgEntity);

            return CreatedAtRoute("OrganizationById", new { id = orgToReturn.Id }, orgToReturn);
        }
    }
}