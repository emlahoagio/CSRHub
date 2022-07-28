using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repo
{
    public class ProjectRepo : RepoBase<Project>, IProjectRepo
    {
        public ProjectRepo(RepoContext context) : base(context)
        {

        }
        public void CreateProjectForOrganization(Guid organizationId, Project project)
        {
            project.OrganizationId = organizationId;
            Create(project);
        }

        public void DeleteProject(Project project) => Delete(project);

        public async Task<IEnumerable<Project>> GetProjectsAsync(Guid organizationId, bool trackChanges)
        {
            var projects = await FindByCondition(p => p.OrganizationId.Equals(organizationId), trackChanges)
                .OrderBy(p => p.Name)
                .ToListAsync();
            return projects;
        }

        public async Task<Project> GetProject(Guid orgId, Guid projectId, bool trackChanges) =>
            await FindByCondition(p => p.Id.Equals(projectId) && p.OrganizationId.Equals(orgId), trackChanges)
            .SingleOrDefaultAsync();

        public void UpdateProject(Project project) => Update(project);
    }
}

