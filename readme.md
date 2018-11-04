# DotNetArchitecture

Solution to apply and share new knowledge and technologies and to serve as architecture for new projects.

## Tools, Practices and Technologies

* Cross-Platform (Windows, Linux, macOS)
* Docker
* Visual Studio 2017
* Visual Studio Code
* .NET Core 2.1.5
* ASP.NET Core 2.1.5
* Entity Framework Core 2.1.4
* SQL Server 2017
* MongoDB
* C# 7.3
* SPA (Single Page Application)
* Angular 7.0.2
* Typescript 3.1.6
* HTML5
* CSS3
* SASS (Syntactically Awesome Style Sheets)
* UIkit
* DDD (Domain-Driven Design)
* SOLID Principles
* Dependency Injection
* Mapping
* Logging
* Unit Test
* JWT (Json Web Token)
* Response Caching
* Response Compression (Brotli)
* Code Analysis (Ruleset, TSLint and Codacy)
* Swagger

## Code Analysis

[![Codacy](https://api.codacy.com/project/badge/Grade/6eef5f26173c4b80824a2eeb0b4f9ab9)](https://www.codacy.com/app/rafaelfgx/DotNetArchitecture?utm_source=github.com&amp;utm_medium=referral&amp;utm_content=rafaelfgx/DotNetArchitecture&amp;utm_campaign=Badge_Grade)

## Layers

![Screenshot](screenshots/layers.png)

**Web:** This layer contains the api and the frontend, responsible for interaction with the user to obtain and display data.

**Application:** This layer is the main entry point of the application.

**Domain:** This layer contains the requirements and the business logic, it is the core of the application.

**Infrastructure:** This layer isolates and abstracts the logic required for data persistence.

**Model:** This layer is responsible for modeling the domain classes according with the business context.

**CrossCutting:** This layer provides generic features for the other layers.

**Tests:** It is responsible for testing individual units of the code.

## Projects

![Screenshot](screenshots/projects.png)

## Application

![Screenshot](screenshots/layer-application.png)

## Domain

![Screenshot](screenshots/layer-domain.png)

## Repository

![Screenshot](screenshots/layer-repository.png)

## Unit Test

![Screenshot](screenshots/layer-test.png)

## ASP.NET Core + Angular

![Screenshot](screenshots/aspnetcore-angular.png)

## ASP.NET Core Startup

![Screenshot](screenshots/aspnetcore-startup.png)

## ASP.NET Core Controller

![Screenshot](screenshots/aspnetcore-controller.png)

## Angular Guard

![Screenshot](screenshots/angular-guard.png)

## Angular Error Handler

![Screenshot](screenshots/angular-error-handler.png)

## Angular HTTP Interceptor

![Screenshot](screenshots/angular-http-interceptor.png)

## Angular Service

![Screenshot](screenshots/angular-service.png)

## Angular Component

![Screenshot](screenshots/angular-component.png)

## ASP.NET Core + Angular + Entity Framework Core + SQL Server Performance

![Screenshot](screenshots/aspnetcore-angular-performance.png)

**Specifications:**

**Processor:** Intel Core I7 8700K Coffee Lake 8th-generation.

**Memory:** 16GB 2400Mhz DDR4.

**Storage:** Samsung Evo 960 SSD M2 250gb.

**OS:** Windows 10 Pro 64 bits.

**Web Server:** Kestrel.

**Database:** SQL Server 2017 Developer Edition.

## Swagger

![Screenshot](screenshots/swagger.png)

## Run Command Line

1. Install latest [.NET Core SDK](https://aka.ms/dotnet-download).

2. Open directory **source\Web\App\Frontend** in command line and execute **npm run restore**.

3. Open directory **source\Web\App** in command line and execute **dotnet run**.

4. Open <https://localhost:8090>.

## Run Visual Studio Code

1. Install latest [.NET Core SDK](https://aka.ms/dotnet-download).

2. Install [C# Extension](https://marketplace.visualstudio.com/items?itemName=ms-vscode.csharp).

3. Open directory **source\Web\App\Frontend** in command line and execute **npm run restore**.

4. Open **source** directory in Visual Studio Code.

5. Press **F5**.

## Run Visual Studio 2017

1. Install latest [.NET Core SDK](https://aka.ms/dotnet-download).

2. Open directory **source\Web\App\Frontend** in command line and execute **npm run restore**.

3. Open **source\Solution.sln** in Visual Studio.

4. Set **Solution.Web.App** as startup project.

5. Press **F5**.

## Run Docker

1. Install and configure [Docker](https://www.docker.com/get-started).

2. Execute **docker-compose up --build -d --force-recreate** in root directory.

3. Open <http://localhost:8095>.

## Host and Deploy

[Microsoft host and deploy ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/host-and-deploy/index?view=aspnetcore-2.1&tabs=aspnetcore2x)

## Visual Studio Extensions

[CodeMaid](https://marketplace.visualstudio.com/items?itemName=SteveCadwallader.CodeMaid)

[Roslynator](https://marketplace.visualstudio.com/items?itemName=josefpihrt.Roslynator2017)

[SonarLint](https://marketplace.visualstudio.com/items?itemName=SonarSource.SonarLintforVisualStudio2017)

[TSLint](https://marketplace.visualstudio.com/items?itemName=vladeck.TSLint)
