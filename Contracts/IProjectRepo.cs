using Entities.Models;

namespace Contracts
{
    public interface IProjectRepo
    {
        Task<IEnumerable<Project>> GetAllProjects(bool trackChanges);
        Task<Project> GetProject(Guid projectId, bool trackChanges);
        void CreateProject(Project project);
    }
}

