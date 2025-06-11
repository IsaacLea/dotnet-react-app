* Implementation notes


** Adding unit/integration tests to the project
- The following guide was used to setup integration tests:
  https://learn.microsoft.com/en-us/aspnet/core/test/integration-tests?view=aspnetcore-9.0&pivots=xunit
- Added the following line to the ReactApp1.Server Program.cs:
  public partial class Program { }
- Registered the UserController class in ReactApp1.Server Program.cs so that it can be used by the test project:
  builder.Services.AddScoped<UserController>();
- Added the following to ReactApp1.Server.csproj:
  <ItemGroup>
     <InternalsVisibleTo Include="ServerTestProject" />
  </ItemGroup>

** Repository layer
- I have added a repository layer for encapsulated data access logic.  
  Some say that EF itself is a repository and adding an explicit layer is redundant, but I prefer to have a separate layer for data access logic.  This allows for better separation of concerns and makes it easier to swap out the data access technology if needed in the future.
  The alternative is to inject DbContext into the service layer which would be simpler.
- There is an approach of returning IQueryable instead of IEnumerable from the repo layer queries to allow the business logic to customize the query before execution, but this has the downside of making the repo layer lest testable and leaking database logic into the service layer.

** Exception handling
- The developer error page is enabled by default when running in Dev mode (includes stack trace and some additional info)
- For non development, an ErrorController is added with a /error route registered in program.cs

** Input validation
- Only basic manual input validation has been added on the controller.  Consider using FluentValidator to setup validation rules on DTOs.