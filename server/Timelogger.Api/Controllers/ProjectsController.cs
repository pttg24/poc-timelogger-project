namespace Timelogger.Api.Controllers
{  
    using Commands;
    using Domain;
    using Queries;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using System;

    [Route("[controller]")]
	public class ProjectsController : Controller
	{
        private readonly IProjectCommand _projectCommand;
        private readonly IProjectQuery _projectQuery;

        public ProjectsController(IProjectCommand projectCommand, IProjectQuery projectQuery)
		{
            _projectCommand = projectCommand;
            _projectQuery = projectQuery;
		}

		[HttpGet]
        [Route("all")]
        [ProducesResponseType(typeof(OkResult), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllProjects()
		{
            var result = await _projectQuery.GetAllProjects();
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(OkResult), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetProject(int id)
        {
            var result = await _projectQuery.GetProject(id);
            return Ok(result);
        }

		[HttpPost]
        [ProducesResponseType(typeof(OkResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BadRequestResult), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateProject([FromBody]ProjectRequest request)
        {
            var result = await _projectCommand.CreateProject(request);
            return Ok(result);
        }

        [HttpPut]
        [ProducesResponseType(typeof(OkResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BadRequestResult), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateProject(int id, string? name, DateTime? endDate, double? price, string? notes, bool? isFinished, int? status)
        {
            await _projectCommand.UpdateProject(id, name, endDate, price, notes, isFinished, status);
            return Ok();
        }

        [HttpDelete]
        [ProducesResponseType(typeof(StatusCodeResult), StatusCodes.Status405MethodNotAllowed)]
        public IActionResult DeleteProject()
        {
            //Delete action not allowed
            return new StatusCodeResult(StatusCodes.Status405MethodNotAllowed);
        }
    }
}
