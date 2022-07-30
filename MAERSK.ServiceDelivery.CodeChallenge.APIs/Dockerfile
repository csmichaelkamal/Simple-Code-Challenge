#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["MAERSK.ServiceDelivery.CodeChallenge.APIs/MAERSK.ServiceDelivery.CodeChallenge.APIs.csproj", "MAERSK.ServiceDelivery.CodeChallenge.APIs/"]
RUN dotnet restore "MAERSK.ServiceDelivery.CodeChallenge.APIs/MAERSK.ServiceDelivery.CodeChallenge.APIs.csproj"
COPY . .
WORKDIR "/src/MAERSK.ServiceDelivery.CodeChallenge.APIs"
RUN dotnet build "MAERSK.ServiceDelivery.CodeChallenge.APIs.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MAERSK.ServiceDelivery.CodeChallenge.APIs.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MAERSK.ServiceDelivery.CodeChallenge.APIs.dll"]