using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repo
{
    public class OrgRepo : RepoBase<Organization>, IOrgRepo
    {
        public OrgRepo(RepoContext context) : base(context)
        {
        }

        public void CreateOrganization(Organization org) => Create(org);

        public async Task<IEnumerable<Organization>> GetAllOrganizations(bool trackChanges) =>
            await FindAll(trackChanges)
            .OrderBy(o => o.Name)
            .ToListAsync();

        public async Task<Organization> GetOrganization(Guid orgId, bool trackChanges) =>
            await FindByCondition(o => o.Id.Equals(orgId), trackChanges)
            .SingleOrDefaultAsync();
    }
}

