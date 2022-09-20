namespace Timelogger.Api.Queries
{
    using Domain;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IProjectQuery
    {
        Task<ProjectResponse> GetProject(int id);
        Task<IEnumerable<ProjectResponse>> GetAllProjects();
    }
}
