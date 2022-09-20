namespace Timelogger.Entities
{
    using System;

    public class Project
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

        public Project(
            int id,
            string name,
            DateTime endDate,
            double price,
            int customerNumber,
            string notes,
            bool isFinished,
            int contributorNumber,
            ProjectStatuses status)
        {
            Id = id;
            Name = name;
            EndDate = endDate;
            Price = price;                
            CustomerNumber = customerNumber;
            Notes = notes;
            IsFinished = isFinished;
            ContributorNumber = contributorNumber;
            Status = status;
        }
    }
}
