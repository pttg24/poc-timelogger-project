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

    public class ProjectsControllerTests
    {
        private readonly Mock<IProjectCommand> _projectCommand = new Mock<IProjectCommand>();
        private readonly Mock<IProjectQuery> _projectQuery = new Mock<IProjectQuery>();

        [Test]
        public async Task GetProjectReturnsSuccess()
        {
            ProjectResponse pr = new ProjectResponseBuilder().Build();

            _projectQuery
                .Setup(q => q.GetProject(It.IsAny<int>()))
                .Returns(Task.FromResult(pr));

            var response = await GetSut().GetProject(It.IsAny<int>());

            response.ShouldNotBeNull();
            response.ShouldBeOfType<OkObjectResult>();
        }

        [Test]
        public async Task GetAllProjectsReturnsSuccess()
        {
            IEnumerable<ProjectResponse> pr = new ProjectResponseBuilder().BuildList().AsEnumerable();

            _projectQuery
                .Setup(q => q.GetAllProjects())
                .Returns(Task.FromResult(pr));

            var response = await GetSut().GetAllProjects();

            response.ShouldNotBeNull();
            response.ShouldBeOfType<OkObjectResult>();
        }

        [Test]
        public async Task DeleteProjectReturnsNotAllowed()
        {
            var response = GetSut().DeleteProject();

            response.ShouldNotBeNull();
            response.ShouldBeOfType<StatusCodeResult>();
            response.Equals(HttpStatusCode.MethodNotAllowed);
        }

        [Test]
        public async Task CreateProjectReturnsSuccess()
        {
            ProjectRequest prequest = new ProjectRequestBuilder().Build();
            ProjectResponse presponse = new ProjectResponseBuilder().Build();

            _projectCommand
                .Setup(c => c.CreateProject(It.IsAny<ProjectRequest>()))
                .Returns(Task.FromResult(presponse));

            var response = await GetSut().CreateProject(prequest);

            response.ShouldNotBeNull();
            response.ShouldBeOfType<OkObjectResult>();
        }


        private ProjectsController GetSut() => new ProjectsController(_projectCommand.Object, _projectQuery.Object)
        {
            ControllerContext = { HttpContext = new DefaultHttpContext() }
        };
    }
} 
