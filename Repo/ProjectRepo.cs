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
        public void CreateProject(Project project) => Create(project);

        public async Task<IEnumerable<Project>> GetAllProjects(bool trackChanges) =>
            await FindAll(trackChanges)
            .OrderBy(p => p.Name)
            .ToListAsync();

        public async Task<Project> GetProject(Guid projectId, bool trackChanges) =>
            await FindByCondition(c => c.Id.Equals(projectId), trackChanges)
            .SingleOrDefaultAsync();
    }
}

