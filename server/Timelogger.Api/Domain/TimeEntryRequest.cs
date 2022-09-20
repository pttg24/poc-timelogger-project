namespace Timelogger.Api.Domain
{
    using System;

    public class TimeEntryRequest
    {
        public int Id { get; set; }
        public int ContributorNumber { get; set; }
        public DateTime InsertedAt { get; set; }
        public DateTime EntryDate { get; set; }
        public int ProjectNumber { get; set; }
        public double Hours { get; set; }
        public string Notes { get; set; }

        public TimeEntryRequest() { }

        public TimeEntryRequest(
            int id,
            int contributorNumber,
            DateTime insertedAt,
            DateTime entryDate,
            int projectNumber,
            double hours,
            string notes)
        {
            Id = id;
            ContributorNumber = contributorNumber;
            InsertedAt = insertedAt;
            EntryDate = entryDate;
            ProjectNumber = projectNumber;
            Hours = hours;
            Notes = notes;
        }
    }
}
