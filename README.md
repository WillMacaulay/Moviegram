Sample API application created using Visual Code and C# and dotnet core 2.2
Note - Would normally have used Visual Studio (but didn't have on this machine)

Runinng the application:
In src\WebUI folder - build using 'dotnet build' and then run using 'dotnet run'

Initially access default ValuesController in browser:
https://localhost:5001/api/values


EF CORE
EF Core (ORM) acts as a respository pattern as it can be easily be used to swap out for other database providers
I used SqlLite as the EF Core provider - could have used SQL Server - but was dependent on the OS i had 
on this windows 8.1 machine 
Also used a code first approach (as i was starting afresh) - database create using:
    migrations 
        dotnet ef migrations add InitialCreate
        dotnet ef database update


Now can access https://localhost:5001/api/Movie