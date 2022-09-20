namespace Timelogger.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ProjectTimeLog
    {
        public int ContributorNumber { get; set; }
        public int ProjectNumber { get; set; }
        public List<TimeEntry> TimeEntries { get; set; }
    }
}
