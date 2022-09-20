namespace Timelogger.Api.Domain
{
    using System;

    public class ProjectResponse
    {
        public int Number { get; set; }
        public string Name { get; set; }
        public string StatusDescription { get; set; }
        public DateTime EndDate { get; set; }
        public double Price { get; set; }
        public int CustomerNumber { get; set; }
        public string Notes { get; set; }
        public bool IsFinished { get; set; }
        public int ContributorNumber { get; set; }

        public ProjectResponse() { }

        public ProjectResponse(
            int number,
            string name,
            string statusDescription,
            DateTime endDate,
            double price,
            int customerNumber,
            string notes,
            bool isFinished,
            int contributorNumber)
        {
            Number = number;
            Name = name;
            StatusDescription = statusDescription;
            EndDate = endDate;
            Price = price;
            CustomerNumber = customerNumber;
            Notes = notes;
            IsFinished = isFinished;
            ContributorNumber = contributorNumber;
        }
    }
}
