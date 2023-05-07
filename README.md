## A Simple Calculator application with ASP.NET Core

[![CI](https://github.com/VIbanichuka/SimpleCalculator/actions/workflows/ci.yaml/badge.svg)](https://github.com/VIbanichuka/SimpleCalculator/actions/workflows/ci.yaml)

This SimpleCalculator application features:
- [**SimpleCalculator.Web**](src/SimpleCalculator.Web/) - An ASP.NET Core web application
- [**SimpleCalculator.Console**](src/SimpleCalculator.Console/) - A .NET console application

## Design Pattern 
- Dependency Injection Design Pattern
- The MVC (Model-View-Controller) architectural Design Pattern

For information about [MVC pattern](https://learn.microsoft.com/en-us/aspnet/core/mvc/overview?view=aspnetcore-7.0) and [DI pattern](https://dotnettutorials.net/lesson/dependency-injection-design-pattern-csharp/)

The application is separated into 3 layers: 
- The business logic layer [**Calculations**](src/Calculations/)
- The data access layer [**SimpleCalculator.DataAccess**](src/SimpleCalculator.DataAccess/)
- The presentation layer [**SimpleCalculator.Web**](src/SimpleCalculator.Web/) and [**SimpleCalculator.Console**](src/SimpleCalculator.Console/)

The [SimpleCalculator.Web](src/SimpleCalculator.Web/) and [SimpleCalculator.Console](src/SimpleCalculator.Console/) use the same business logic [Calculations](src/Calculations/)

The web application showcases:
- ASP.NET core MVC
- ASP.NET core WEB API
- Using EntityFramework core and Microsoft SQL Server
- [AutoMapper](https://docs.automapper.org/en/latest/Getting-started.html) for mapping one object to another.
- LINQ
- Client-side requests paging using JavaScript Ajax Call
- Unit tests for the Services using xUnit and Moq

## Prerequisites

### .NET
1. [Install .NET 6](https://dotnet.microsoft.com/en-us/download)

### Database
1. Install the **dotnet-ef** tool
2. Install the Microsoft SQL Server Management Studio

### Running the console application using Visual Studio Code

- **Visual Studio Code** - Open the [SimpleCalculator.Console](src/SimpleCalculator.Console/) terminal windows and then run the command:

    ```
    dotnet watch run 
    ```

    This will run the console application and display the console UI for user interaction:

<img width="500" alt="Screenshot 2023-03-05 145251" src="https://user-images.githubusercontent.com/94909597/222975290-881c2218-d9d9-44ca-ab2f-ef00af50684b.png">

### Running the web application using Visual Studio Code

- **Visual Studio Code** - Open the [SimpleCalculator.Web](src/SimpleCalculator.Web/) terminal windows and then run the command:

    ```
    dotnet watch run 
    ```

    This will run the web application. Navigate the web application - **Home** - **Privacy** - **Results**

<img width="900" alt="Screenshot 2023-03-05 151255" src="https://user-images.githubusercontent.com/94909597/222975517-dce24248-9011-4188-87f2-ef22ba978cda.png">

- The webpage **Home** displays the calculator's UI for calculation operations and some filtered data from Microsoft SQL server as shown above:
    - ASP.NET Core MVC
    - LINQ retrieves data from the data source as well as order and filter the data

<img width="900" alt="Screenshot 2023-03-05 154443" src="https://user-images.githubusercontent.com/94909597/222976444-13fc53ce-b140-4982-b91c-01ec504dc27e.png">

- The webpage **Results** displays filtered calculation results from Microsoft SQL server and a pagination panel as shown above:
    - ASP.NET Core Web API and JavaScript Ajax Call retrieves data and display paging
    - LINQ retrieves data from the data source and filters the data that displays on the webpage

## Optional

### Using the API standalone
The SimpleCalculator Web API controller can run standalone as well. You can run it and make requests to various endpoints using any client of your choice:

<img width="900" alt="Screenshot 2023-03-05 175617" src="https://user-images.githubusercontent.com/94909597/222977495-e083c28f-7b1c-4d3a-b9d4-0acc01f90020.png">
