namespace Timelogger.Api.Domain
{
    using System;
    using System.Collections.Generic;

    public class ProjectTimeLogResponse
    {
        public int ContributorNumber { get; set; }
        public int ProjectNumber { get; set; }
        public List<TimeEntryRequest> TimeEntries { get; set; }

        public ProjectTimeLogResponse(
            int contributorNumber,
            int projectNumber,
            List<TimeEntryRequest> timeEntries)
        {
            ContributorNumber = contributorNumber;
            ProjectNumber = projectNumber;
            TimeEntries = timeEntries;
        }
    }
}
