# DevHabits API

A RESTful Web API for managing personal habits, tracking progress, and helping users build consistent routines.

## Features

* User authentication with JWT
* Habit management (Create, Read, Update, Delete)
* Progress tracking
* Pagination, filtering, and searching
* Input validation
* Global exception handling
* Structured logging
* OpenAPI documentation with Scalar
* Clean Architecture principles
* Entity Framework Core with SQL Server

## Technologies

* ASP.NET Core (.NET 10)
* C#
* Entity Framework Core
* SQL Server
* JWT Authentication
* Scalar API Reference
* AutoMapper
* Docker & Docker Compose
* Serilog
* xUnit (planned)

## Project Structure

```text
DevHabits.Api
├── Controllers
├── Services
├── Repositories
├── Models
├── DTOs
├── Data
├── Middleware
├── Mappings
├── Validators
└── Program.cs
```

## Getting Started

### Prerequisites

* .NET 10 SDK
* SQL Server
* Docker Desktop (optional)
* Visual Studio 2022 or Visual Studio Code

### Clone the repository

```bash
git clone https://github.com/<your-username>/DevHabits.api.git
cd DevHabits.api
```

### Configure the database

Update the connection string in:

```text
appsettings.Development.json
```

### Apply database migrations

```bash
dotnet ef database update
```

### Run the application

```bash
dotnet run
```

## API Documentation

After starting the application, open:

```text
https://localhost:2301/scalar
```

The OpenAPI document is available at:

```text
https://localhost:2301/openapi/v1.json
```

> Replace the port if your project uses a different one.

## Authentication

This API uses **JWT Bearer Authentication**.

To access protected endpoints:

1. Register or log in.
2. Copy the generated JWT.
3. Click **Authorize** in Scalar.
4. Enter:

```text
Bearer <your_token>
```

## Development Workflow

```bash
git pull
git checkout -b feature/your-feature
```

After making changes:

```bash
git add .
git commit -m "Describe your changes"
git push
```

## Roadmap

* [ ] User registration
* [ ] User login
* [ ] JWT authentication
* [ ] Habit CRUD
* [ ] Categories
* [ ] Progress tracking
* [ ] Pagination
* [ ] Filtering
* [ ] Validation
* [ ] Logging
* [ ] Docker support
* [ ] Unit tests
* [ ] Integration tests
* [ ] CI/CD pipeline

## License

This project is intended for learning and portfolio purposes.

## Author

**lava231**

Backend Developer focused on ASP.NET Core, REST APIs, Entity Framework Core, and Clean Architecture.
