namespace Timelogger.Api.Domain
{
    public class ProjectTimeLogOverview
    {
        public int ContributorNumber { get; set; }
        public int ProjectNumber { get; set; }
        public double Hours { get; set; }

        public ProjectTimeLogOverview() { }

        public ProjectTimeLogOverview(
            int contributorNumber,
            int projectNumber,
            double hours,
            string projectName)
        {
            ContributorNumber = contributorNumber;
            ProjectNumber = projectNumber;
            Hours = hours;
        }
    }
}