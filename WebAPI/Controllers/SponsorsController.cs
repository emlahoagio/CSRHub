using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SponsorsController : ControllerBase
    {
        private readonly IRepoManager _repo;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public SponsorsController(IRepoManager repo, ILoggerManager logger, IMapper mapper)
        {
            _repo = repo;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetSponsors()
        {
            try
            {
                var sponsors = await _repo.Sponsor.GetAllSponsors(trackChanges: false);
                return Ok(sponsors);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetSponsors)} action {ex}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}", Name = "SponsorById")]
        public async Task<IActionResult> GetSponsor(Guid id)
        {
            var sponsor = await _repo.Sponsor.GetSponsor(id, trackChanges: false);
            if (sponsor == null)
            {
                _logger.LogInfo($"sponsor with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            else
            {
                return Ok(sponsor);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateSponsor([FromBody] SponsorForCreationDto sponsor)
        {
            if (sponsor == null)
            {
                _logger.LogError("SponsorForCreationDto object sent from client is null");
                return BadRequest("SponsorForCreationDto object is null");
            }
            var sponsorEntity = _mapper.Map<Sponsor>(sponsor);

            _repo.Sponsor.CreateSponsor(sponsorEntity);
            await _repo.SaveAsync();

            var sponsorToReturn = _mapper.Map<Sponsor>(sponsorEntity);

            return CreatedAtRoute("SponsorById", new { id = sponsorToReturn.Id }, sponsorToReturn);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSponsor(Guid id)
        {
            var sponsor = await _repo.Sponsor.GetSponsor(id, trackChanges: false);
            if (sponsor == null)
            {
                _logger.LogInfo($"Sponsor with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            _repo.Sponsor.DeleteSponsor(sponsor);
            await _repo.SaveAsync();

            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSponsor(Sponsor sponsor)
        {
            var sponsorUpdate = await _repo.Sponsor.GetSponsor(sponsor.Id, trackChanges: false);
            if (sponsorUpdate == null)
            {
                _logger.LogInfo($"Sponsor with id: {sponsor.Id} doesn't exist in the database.");
                return NotFound();
            }
            _repo.Sponsor.UpdateSponsor(sponsor);
            await _repo.SaveAsync();

            return NoContent();
        }
    }
}
