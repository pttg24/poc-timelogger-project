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

    public class ProjectQueryTests
    {
        private readonly Mock<IProjectRepository> _projectRepository = new Mock<IProjectRepository>();

        [TestCase(1)]
        [TestCase(2)]
        public async Task ShouldGetProject(int id)
        {
            var project = new Project(id,"name",DateTime.UtcNow,1.5,1,"notes",true,1,Entities.ProjectStatuses.Created);

            _projectRepository
                .Setup(q => q.GetProjectAsync(It.IsAny<int>()))
                .Returns(Task.FromResult(project));

            var result = await GetSut().GetProject(id);

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

        [Test]
        public async Task ShouldGetAllProjects()
        {
            var project1 = new Project(1, "name", DateTime.UtcNow, 1.5, 1, "notes", true, 1, Entities.ProjectStatuses.Created);
            var project2 = new Project(2, "name", DateTime.UtcNow, 1.5, 1, "notes", true, 1, Entities.ProjectStatuses.Created);
            List<Project> projectsList = new List<Project>
            {
                project1,
                project2
            };

            _projectRepository
                .Setup(q => q.GetAllProjectsAsync())
                .Returns(Task.FromResult(projectsList));

            var result = await GetSut().GetAllProjects();

            result.ShouldSatisfyAllConditions(() =>
            {
                result.ShouldNotBeNull();
                result.Count().ShouldBe(2);
                result.First().ContributorNumber.ShouldBe(project1.ContributorNumber);
                result.First().CustomerNumber.ShouldBe(project1.CustomerNumber);
                result.First().EndDate.ShouldBe(project1.EndDate);
                result.First().IsFinished.ShouldBe(project1.IsFinished);
                result.First().Name.ShouldBe(project1.Name);
                result.First().Notes.ShouldBe(project1.Notes);
                result.First().Number.ShouldBe(project1.Id);
                result.First().Price.ShouldBe(project1.Price);
            });
        }

        private ProjectQuery GetSut() => new ProjectQuery(_projectRepository.Object){};
    }
}