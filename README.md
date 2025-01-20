# EduConnect Minimal API

EduConnect is a minimal API developed using .NET Core 9, designed to manage educational resources efficiently. 

## Features
- Resource Management:
   - Create, retrieve, update, and delete educational resources.
- Entity Framework Core Integration:
   - Efficient data access and management.
- Swagger UI:
   - Interactive documentation for testing and exploring API endpoints.
 
## Technologies Used
- .NET Core 9 Minimal API
- Entity Framework Core
- Sql server
- AutoMapper
- Swagger/OpenAPI

---

## Project Structure

```
EduConnect
|
├── Context
│   └── ApplicationDbContext.cs         # Database context
|
├── DTOS
│   ├── ResourceDto.cs                  # Data Transfer Object for Resource
|
├── EndpointHandlers
│   ├── ResourceHandlers.cs             # Handlers for Resource-related endpoints
|
├── EntitiesConfiguration
│   └── ResourceConfiguration.cs        # Entity configurations
|
├── Extensions
│   └── EndpointRouteBuilderExtensions.cs # Extension methods for routing
|
├── Models
│   ├── Resource.cs                     # Resource entity
|
├── Profiles
│   └── EduConnectProfile.cs            # AutoMapper profile
|
├── Migrations                          # EF Core migrations folder
|
├── appsettings.json                    # Application configuration
├── Program.cs                          # Application entry point
```
---

## API Endpoints

### Resource Endpoints

| HTTP Method | Endpoint        | Description                 |
|-------------|-----------------|-----------------------------|
| GET         | `/resource`     | Retrieves all resources     |
| POST        | `/resource`     | Creates a new resource      |
| PUT         | `/resource`     | Updates an existing resource|
| DELETE      | `/resource`     | Deletes a resource          |
| GET         | `/resource/{id}`| Retrieves resource by ID    |

---

# Prerequisites
- .NET Core 9 SDK
- SQL server (docker container)
- SQLite installed (optional, database is created automatically if not present)

---

## Getting Started

1. Clone the repository:
   ```bash
   git clone https://github.com/clebertonf/EduConnect-minimal-api-dotnetcore-9.git
   cd EduConnect
   ```

2. Restore dependencies:
   ```bash
   dotnet restore
   ```

3. Apply migrations:
   ```bash
   dotnet ef database update
   ```

4. Run the application:
   ```bash
   dotnet run
   ```

5. Open the Swagger UI:
   Navigate to `https://localhost:5001/swagger` in your browser to explore and test the API.

---

### Using SQLite Instead of SQL Server

If you don't have SQL Server installed and want to use SQLite as your database, follow these steps:

---

#### 1. **Install SQLite Provider**  
Run the following command in your project directory to add the SQLite provider:
```bash
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
```

---

#### 2. **Modify `ApplicationDbContext`**  
Open the `ApplicationDbContext` file and update the `DbContextOptions` to use SQLite. Replace your existing configuration with the following:
```csharp
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    optionsBuilder.UseSqlite("Data Source=EduConnect.db");
}
```

---

#### 3. **Adjust `appsettings.json`**  
Update the connection string in your `appsettings.json` file:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=EduConnect.db"
  }
}
```

---

#### 4. **Apply Migrations**  
Regenerate your migrations to ensure they are compatible with SQLite. Use the following commands:
```bash
dotnet ef migrations remove
dotnet ef migrations add InitialCreate
dotnet ef database update
```

---

#### 5. **Run the Project**  
You can now run the project using SQLite. The database file (`EduConnect.db`) will be created in your project directory.

---

This setup allows you to use SQLite as an alternative to SQL Server with minimal changes.




