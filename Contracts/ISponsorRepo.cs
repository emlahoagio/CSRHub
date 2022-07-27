using Entities.Models;

namespace Contracts
{
    public interface ISponsorRepo
    {
        Task<IEnumerable<Sponsor>> GetAllSponsors(bool trackChanges);
        Task<Sponsor> GetSponsor(Guid sponsorId, bool trackChanges);
        void CreateSponsor(Sponsor sponsor);
    }
}

