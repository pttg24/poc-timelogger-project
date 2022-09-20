# poc-timelogger-project

TimeLogger project 

This project is a POC for a timelogger project. It includes API (.NET) + UI (React) components.

## Task description

The task is to implement a simple time logger web application that solves the following three user stories:

1. As a freelancer I want to be able to register how I spend time on my _projects_, so that I can provide my _customers_ with an overview of my work.
2. As a freelancer I want to be able to get an _overview of my time registrations per project_, so that I can create correct invoices for my customers.
2. As a freelancer I want to be able to _sort my projects by their deadline_, so that I can prioritise my work.

Individual time registrations should be 30 minutes or longer, and once a project is complete it can no longer receive new registrations.

## Technical Summary

**Stack API**  
* .Net Core 3.1, Entity Framework Core (in-memory DB)
* CQRS, Linq
* OpenAPI/Swagger
* nUnit, Moq, Shouldly
* Git, Visual Studio 2022

**Stack UI**  
* React
* NodeJS
* Typescript
* Tailwind

Technical decisions, further developments, conclusions, please go to --> [TechNotes](/docs/technical-notes.md)

Tutorial/demo, please go to -->  [Demo](/docs/demo.md)

## How to Run

To run this project you will need both .NET Core v3.1 and Node installed on your environment.

Server
 `dotnet restore` - to restore nuget packages
 `dotnet build` - to build the solution
 `cd Timelogger.Api && dotnet run` - starts a server on http://localhost:3001. 

The server solution contains an API only with a basic Entity Framework in memory context that acts as a database.

Client
 `npm install` to install dependencies
 `npm start` runs the create-react-app development server on http://localhost:3000

## Screenshots

![GitHub Logo](/docs/01.png)

![GitHub Logo](/docs/02.png)

![GitHub Logo](/docs/03.png)

![GitHub Logo](/docs/04.png)