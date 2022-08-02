# MAERSK Service Delivery APIs

## This Repo is private, secure and is only visible for MAERSK

## TL;DR
To Run the project:
- You need .Net SDK 3.1
- You can run it on Visual Studio [2022](https://visualstudio.microsoft.com/downloads/), [vscode](https://code.visualstudio.com/),
or from the cmd using [.Net CLI](https://docs.microsoft.com/en-us/dotnet/core/sdk)
- Make sure that the API project is set as the startup project
- Press Ctrl+F5 (visual studio) or
	- From the command line, run:
		- `dotnet restore`
		- `dotnet build --no-restore`
		- `dotnet run --no-build MAERSK.ServiceDelivery.CodeChallenge.APIs.dll`, `--no-restore` is called implicitly 
		- Note: you can directly run `dotnet run ...`, it will implicitly restore and build the project

This is a very simple API project for managing Voyage [Container](#terminologies-used-in-this-project) Prices, like updating the voyage price,
and retrieving the average container price for the last 10 voyages for a given currency.
See below for the [supported currencies](#supported-currencies)

Providing two main APIs (and one utility endpoint):
1. `UpdatePrice`
1. `GetAveragePrice`

Tools and Technologies used in this project:
- .Net Core
- Asp.Net Core (API)
- C#
- Entity Framework Core (EF Core) with InMemory Db
- Visual Studio 2019
- Docker (on linux)
- API Versioning
- Swagger (Open API) via SwashBuckle library 

### We should:
- Use a cache for our APIs, like Redis or Memcached
- Use a mapper like Automapper
- Securing the APIs via OAuth2.0 and OpenId Connect (maybe via IdentityServer4)
- Use [Repository Pattern](https://deviq.com/design-patterns/repository-pattern) and [UnitOfWork](https://dotnettutorials.net/lesson/unit-of-work-csharp-mvc/#:~:text=The%20Unit%20of%20Work%20pattern,or%20fail%20as%20one%20unit.),
but because of being a small project with just few [CRUD](https://en.wikipedia.org/wiki/Create,_read,_update_and_delete) operations, we didn't use it

### Supported Currencies
1. USD
2. EUR
3. DKK
4. GBP

### Terminologies used in this project
- `container`: this word is for the [intermodal container](https://en.wikipedia.org/wiki/Intermodal_container),
don't get confused with [virtualization Container](https://en.wikipedia.org/wiki/OS-level_virtualization#:~:text=OS%2Dlevel%20virtualization%20is%20an%20operating%20system%20(OS)%20paradigm%20in%20which%20the%20kernel%20allows%20the%20existence%20of%20multiple%20isolated%20user%20space%20instances%2C%20called%20containers)