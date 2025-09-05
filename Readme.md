# LibraryApi – Setup & Required Packages

This project is an ASP.NET Core Web API for managing a library of books.  
If you clone or pull this repository, you’ll need the following NuGet packages to build, run, and test the API.

---

## Required Packages

| Package Name                   | Purpose                                 |
|--------------------------------|-----------------------------------------|
| Swashbuckle.AspNetCore         | Swagger/OpenAPI documentation           |
| Microsoft.AspNetCore.OpenApi   | OpenAPI support for ASP.NET Core        |
| Microsoft.NET.Test.Sdk         | Test runner for .NET                    |
| xunit                          | Unit testing framework                  |
| xunit.runner.visualstudio      | xUnit test runner integration           |
| Moq                            | Mocking framework for unit tests        |
| Newtonsoft.Json                | JSON serialization (optional)           |

---

## How to Restore Packages

After cloning, run this command in the project folder:

```powershell
dotnet restore
```

---

## How to Build and Run

```powershell
dotnet build
dotnet run
```

---

## How to Run Unit Tests

```powershell
dotnet test
```

---

## Troubleshooting

- If you get errors about missing packages, run `dotnet restore`.
- Make sure you have the .NET SDK installed (version 9.0 or compatible).

---

## Notes

- All required packages are listed in `LibraryApi.csproj`.
- If you add new dependencies, update this info file and