* Implementation notes
The following guide was used to setup integration tests:
https://learn.microsoft.com/en-us/aspnet/core/test/integration-tests?view=aspnetcore-9.0&pivots=xunit


- Added the following line to the ReactApp1.Server Program.cs:
  public partial class Program { }
- Registered the UserController class in ReactApp1.Server Program.cs so that it can be used by the test project:
  builder.Services.AddScoped<UserController>();
- Added the following to ReactApp1.Server.csproj:
  <ItemGroup>
     <InternalsVisibleTo Include="ServerTestProject" />
  </ItemGroup>