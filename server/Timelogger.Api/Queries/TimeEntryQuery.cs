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

    public class TimeEntryQuery : ITimeEntryQuery
    {
        private readonly ITimeEntryRepository timeEntryRepository;

        public TimeEntryQuery(ITimeEntryRepository timeEntryRepository)
        {
            this.timeEntryRepository = timeEntryRepository;
        }

        public async Task<TimeEntryResponse> GetTimeEntry(int id)
        {
            var entry = await this.timeEntryRepository.GetTimeEntryAsync(id);
            return Map(entry);
        }

        public async Task<IEnumerable<TimeEntryResponse>> GetAllTimeEntries()
        {
            var entries = await this.timeEntryRepository.GetAllTimeEntriesAsync();
            return entries.Select(p => Map(p)).AsEnumerable();
        }

        public async Task<ProjectTimeLogResponse> GetTimeEntriesByProject(int project, int contributor)
        {
            var projectTimeLog = await this.timeEntryRepository.GetTimeEntriesByProjectAsync(project, contributor);
            return Map(projectTimeLog);
        }

        public async Task<IEnumerable<ProjectTimeLogOverview>> GetTimeEntriesOverview(int contributor)
        {
            var projectTimeLogEntries = await this.timeEntryRepository.GetTimeEntriesOverviewAsync(contributor);
            return GetOverview(projectTimeLogEntries);
        }

        private IEnumerable<ProjectTimeLogOverview> GetOverview(ProjectTimeLog logs)
        {
            var result = logs.TimeEntries.GroupBy(l => l.ProjectNumber)
                .Select(x => new ProjectTimeLogOverview
                {
                    ProjectNumber = x.First().ProjectNumber,
                    ContributorNumber = x.First().ContributorNumber,
                    Hours = x.Sum(h => h.Hours)
                });
            return result;
        }

        private TimeEntryResponse Map(TimeEntry entry)
        {
            return new TimeEntryResponse(
                id: entry.Id,
                contributorNumber: entry.ContributorNumber,
                insertedAt: entry.InsertedAt,
                entryDate: entry.EntryDate,
                projectNumber: entry.ProjectNumber,
                hours: entry.Hours,
                notes: entry.Notes);
        }

        private ProjectTimeLogResponse Map(ProjectTimeLog log) 
        {
            return new ProjectTimeLogResponse(
                contributorNumber: log.ContributorNumber,
                projectNumber: log.ProjectNumber,
                timeEntries: Map(log.TimeEntries));
        }

        private List<TimeEntryRequest> Map(List<TimeEntry> entries)
        {
            return entries.Select(entry =>
                new TimeEntryRequest(
                id: entry.Id,
                contributorNumber: entry.ContributorNumber,
                insertedAt: entry.InsertedAt,
                entryDate: entry.EntryDate,
                projectNumber: entry.ProjectNumber,
                hours: entry.Hours,
                notes: entry.Notes)).ToList();
        }
    }
}