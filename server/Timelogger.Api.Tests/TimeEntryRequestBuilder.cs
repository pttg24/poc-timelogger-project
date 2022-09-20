namespace Timelogger.Api.Tests
{
    using System;
    using Timelogger.Api.Domain;

    public class TimeEntryRequestBuilder
    {
        private int _id = 1;
        private int _contributorNumber = 100;
        private int _projectNumber = 1001;
        private string _notes = "notes";
        private double _hours = 123;

        public TimeEntryRequest Build() =>
            new TimeEntryRequest()
            {
                Id = _id,
                ContributorNumber = _contributorNumber,
                InsertedAt = DateTime.UtcNow,
                EntryDate = DateTime.UtcNow,
                ProjectNumber = _projectNumber,
                Hours = _hours,
                Notes = _notes,
            };
    }
}