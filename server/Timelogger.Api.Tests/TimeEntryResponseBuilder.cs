namespace Timelogger.Api.Tests
{
    using System;
    using System.Collections.Generic;
    using Timelogger.Api.Domain;

    public class TimeEntryResponseBuilder
    {
        private int _id = 1;
        private int _contributorNumber = 100;
        private int _projectNumber = 1001;
        private string _notes = "notes";
        private double _hours = 123;

        public TimeEntryResponse Build() =>
            new TimeEntryResponse()
            {
                Id = _id,
                ContributorNumber = _contributorNumber,
                InsertedAt = DateTime.UtcNow,
                EntryDate = DateTime.UtcNow,
                ProjectNumber = _projectNumber,
                Hours = _hours,
                Notes = _notes
            };

        public List<TimeEntryResponse> BuildList() =>
            new List<TimeEntryResponse>()
            {
                        new TimeEntryResponse()
                        {
                            Id = _id,
                            ContributorNumber = _contributorNumber,
                            InsertedAt = DateTime.UtcNow,
                            EntryDate = DateTime.UtcNow,
                            ProjectNumber = _projectNumber,
                            Hours = _hours,
                            Notes = _notes
                        },
                        new TimeEntryResponse
                        {
                            Id = _id + 1 ,
                            ContributorNumber = _contributorNumber + 1,
                            InsertedAt = DateTime.UtcNow,
                            EntryDate = DateTime.UtcNow,
                            ProjectNumber = _projectNumber + 1,
                            Hours = _hours + 1,
                            Notes = _notes
                        }
            };
    }
}