# Documentation for Gudang Super Market Project

## Overview

This project is a Gudang Super Market application developed using .NET Core and PostgreSQL.

## File Structure

- **Gudang_Super_Market/**
  - **Controllers/**
    - `AuthController.cs`: Handles user registration and login.
    - `GudangController.cs`: Manages CRUD operations for Gudang entities.
    - `BarangController.cs`: Manages CRUD operations for Barang entities.
    - `ProductController.cs`: Manages CRUD operations for Product entities.
  - **Middleware/**
    - `ErrorHandlerMiddleware.cs`: Custom middleware for handling errors.
  - **Models/**
    - `User.cs`: Represents a user entity.
    - `Gudang.cs`: Represents a Gudang entity.
    - `Barang.cs`: Represents a Barang entity.
    - `Product.cs`: Represents a Product entity.
  - `AppDbContext.cs`: Entity Framework DbContext class.
  - `DesignTimeDbContextFactory.cs`: Design-time factory for DbContext.
  - `Startup.cs`: Configuration for the application startup.
  - `Program.cs` : Running application
  - `appsettings.json`: Configuration file for database connection, JWT, etc.

## Database Configuration

- Connection Strings:
  - DefaultConnection: PostgreSQL database connection string.

## Swagger Configuration

- Swagger is configured for API documentation.
- Swagger UI is available in development environment.

## JWT Configuration

- JWT is used for secure authentication.
- Configuration settings are present in the `Jwt` section of `appsettings.json`.

## Logging and Caching

- Logging and caching configurations are set up in `ConfigureServices` method in `Startup.cs`.

## How to Run

1. Clone the repository.
2. Configure the database connection in `appsettings.json`.
3. Run the database migration: `dotnet ef database update`.
4. Run the application: `dotnet run`.

```

Anda dapat menyesuaikan dokumenasi ini sesuai dengan kebutuhan dan detail implementasi dari proyek Anda. Jangan ragu untuk menambahkan sebanyak mungkin informasi yang diperlukan agar pengembang dan pengguna lain dapat dengan mudah memahami proyek ini.