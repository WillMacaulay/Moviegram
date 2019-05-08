This layer contains classes e.g. WebAPI / applications for presentation / DTOs(API Models).

DEVELOPMENT
Used Visual Code - but would normally used Visual Studio (didn't have on this machine)
Built using:
    dotnet build 
    dotnet run

APIs
Async code is used - where possible


EF CORE
EF Core (ORM) acts as a respository pattern as it can be easily be used to swap out for other database providers
I used SqlLite as the EF Core provider - could have used SQL Server - but was dependent on the OS i had 
on this windows 8.1 machine 
Also used a code first approach (as i was starting afresh) - database create using:
    migrations 
        dotnet ef migrations add InitialCreate
        dotnet ef database update

    and packages 
        dotnet add package Microsoft.EntityFrameworkCore.Sqlite
        dotnet add package Microsoft.EntityFrameworkCore.Design

        Seeded the database in the controller (just for simplicy) - but could easily have created seed database
        and then add-migration seeddata
    
DEPENDENCY Injection - couple of examples
Added EF Core db context to services (Startup.cs) to inject it where needed
services.AddDbContext<MovieContext>(options => options.UseSqlite("Data Source=c:\\sqllite\\movies.sdb"));
Added logger and sample log message in controller

SWAGGER
https://localhost:5001/index.html
Swashbuckle package used for API documentation and also useful for testing
Just for info - can also use swagger json and swagger codegen to generate frontend client code - 
really useful - but not needed here for this demo
Used ConfigureServices in Startup.cs to setup swagger service, and Configure to set up in the pipeline

MOVIE IMAGES
These are stored on the server in the Images folder - and not directly in the database 
The name of the generated file gets stored in the database - and the image is loaded on FrontEnd using that
An API is provided to load the images 
