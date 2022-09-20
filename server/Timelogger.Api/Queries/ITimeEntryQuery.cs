namespace Timelogger.Api.Queries
{
    using Domain;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ITimeEntryQuery
    {
        Task<TimeEntryResponse> GetTimeEntry(int id);
        Task<IEnumerable<TimeEntryResponse>> GetAllTimeEntries();
        Task<ProjectTimeLogResponse> GetTimeEntriesByProject(int project, int contributor);
        Task<IEnumerable<ProjectTimeLogOverview>> GetTimeEntriesOverview(int contributor);
    }
}