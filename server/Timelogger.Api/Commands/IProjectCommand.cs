namespace Timelogger.Api.Commands
{
    using Domain;
    using System;
    using System.Threading.Tasks;

    public interface IProjectCommand
    {
        Task<ProjectResponse> CreateProject(ProjectRequest request);
        Task UpdateProject(int id, string? name, DateTime? endDate, double? price, string? notes, bool? isFinished, int? status);
    }
}
