namespace Timelogger.Api.Tests.Controllers
{
    using Timelogger.Api.Controllers;
    using Timelogger.Api.Commands;
    using Timelogger.Api.Queries;
    using NUnit.Framework;
    using Microsoft.AspNetCore.Mvc;
    using Moq;
    using Shouldly;
    using System.IO;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Timelogger.Api.Domain;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System;

    public class TimeEntriesControllerTests
    {
        private readonly Mock<ITimeEntryCommand> _timeEntryCommand = new Mock<ITimeEntryCommand>();
        private readonly Mock<ITimeEntryQuery> _timeEntryQuery = new Mock<ITimeEntryQuery>();

        [Test]
        public async Task GetTimeEntryReturnsSuccess()
        {
            TimeEntryResponse ter = new TimeEntryResponseBuilder().Build();

            _timeEntryQuery
                .Setup(q => q.GetTimeEntry(It.IsAny<int>()))
                .Returns(Task.FromResult(ter));

            var response = await GetSut().GetTimeEntry(It.IsAny<int>());

            response.ShouldNotBeNull();
            response.ShouldBeOfType<OkObjectResult>();
        }

        [Test]
        public async Task GetAllProjectsReturnsSuccess()
        {
            IEnumerable<TimeEntryResponse> ter = new TimeEntryResponseBuilder().BuildList().AsEnumerable();

            _timeEntryQuery
                .Setup(q => q.GetAllTimeEntries())
                .Returns(Task.FromResult(ter));

            var response = await GetSut().GetAllTimeEntries();

            response.ShouldNotBeNull();
            response.ShouldBeOfType<OkObjectResult>();
        }

        [Test]
        public async Task DeleteTimeEntryReturnsNotAllowed()
        {
            var response = GetSut().DeleteTimeEntry();

            response.ShouldNotBeNull();
            response.ShouldBeOfType<StatusCodeResult>();
            response.Equals(HttpStatusCode.MethodNotAllowed);
        }

        [Test]
        public async Task UpdateTimeEntryReturnsNotImplement()
        {
            var response = GetSut().DeleteTimeEntry();

            response.ShouldNotBeNull();
            response.ShouldBeOfType<StatusCodeResult>();
            response.Equals(HttpStatusCode.NotImplemented);
        }

        [Test]
        public async Task CreateTimeEntryReturnsSuccess()
        {
            TimeEntryRequest trequest = new TimeEntryRequestBuilder().Build();
            TimeEntryResponse tresponse = new TimeEntryResponseBuilder().Build();

            _timeEntryCommand
                .Setup(c => c.CreateTimeEntry(It.IsAny<TimeEntryRequest>()))
                .Returns(Task.FromResult(tresponse));

            var response = await GetSut().CreateTimeEntry(trequest);

            response.ShouldNotBeNull();
            response.ShouldBeOfType<OkObjectResult>();
        }


        private TimeEntriesController GetSut() => new TimeEntriesController(_timeEntryCommand.Object, _timeEntryQuery.Object)
        {
            ControllerContext = { HttpContext = new DefaultHttpContext() }
        };
    }
}