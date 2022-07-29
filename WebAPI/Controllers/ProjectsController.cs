using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IRepoManager _repo;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public ProjectsController(IRepoManager repo, ILoggerManager logger, IMapper mapper)
        {
            _repo = repo;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetProjectsForOrganization(Guid orgId)
        {
            var org = await _repo.Organization.GetOrganization(orgId, trackChanges: false);
            if (org == null)
            {
                _logger.LogInfo($"Organization with id: {orgId} doesn't exist in the database.");
                return NotFound();
            }
            var projects = await _repo.Project.GetProjectsAsync(orgId, trackChanges: false);
            return Ok(projects);
        }

        [HttpGet("{id}", Name = "GetProjectForOrganization")]
        public async Task<IActionResult> GetProjectForOrganization(Guid orgId, Guid id)
        {
            var org = _repo.Organization.GetOrganization(orgId, trackChanges: false);
            if (org == null)
            {
                _logger.LogInfo($"Organization with id: {orgId} doesn't exist in the database.");
                return NotFound();
            }

            var project = await _repo.Project.GetProject(orgId, id, trackChanges: false);
            if (project == null)
            {
                _logger.LogInfo($"Project with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            else
            {
                return Ok(project);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateProjectForOrganization(Guid organizationId,
            [FromBody] ProjectForCreationDto project)
        {
            if (project == null)
            {
                _logger.LogError("ProjectForCreationDto object sent from client is null.");
                return BadRequest("ProjectForCreationDto object is null");
            }

            // Check model validation from (data annotation attribute)
            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the ProjectForCreationDto object.");
                return UnprocessableEntity(ModelState);
            }

            var organization = await _repo.Organization.GetOrganization(organizationId, trackChanges: false);
            if (organization == null)
            {
                _logger.LogInfo($"Organization with id: {organizationId} doesn't exist in the database.");
                return NotFound();
            }

            var projectEntity = _mapper.Map<Project>(project);

            _repo.Project.CreateProjectForOrganization(organizationId, projectEntity);
            await _repo.SaveAsync();

            var projectToReturn = _mapper.Map<Project>(projectEntity);
            return CreatedAtRoute("GetProjectForOrganization", new
            {
                organizationId,
                id = projectToReturn.Id
            }, projectToReturn);
        }
    }
}
