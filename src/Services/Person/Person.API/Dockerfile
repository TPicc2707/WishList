#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Services/Person/Person.API/Person.API.csproj", "Services/Person/Person.API/"]
COPY ["Services/Person/Person.Application/Person.Application.csproj", "Services/Person/Person.Application/"]
COPY ["Services/Person/Person.Domain/Person.Domain.csproj", "Services/Person/Person.Domain/"]
COPY ["Services/Person/Person.Infrastructure/Person.Infrastructure.csproj", "Services/Person/Person.Infrastructure/"]
RUN dotnet restore "Services/Person/Person.API/Person.API.csproj"
COPY . .
WORKDIR "/src/Services/Person/Person.API"
RUN dotnet build "Person.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Person.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Person.API.dll"]
