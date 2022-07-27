using Contracts;
using Entities;
using Entities.Models;

namespace Repo
{
    public class SponsorRepo : RepoBase<Sponsor>, ISponsorRepo
    {
        public SponsorRepo(RepoContext context):base(context)
        {
        }

        public void CreateSponsor(Sponsor sponsor)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Sponsor>> GetAllSponsors(bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public Task<Sponsor> GetSponsor(Guid sponsorId, bool trackChanges)
        {
            throw new NotImplementedException();
        }
    }
}

