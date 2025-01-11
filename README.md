# Car Manufacturers and Models API

This project is a .NET 8 C# application that provides APIs to perform CRUD (Create, Read, Update, Delete) operations on car manufacturers and car models data tables. The project uses Entity Framework (EF) Core with a code-first approach.

## Getting Started

These instructions will help you set up and run the project on your local machine for development and testing purposes.

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) installed on your machine.
- A SQL Server database to connect to.

### Configuration

1. Update the `appsettings.json` file with your database connection string:

    ```json
    {
      "ConnectionStrings": {
        "DefaultConnection": "YourConnectionStringHere"
      }
    }
    ```

### Database Migration

To set up the database, you'll need to apply the EF Core migrations. Use the following commands:

1. Add a new migration (if necessary):

    ```bash
    dotnet ef migrations add InitialCreate
    ```

2. Update the database with the latest migration:

    ```bash
    dotnet ef database update
    ```

### Building the Project

To build the project, navigate to the project directory and run the following command:

```bash
dotnet build

# Running the Project
To run the project, use the following command:

```bash
dotnet run
