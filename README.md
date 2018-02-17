# Setup


## Create Project Directory

```bash
$ mkdir Company.LocationService
```

## Create Solution

In the root folder of `Company.LocationService`, run:

```bash
$ dotnet new sln
```

## Create New Project

```bash
$ dotnet new mvc -o Company.LocationService

# Add the project to the solution
$ dotnet sln add ./Company.LocationService/Company.LocationService.csproj
```

## Create New Test Project

In the root directory of `Company.LocationService`, create a folder:
```bash
$ mkdir Company.LocationService.Tests

# Enter the folder and init test project
$ cd Company.LocationService.Tests
$ dotnet new xunit

# Back to top directory
$ cd ../

# Add test project to solution
$ dotnet sln add ./Company.LocationService.Tests/Company.LocationService.Tests.csproj
```

## Testing

```bash
# Go to test project directory
$ cd Company.LocationService.Tests

# Execute tests
$ dotnet test
```

## Running

```bash
# Go to main project directory
$ cd Company.LocationService

# Execute main
$ dotnet run
```

## Adding PostgreSQL Database

```bash
$ dotnet add package Microsoft.EntityFrameworkCore
$ dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
$ dotnet add package Microsoft.EntityFrameworkCore.Design
```

## Running migration

```bash
$ dotnet ef database update
# If you hit this error: No executable found matching command "dotnet-ef"
# Check if this is included in your .csproj
# <DotNetCliToolReference Include="Microsoft.EntityFrameworkCore.Tools.DotNet" Version="2.0.0" />
```

If the following message appear, it means there are no migrations created. To create a new migration, run `$ dotnet ef migrations add InitialMigration`, then `$ dotnet ef database update`.

```bash
info: Microsoft.AspNetCore.DataProtection.KeyManagement.XmlKeyManager[0]
      User profile is available. Using '/Users/alextanhongpin/.aspnet/DataProtection-Keys' as key repository; keys will not be encrypted at rest.
No migrations were applied. The database is already up to date.
Done.
```

## To access the psql cli

```
$ docker exec -it 46897d65b649 psql -h database -U john -d locationservice
```