# Angular CLI ASP.NET Core
## Angular CLI & ASP.NET Core WebAPI in the same project.


#Features
##Angular v13 & ASP.NET Core 6.0.101
##Angular CLI

##Angular CLI, .NET Core CLI or Visual Studio 2019

Project structure



Controllers
ValuesController.cs Resource API
Properties
lanchSettings.json ASP.NET Core environments
ClientApp Angular application
wwwroot Root for Angular application deployment
Startup.cs WebAPI configuration
Installing
Requirements
At least .NET Core 2.1
Node.js and npm
At least Angular CLI 7.0.0
Command line & .NET Core CLI
In ClientApp folder run: npm install
dotnet build
Visual Studio 2017
In ClientApp folder run: npm install
Build the solution
Running
The app will be served on https://localhost:5001

Command line & .NET Core CLI
Development
dotnet watch run
Staging
In ClientApp folder run: npm run build
dotnet run --launch-profile Staging
Visual Studio 2017
Development
Select AngularCliAspNetCore profile
Start debugging
Staging
In ClientApp folder run: npm run build
Select Staging profile
Start debugging
Start from scratch
