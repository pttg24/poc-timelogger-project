namespace Timelogger.Api.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Timelogger.Api.Domain;

    public class ProjectResponseBuilder
    {
        private int _number = 1;
        private string _name = "Name";
        private string _statusDescription = "Created";
        private DateTime _endDate = DateTime.UtcNow;
        private double _price = 500.36;
        private int _customerNumber = 1001;
        private string _notes = "notes";
        private bool _isFinished = true;
        private int _contributorNumber = 123;

        public ProjectResponse Build() =>
            new ProjectResponse()
            {
                Number = _number,
                Name = _name,
                StatusDescription = _statusDescription,
                EndDate = _endDate,
                Price = _price,
                CustomerNumber = _customerNumber,
                Notes = _notes,
                IsFinished = _isFinished,
                ContributorNumber = _contributorNumber,
            };

        public List<ProjectResponse> BuildList() =>
            new List<ProjectResponse>() 
            {
                new ProjectResponse()
                {
                    Number = _number,
                    Name = _name,
                    StatusDescription = _statusDescription,
                    EndDate = _endDate,
                    Price = _price,
                    CustomerNumber = _customerNumber,
                    Notes = _notes,
                    IsFinished = _isFinished,
                    ContributorNumber = _contributorNumber,
                },
                new ProjectResponse
                {
                    Number = _number + 1,
                    Name = _name,
                    StatusDescription = _statusDescription,
                    EndDate = _endDate,
                    Price = _price + 1,
                    CustomerNumber = _customerNumber + 1,
                    Notes = _notes,
                    IsFinished = _isFinished,
                    ContributorNumber = _contributorNumber + 1,
                }
            };
    }
}
