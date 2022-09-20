namespace Timelogger.Api.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Timelogger.Api.Domain;

    public class ProjectRequestBuilder
    {
        private string _name = "Name";
        private DateTime _endDate = DateTime.UtcNow;
        private double _price = 500.36;
        private int _customerNumber = 1001;
        private string _notes = "notes";
        private bool _isFinished = true;
        private int _contributorNumber = 123;

        public ProjectRequest Build() =>
            new ProjectRequest()
            {
                Name = _name,
                EndDate = _endDate,
                Price = _price,
                CustomerNumber = _customerNumber,
                Notes = _notes,
                IsFinished = _isFinished,
                ContributorNumber = _contributorNumber,
            };
    }
}
