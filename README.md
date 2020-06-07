# PaymentDemo
 This is a code challenge.

How To:

- Run this project in Docker:
Go to Docker and run "Run.ps1" with PowerShell.

- Run this project in Visual Studio:
Clone this Repo. Run it using PaymentDemo profile (instead of IIS Express).
Packages should restore themselves automatically.

The only endpoint is located at: http://localhost:5000/api/payments (use a POST verb)
Or even better, try out its basic Swagger documentation: http://localhost:5000/swagger

The app will automatically create and seed its database.

Extra info:
The App is built with ASP.NET Core 3.1
Following NuGet Packages have been used:
- AutoMapper.Extensions.Microsoft.DependencyInjection 7.0.0
- FluentValidation.AspNetCore 8.6.2
- Microsoft.EntityFrameworkCore 3.1.4
- Microsoft.EntityFrameworkCore.SqlServer 3.1.4
- Microsoft.EntityFrameworkCore.Tools 3.1.4
- Swashbuckle.AspNetCore 5.4.1
- covrelet.collector 1.2.0
- FluentAssertions 5.10.3
- Microsoft.Net.Test.Sdk 16.5.0
- Moq 4.14.1
- xunit 2.4.0
- xunit.runner.visualstudio 2.4.0

