# MAERSK Service Delivery APIs

## This Repo is private, secure and is only visible for MAERSK

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


### Supported Currencies
1. USD
2. EUR
3. DKK
4. GBP

### Terminologies used in this project
- `container`: this word is for the [intermodal container](https://en.wikipedia.org/wiki/Intermodal_container){target="_blank"},
don't get confused with [virtualization Container](https://en.wikipedia.org/wiki/OS-level_virtualization#:~:text=OS%2Dlevel%20virtualization%20is%20an%20operating%20system%20(OS)%20paradigm%20in%20which%20the%20kernel%20allows%20the%20existence%20of%20multiple%20isolated%20user%20space%20instances%2C%20called%20containers){target="_blank"}