namespace Timelogger.Repositories
{
    using Entities;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface IProjectRepository
    {
        Task<Project> GetProjectAsync(int id);
        Task<List<Project>> GetAllProjectsAsync();
        Task<Project> CreateProjectAsync(Project project);
        Task UpdateProjectAsync(int id, string? name, DateTime? endDate, double? price, string? notes, bool? isFinished, int? status);
    }
}
