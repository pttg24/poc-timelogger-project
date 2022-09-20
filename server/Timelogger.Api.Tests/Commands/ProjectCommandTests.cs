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

    public class ProjectCommandTests
    {
        private readonly Mock<IProjectRepository> _projectRepository = new Mock<IProjectRepository>();

        [Test]
        public async Task ShouldCreateProject()
        {
            ProjectRequest prequest = new ProjectRequestBuilder().Build();
            ProjectResponse presponse = new ProjectResponseBuilder().Build();

            var project = new Project(1, "name", DateTime.UtcNow, 1.5, 1, "notes", true, 1, Entities.ProjectStatuses.Created);

            _projectRepository
                .Setup(q => q.CreateProjectAsync(It.IsAny<Project>()))
                .Returns(Task.FromResult(project));

            var result = await GetSut().CreateProject(prequest);

            result.ShouldSatisfyAllConditions(() =>
            {
                result.ShouldNotBeNull();
                result.ContributorNumber.ShouldBe(project.ContributorNumber);
                result.CustomerNumber.ShouldBe(project.CustomerNumber);
                result.EndDate.ShouldBe(project.EndDate);
                result.IsFinished.ShouldBe(project.IsFinished);
                result.Name.ShouldBe(project.Name);
                result.Notes.ShouldBe(project.Notes);
                result.Number.ShouldBe(project.Id);
                result.Price.ShouldBe(project.Price);
            });
        }

        private ProjectCommand GetSut() => new ProjectCommand(_projectRepository.Object) { };
    }
}