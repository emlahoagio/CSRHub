using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repo
{
    public class SponsorRepo : RepoBase<Sponsor>, ISponsorRepo
    {
        public SponsorRepo(RepoContext context) : base(context)
        {
        }

        public void CreateSponsor(Sponsor sponsor) => Create(sponsor);

        public void DeleteSponsor(Sponsor sponsor) => Delete(sponsor);

        public async Task<IEnumerable<Sponsor>> GetAllSponsors(bool trackChanges) =>
            await FindAll(trackChanges)
            .OrderBy(s => s.Name)
            .ToListAsync();

        public async Task<Sponsor> GetSponsor(Guid sponsorId, bool trackChanges) =>
        await FindByCondition(s => s.Id.Equals(sponsorId), trackChanges)
            .SingleOrDefaultAsync();

        public void UpdateSponsor(Sponsor sponsor) => Update(sponsor);
    }
}

