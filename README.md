# EducationProcess
A project designed to correct a misunderstanding with getting a schedule from college, as well as replace routine work with automation

## Whats Including In This Repository

#### Api/EducationProcess.* which includes; 
* **ASP.NET** Web API application
* REST API principles
* **Swagger** Open API implementation	
* **Repository** Pattern implementation
* **UnitOfWork** Pattern implementation
* Using **Entity Framework Core** ORM
* Using **AutoMapper** Object Mapping 
* Using **FluentValidation**
* Using **Fluent Assertions** for **xUnit** unit testing

## Run The Project
You will need the following tools:

* [Visual Studio 2019](https://visualstudio.microsoft.com/downloads/)
* [.Net 5](https://dotnet.microsoft.com/download/dotnet/5.0)
* [dotnet-ef](https://docs.microsoft.com/en-us/ef/core/cli/dotnet)
* [Git Bash](https://git-scm.com/downloads)
* [MySQL Community Server 8.0 or above](https://dev.mysql.com/downloads/mysql/)

### Configuration
Follow these steps to get your development environment set up: (Before building this project)
1. Clone this repository:
```
git clone https://github.com/NotKohtpojiep/EducationProcess
```
2. Go to *EducationProcess/src* folder and restore nuget-packages:
```
cd EducationProcess/src
dotnet restore EducationProcess.sln
```
3. Make sure that the database connection strings are correct in _EducationProcess/src/Api/EducationProcess.Api/_**appsettings.Development.json**:
```json
...
"ConnectionStrings": {
    "ConnectionDbContext": "server=localhost;user=root;password=1234;database=EducationProcess;",
    "IdentityServerUrl": "https://localhost:5001"
  }
...
```
4. Migrate database into your MySQL server:
```
cd Api/EducationProcess.DataAccess
dotnet-ef database update -s ../EducationProcess.Api
```
5. Back to *EducationProcess/src* folder, build and run
```
cd ../..
dotnet build EducationProcess.sln
start /d "." dotnet run --project ./Api/EducationProcess.Api/EducationProcess.Api.csproj
start /d "." dotnet run --project ./Identity/Identity.Api.csproj
```
6. You can **connect** using below urls:

* **EducationProcess.API: https://localhost:5005/swagger/index.html**
* **Identity.API: https://localhost:5001/auth**