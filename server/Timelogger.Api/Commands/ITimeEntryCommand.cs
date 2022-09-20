namespace Timelogger.Api.Commands
{
    using Domain;
    using System;
    using System.Threading.Tasks;

    public interface ITimeEntryCommand
    {
        Task<TimeEntryResponse> CreateTimeEntry(TimeEntryRequest request);
    }
}