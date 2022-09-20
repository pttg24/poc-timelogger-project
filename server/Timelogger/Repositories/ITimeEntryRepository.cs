namespace Timelogger.Repositories
{
    using Entities;
    using System.Collections.Generic;
    using System;
    using System.Threading.Tasks;

    public interface ITimeEntryRepository
    {
        Task<TimeEntry> GetTimeEntryAsync(int id);
        Task<List<TimeEntry>> GetAllTimeEntriesAsync();
        Task<TimeEntry> CreateTimeEntryAsync(TimeEntry timeEntry);
        Task<ProjectTimeLog> GetTimeEntriesByProjectAsync(int project, int contributor);
        Task<ProjectTimeLog> GetTimeEntriesOverviewAsync(int contributor);
    }
}
