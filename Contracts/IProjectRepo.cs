using Entities.Models;

namespace Contracts
{
    public interface IProjectRepo
    {
        Task<IEnumerable<Project>> GetProjectsAsync(Guid organizationId, bool trackChanges);
        Task<Project> GetProject(Guid orgId, Guid projectId, bool trackChanges);
        void CreateProjectForOrganization(Guid organizationId, Project project);
        void DeleteProject(Project project);
        void UpdateProject(Project project);
    }
}

