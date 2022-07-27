using Entities.Models;

namespace Contracts
{
    public interface IOrgRepo
    {
        Task<IEnumerable<Organization>> GetAllOrganizations(bool trackChanges);
        Task<Organization> GetOrganization(Guid orgId, bool trackChanges);
        void CreateOrganization (Organization org);
    }
}

