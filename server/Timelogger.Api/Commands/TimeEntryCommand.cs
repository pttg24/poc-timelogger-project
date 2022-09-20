namespace Timelogger.Api.Commands
{
    using Domain;
    using Exceptions;
    using Timelogger.Entities;
    using Timelogger.Repositories;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class TimeEntryCommand : ITimeEntryCommand
    {
        private readonly ITimeEntryRepository timeEntryRepository;

        public TimeEntryCommand(ITimeEntryRepository timeEntryRepository)
        {
            this.timeEntryRepository = timeEntryRepository;
        }

        public async Task<TimeEntryResponse> CreateTimeEntry(TimeEntryRequest request)
        {
            if (request == null)
            {
                throw new InvalidTimeEntryApiException("Request parameter is null");
            }

            var entry = await this.timeEntryRepository.CreateTimeEntryAsync(Map(request));

            return Map(entry);
        }

        private TimeEntry Map(TimeEntryRequest request)
        {
            return new TimeEntry(
                id: request.Id,
                contributorNumber: request.ContributorNumber,
                insertedAt: request.InsertedAt,
                entryDate: request.EntryDate,
                projectNumber: request.ProjectNumber,
                hours: request.Hours,
                notes: request.Notes);
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
    }
}