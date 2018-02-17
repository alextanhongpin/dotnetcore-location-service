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