# Device Category Management System

An ASP.NET Core MVC web application for managing devices, device categories, and users — built as a coursework project for **CSE422**.

## Overview

The system implements full CRUD (Create, Read, Update, Delete) management for three core entities:

- **Devices** — individual devices tracked by name, code, category, status, and entry date
- **Device Categories** — groupings that devices belong to
- **Users** — people who use or manage the system

## Tech Stack

- [ASP.NET Core MVC](https://learn.microsoft.com/aspnet/core/mvc/overview) (.NET 8)
- [Entity Framework Core 8](https://learn.microsoft.com/ef/core/) — ORM and database access
- SQL Server (via `Microsoft.EntityFrameworkCore.SqlServer`)
- Razor Views for the UI
- Docker (containerized build/run support)

## Architecture

The project follows standard ASP.NET Core MVC structure:

| Layer | Responsibility |
|---|---|
| **Models** | `Device`, `DeviceCategory`, and `User` entities, with data annotations for validation |
| **Data** | `ApplicationDbContext` — manages the database connection and `DbSet` entity sets |
| **Controllers** | `DeviceController`, `DeviceCategoryController`, `UserController` — handle CRUD requests for each entity |
| **Views** | Razor views for listing, creating, editing, deleting, and viewing entity details |

### Entities

- **Device** — `Id`, `Name`, `Code`, `DeviceCategoryId`, `Status`, `DateOfEntry`
- **DeviceCategory** — `Id`, `Name`, `Description` (optional), plus a navigation collection of related `Device` objects
- **User** — `Id`, `FullName`, `Email`, `PhoneNumber`

All models use data annotation attributes (required fields, string length, format checks) to enforce validation, with errors surfaced directly in the views.

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- SQL Server / SQL Server Express
- (Optional) Docker, if you prefer running the app in a container

### Configure the database

Update the connection string in `appsettings.json` if needed:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost\\SQLEXPRESS;Database=DeviceDb;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

### Apply migrations and run

```bash
dotnet restore
dotnet ef database update
dotnet run
```

The app runs at `http://localhost:5000` by default and supports full device, category, and user management out of the box.

### Run with Docker

```bash
docker build -t device-category-management .
docker run -p 8080:80 device-category-management
```

## Features

- Full CRUD operations for devices, categories, and users
- Validation via data annotations, with inline error messages surfaced in views
- Clean, consistent Razor view templates for listing and editing records
- Controllers kept thin — request handling only, with data access delegated to `ApplicationDbContext`

## Project Status

This repository currently contains the project scaffold and configuration (`Program.cs`, `.csproj`, `Dockerfile`, `appsettings`). The `Models`, `Data`, `Controllers`, and `Views` described above are documented from the project report and may not yet be fully pushed to this repo — check the current file tree before running the app.

## Future Work

- Authentication and role-based authorization
- Improved UI using a CSS framework
- REST API endpoints for external access
- Reporting and statistics modules

## Course

Built as coursework for **CSE422**.
