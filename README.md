# MAERSK Service Delivery APIs

## This Repo is private, secure and is only visible for MAERSK

This is a very simple APIs for managing Voyage Container Prices, like updating the voyage price,
and retriving the average container price for the last 10 voyages for a given currency.
See below for the suppoerted currencies

Providing two main APIs (and one utility endpoint):
1. `UpdatePrice`
1. `GetAveragePrice`

Tools and Technologies used in this project:
- .Net Core
- Asp.Net Core (API)
- C# as a programming language
- Entity Framework Core (EF Core) with InMemory Db
- Visual Studio 2019
- Docker (on linux)
- API Verioning
- Swagger (Open API) via SwashBuckle library 

### We should:
- Use a cache for our APIs, like Redis or Memcached
- Use a mapper like Automapper
- Securing the APIs via OAuth2.0 and OpenId Connect (maybe via IdentityServer4)


### Supported Currencies
1. USD
2. EUR
3. DKK
4. GBP

### Terminologies used in this project
- container: this word is for the physical containers, don't get confused with Docker Container