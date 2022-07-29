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
                .ToListAsync();
            //var result = projects.Select(x => new Project
            //{
            //    Id = x.Id,
            //    Category = x.Category,
            //    Image = x.Image,
            //    isApprove = x.isApprove,
            //    Location = x.Location,
            //    Name = x.Name,
            //    OrganizationId = x.OrganizationId,
            //    Tag = x.Tag,
            //}).ToList();
            return projects;
        }

        public async Task<Project> GetProject(Guid orgId, Guid projectId, bool trackChanges) =>
            await FindByCondition(p => p.Id.Equals(projectId) && p.OrganizationId.Equals(orgId), trackChanges)
            .SingleOrDefaultAsync();

        public void UpdateProject(Project project) => Update(project);
    }
}

