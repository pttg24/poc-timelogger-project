namespace Timelogger.Api.Domain
{
    using System;

    public class ProjectRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime EndDate { get; set; }
        public double Price { get; set; }
        public int CustomerNumber { get; set; }
        public string Notes { get; set; }
        public bool IsFinished { get; set; }
        public int ContributorNumber { get; set; }
        public ProjectStatuses Status { get; set; }
    }
}
