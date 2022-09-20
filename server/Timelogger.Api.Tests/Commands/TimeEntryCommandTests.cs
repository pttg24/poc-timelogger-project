namespace Timelogger.Api.Tests.Commands
{
    using Timelogger.Repositories;
    using Timelogger.Entities;
    using Timelogger.Api.Domain;
    using Timelogger.Api.Commands;
    using NUnit.Framework;
    using Moq;
    using Shouldly;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using System.Linq;
    using System;

    public class TimeEntryCommandTests
    {
        private readonly Mock<ITimeEntryRepository> _timeEntryRepository = new Mock<ITimeEntryRepository>();

        [Test]
        public async Task ShouldCreateProject()
        {
            TimeEntryRequest terequest = new TimeEntryRequestBuilder().Build();

            var entry = new TimeEntry(1, 1, DateTime.UtcNow, DateTime.UtcNow, 1, 24, "notes");

            _timeEntryRepository
                .Setup(q => q.CreateTimeEntryAsync(It.IsAny<TimeEntry>()))
                .Returns(Task.FromResult(entry));

            var result = await GetSut().CreateTimeEntry(terequest);

            result.ShouldSatisfyAllConditions(() =>
            {
                result.ShouldNotBeNull();
                result.ContributorNumber.ShouldBe(entry.ContributorNumber);
                result.ProjectNumber.ShouldBe(entry.ProjectNumber);
                result.EntryDate.ShouldBe(entry.EntryDate);
                result.InsertedAt.ShouldBe(entry.InsertedAt);
                result.Hours.ShouldBe(entry.Hours);
                result.Notes.ShouldBe(entry.Notes);
            });
        }

        private TimeEntryCommand GetSut() => new TimeEntryCommand(_timeEntryRepository.Object) { };
    }
}