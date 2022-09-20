namespace Timelogger.Repositories
{
    using Entities;
    using Exceptions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class ProjectRepository : IProjectRepository, IDisposable
    {
        private readonly ApiContext _context;

        private bool _disposed;

        public ProjectRepository(ApiContext context)
        {
            _disposed = false;
            _context = context;
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (this._disposed)
                return;

            if (disposing)
            {
                this._context.Dispose();
            }

            this._disposed = true;
        }

        public async Task<Project> GetProjectAsync(int id) 
        {
            var project = await Task.FromResult(this._context.Projects.FirstOrDefault(p => p.Id == id));

            if (project != null)
            {
                return project;
            }
            else 
            {
                throw new InvalidProjectException("Project not found");
            }
        }

        public async Task<List<Project>> GetAllProjectsAsync() 
        {
            var projects = await Task.FromResult(this._context.Projects.ToList());

            if (projects != null)
            {
                return projects;
            }
            else
            {
                throw new InvalidProjectException("Projects not found");
            }
        }
        
        public async Task<Project> CreateProjectAsync(Project project) 
        {
            await this._context.Projects.AddAsync(project);
            await this._context.SaveChangesAsync();

            return project;
        }
        
        public async Task UpdateProjectAsync(int id, string? name, DateTime? endDate, double? price, string? notes, bool? isFinished, int? status) 
        {
            var project = await Task.FromResult(this._context.Projects.FirstOrDefault(p => p.Id == id));

            if (project != null)
            {
                project.Name = name ?? project.Name;
                project.Price = project.Price;
                project.Notes = notes ?? project.Notes;
                project.IsFinished = project.IsFinished;

                this._context.Projects.Update(project);
                await this._context.SaveChangesAsync();
            }
            else
            {
                throw new InvalidProjectException("Project not found.");
            }
        }
    }
}
