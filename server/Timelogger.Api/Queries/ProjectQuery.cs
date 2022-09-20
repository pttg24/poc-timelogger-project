namespace Timelogger.Api.Queries
{
    using Domain;
    using Exceptions;
    using Timelogger.Entities;
    using Timelogger.Repositories;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    public class ProjectQuery : IProjectQuery
    {
        private readonly IProjectRepository projectRepository;

        public ProjectQuery(IProjectRepository projectRepository)
        {
            this.projectRepository = projectRepository;
        }

        public async Task<ProjectResponse> GetProject(int id)
        {
            var projectInfo = await this.projectRepository.GetProjectAsync(id);
            return Map(projectInfo);
        }

        public async Task<IEnumerable<ProjectResponse>> GetAllProjects()
        {
            var projects = await this.projectRepository.GetAllProjectsAsync();
            return projects.Select(p => Map(p)).AsEnumerable();
        }

        private ProjectResponse Map(Project project)
        {
            return new ProjectResponse(
                number: project.Id,
                name: project.Name,
                statusDescription: project.Status.ToString(),
                endDate: project.EndDate,
                price: project.Price,
                customerNumber: project.CustomerNumber,
                notes: project.Notes,
                isFinished: project.IsFinished,
                contributorNumber: project.ContributorNumber);
        }
    }
}
