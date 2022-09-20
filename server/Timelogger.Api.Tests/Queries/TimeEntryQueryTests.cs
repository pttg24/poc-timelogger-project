namespace Timelogger.Api.Tests.Queries
{
    using Timelogger.Repositories;
    using Timelogger.Entities;
    using Timelogger.Api.Queries;
    using NUnit.Framework;
    using Moq;
    using Shouldly;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using System.Linq;
    using System;

    public class TimeEntryQueryTests
    {
        private readonly Mock<ITimeEntryRepository> _timeEntryRepository = new Mock<ITimeEntryRepository>();

        [TestCase(1)]
        [TestCase(2)]
        public async Task ShouldGetTimeEntry(int id)
        {
            var entry = new TimeEntry(id, 1, DateTime.UtcNow, DateTime.UtcNow, 1, 24, "notes");

            _timeEntryRepository
                .Setup(q => q.GetTimeEntryAsync(It.IsAny<int>()))
                .Returns(Task.FromResult(entry));

            var result = await GetSut().GetTimeEntry(id);

            result.ShouldSatisfyAllConditions(() =>
            {
                result.ShouldNotBeNull();
                result.ContributorNumber.ShouldBe(entry.ContributorNumber);
                result.ProjectNumber.ShouldBe(entry.ProjectNumber);
                result.EntryDate.ShouldBe(entry.EntryDate);
                result.InsertedAt.ShouldBe(entry.InsertedAt);
                result.Hours.ShouldBe(entry.Hours);
                result.Notes.ShouldBe(entry.Notes);
                result.Id.ShouldBe(entry.Id);
            });
        }

        [Test]
        public async Task ShouldGetAllTimeEntries()
        {
            var entry1 = new TimeEntry(1, 1, DateTime.UtcNow, DateTime.UtcNow, 1, 24, "notes");
            var entry2 = new TimeEntry(2, 1, DateTime.UtcNow, DateTime.UtcNow, 1, 24, "notes");
            List<TimeEntry> timeEntriesList = new List<TimeEntry>
            {
                entry1,
                entry2
            };

            _timeEntryRepository
                .Setup(q => q.GetAllTimeEntriesAsync())
                .Returns(Task.FromResult(timeEntriesList));

            var result = await GetSut().GetAllTimeEntries();

            result.ShouldSatisfyAllConditions(() =>
            {
                result.ShouldNotBeNull();
                result.Count().ShouldBe(2);
                result.First().ContributorNumber.ShouldBe(entry1.ContributorNumber);
                result.First().ProjectNumber.ShouldBe(entry1.ProjectNumber);
                result.First().EntryDate.ShouldBe(entry1.EntryDate);
                result.First().InsertedAt.ShouldBe(entry1.InsertedAt);
                result.First().Hours.ShouldBe(entry1.Hours);
                result.First().Notes.ShouldBe(entry1.Notes);
                result.First().Id.ShouldBe(entry1.Id);
            });
        }

        private TimeEntryQuery GetSut() => new TimeEntryQuery(_timeEntryRepository.Object) { };
    }
}