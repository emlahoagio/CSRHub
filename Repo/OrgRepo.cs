using Contracts;
using Entities;
using Entities.Models;

namespace Repo
{
    public class OrgRepo : RepoBase<Organization>, IOrgRepo
    {
        public OrgRepo(RepoContext context) : base(context)
        {
        }

        public void CreateOrganization(Organization org)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Organization>> GetAllOrganizations(bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public Task<Organization> GetOrganization(Guid orgId, bool trackChanges)
        {
            throw new NotImplementedException();
        }
    }
}

