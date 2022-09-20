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
    public class TimeEntriesController : Controller
    {
        private readonly ITimeEntryCommand _timeEntryCommand;
        private readonly ITimeEntryQuery _timeEntryQuery;

        public TimeEntriesController(ITimeEntryCommand timeEntryCommand, ITimeEntryQuery timeEntryQuery)
        {
            _timeEntryCommand = timeEntryCommand;
            _timeEntryQuery = timeEntryQuery;
        }

        [HttpGet]
        [Route("all")]
        [ProducesResponseType(typeof(OkResult), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllTimeEntries()
        {
            var result = await _timeEntryQuery.GetAllTimeEntries();
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(OkResult), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetTimeEntry(int id)
        {
            var result = await _timeEntryQuery.GetTimeEntry(id);
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(typeof(OkResult), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetTimeEntriesByProject(int project, int contributor)
        {
            var result = await _timeEntryQuery.GetTimeEntriesByProject(project, contributor);
            return Ok(result);
        }

        [HttpGet]
        [Route("overview/{contributor}")]
        [ProducesResponseType(typeof(OkResult), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetTimeEntriesOverview(int contributor)
        {
            var result = await _timeEntryQuery.GetTimeEntriesOverview(contributor);
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(OkResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BadRequestResult), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateTimeEntry([FromBody] TimeEntryRequest request)
        {
            var result = await _timeEntryCommand.CreateTimeEntry(request);
            return Ok(result);
        }

        [HttpPut]
        [ProducesResponseType(typeof(BadRequestResult), StatusCodes.Status501NotImplemented)]
        public IActionResult UpdateTimeEntry(int id, int? contributorNumber, int? projectNumber)
        {
            //Not Implemented
            return new StatusCodeResult(StatusCodes.Status501NotImplemented);
        }

        [HttpDelete]
        [ProducesResponseType(typeof(StatusCodeResult), StatusCodes.Status405MethodNotAllowed)]
        public IActionResult DeleteTimeEntry()
        {
            //Delete action not allowed
            return new StatusCodeResult(StatusCodes.Status405MethodNotAllowed);
        }
    }
}