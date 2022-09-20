namespace Timelogger.Repositories
{
    using Entities;
    using Exceptions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class TimeEntryRepository : ITimeEntryRepository, IDisposable
    {
        private readonly ApiContext _context;

        private bool _disposed;

        public TimeEntryRepository(ApiContext context)
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

        public async Task<TimeEntry> GetTimeEntryAsync(int id)
        {
            var entry = await Task.FromResult(this._context.TimeEntries.FirstOrDefault(p => p.Id == id));

            if (entry != null)
            {
                return entry;
            }
            else
            {
                throw new InvalidTimeEntryException("Time Entry not found");
            }
        }

        public async Task<List<TimeEntry>> GetAllTimeEntriesAsync()
        {
            var entries = await Task.FromResult(this._context.TimeEntries.ToList());

            if (entries != null)
            {
                return entries;
            }
            else
            {
                throw new InvalidTimeEntryException("Time Entries not found");
            }
        }

        public async Task<ProjectTimeLog> GetTimeEntriesByProjectAsync(int project, int contributor)
        {
            var entries = await Task.FromResult(this._context.TimeEntries
                .Where(t => t.ProjectNumber == project && t.ContributorNumber == contributor).ToList());

            return new ProjectTimeLog()
            {
                ProjectNumber = project,
                ContributorNumber = contributor,
                TimeEntries = entries
            };
        }

        public async Task<ProjectTimeLog> GetTimeEntriesOverviewAsync(int contributor)
        {
            var entries = await Task.FromResult(this._context.TimeEntries
                .Where(t => t.ContributorNumber == contributor).ToList());

            return new ProjectTimeLog()
            {
                ContributorNumber = contributor,
                TimeEntries = entries
            };
        }

        public async Task<TimeEntry> CreateTimeEntryAsync(TimeEntry entry)
        {
            await this._context.TimeEntries.AddAsync(entry);
            await this._context.SaveChangesAsync();

            return entry;
        }

    }
}
