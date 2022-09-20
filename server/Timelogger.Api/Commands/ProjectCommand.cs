namespace Timelogger.Api.Commands
{
    using Domain;
    using Exceptions;
    using Timelogger.Entities;
    using Timelogger.Repositories;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class ProjectCommand : IProjectCommand
    {
        private readonly IProjectRepository projectRepository;

        public ProjectCommand(IProjectRepository projectRepository)
        {
            this.projectRepository = projectRepository;
        }

        public async Task<ProjectResponse> CreateProject(ProjectRequest request)
        {
            if (request == null)
            {
                throw new InvalidProjectApiException("Request parameter is null");
            }

            var projectInfo = await this.projectRepository.CreateProjectAsync(Map(request));

            return Map(projectInfo);
        }

        public async Task UpdateProject(int id, string? name, DateTime? endDate, double? price, string? notes, bool? isFinished, int? status)
        {
            await projectRepository.UpdateProjectAsync(id, name, endDate, price, notes, isFinished, status); 
        }

        private Project Map(ProjectRequest request)
        {
            return new Project(
                id: request.Id,
                name: request.Name,
                endDate: request.EndDate,
                price: request.Price,
                customerNumber: request.CustomerNumber,
                notes: request.Notes,
                isFinished: request.IsFinished,
                contributorNumber: request.ContributorNumber,
                status: 0);
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
