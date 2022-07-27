using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Http;
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
        public async Task<IActionResult> GetProjects()
        {
            try
            {
                var projects = await _repo.Project.GetAllProjects(trackChanges: false);
                //var companiesDto = _mapper.Map<IEnumerable<CompanyDto>>(companies);
                return Ok(projects);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetProjects)} action {ex}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCompany(Guid id)
        {
            var project = await _repo.Project.GetProject(id, trackChanges: false);
            if (project == null)
            {
                _logger.LogInfo($"Project with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            else
            {
                //var companyDto = _mapper.Map<CompanyDto>(company);
                return Ok(project);
            }
        }

        //[HttpPost]
        //public async Task<IActionResult> CreateProject(Guid orgId, [FromBody] ProjectForCreationDto company)
        //{
        //    if (company == null)
        //    {
        //        _logger.LogError("CompanyForCreationDto object sent from client is null");
        //        return BadRequest("CompanyForCreationDto object is null");
        //    }
        //    var companyEntity = _mapper.Map<Company>(company);

        //    _repo.Company.CreateCompany(companyEntity);
        //    await _repo.SaveAsync();

        //    var companyToReturn = _mapper.Map<CompanyDto>(companyEntity);

        //    return CreatedAtRoute("CompanyById", new { id = companyToReturn.Id }, companyToReturn);
        //}
    }
}
