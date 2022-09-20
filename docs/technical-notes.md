## Architecture Decisions  

**Timelogger.Api**    
API project. 
ProjectsController exposes CRUD methods for projects (not all of them are implemented). 
Main methods: Create single project, Get single project, Get all projects 

TimeEntriesController exposes CRUD methos for timeEntries (not all of them are implemented).
Main methods: Create single entry, Get single entry, Get all entries
Extra: 
Get Time Entries by project - return time entries of specific contributor(param) on a specific project(param)
Get Time Entries overview - return a sum of hours of specific contributor(param) on each project.  

Services injection (cqrs, repositories) and InMemory database defined on Startup.cs 

Packages:  
Swashbuckle/Swagger: web interface to API 
  
**Timelogger.Api.Commands**    
CQRS Pattern - Commands (Post action).  
Receive Project/TimeEntry request, map to respective entities and send action to repository to store in database. 
  
**Timelogger.Api.Queries**   
CQRS Pattern - Queries (Get action).  
Receive an id or search request, queries the database and returns the information for the controllers.  
  
**Timelogger.Api.Domain**  
Domain Aggregates (request/response)  
  
**Timelogger**  
DataModel(entities) and definition of inMemory Database context.  
Repositories for database actions.
By default (on startup) API creates 2 projects and 3 time entries. 

Packages:  
Microsoft.EntityFrameworkCore.InMemory  
  
**Timelogger.Tests**  
Using nUnit and Moq to mock commands,queries and repositories 

**Timelogger Client (UI)**
UI application.

React based with typescript.

- api/ - API requests (post/get)
- components/ - react components definition (mostly tables)
- models/ - models to be used in the UI
- views/ - UI views, makes use of react components

Index page requires a contributor number (id). This aims to emulate a login/authorization/authentication mechanism.
Information is stored in the localStorage.
A final version should get rid of this approach and implement a proper authorization/authentication.

## Further Developments
- [ ] Add logging (example: Serilog, Log4Net, etc.)
- [ ] Add and publish metrics (example: Prometheus + Grafana)
- [ ] Add validations on API requests
- [ ] Better database design (keys, relationships)  
- [ ] Publish docker image on automated build
- [ ] Improve unit tests  
- [ ] Include integration and performance tests 
- [ ] UI tests  
- [ ] API client  
- [ ] API Authentication
- [ ] UI logins / user management  
  
## Demo  
Tutorial/demo, please go to -->  [Demo](/docs/demo.md)
