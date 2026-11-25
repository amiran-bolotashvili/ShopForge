# Modular Ecommerce

A modular monolith ecommerce backend built with C# and ASP.NET Core.
**Status: in early development.**

## About
This project is my way of practicing backend architecture in .NET.
Each module has its own infrastructure and its own DbContext,
so modules stay independent and could be split into services later.

## Modules
- **Catalog** (in progress): products, categories and specifications.
  Specifications belong to categories and are used to filter products.
- **Orders** (planned)

## Tech stack
- C#, .NET, ASP.NET Core Web API
- Entity Framework Core
- MediatR (CQRS)
- [SQL Server / MySQL, whichever you use]

## Architecture
- Modular monolith
- CQRS: separate commands and queries
- Domain model with Product, Category and Specification aggregates

## How to run
1. Clone the repository
2. Set the connection string in `appsettings.Development.json`
3. Apply migrations: `dotnet ef database update`
4. Run: `dotnet run --project <path to API project>`

## Roadmap
- [x] Catalog domain model
- [ ] Catalog commands and queries
- [ ] Catalog API endpoints
- [ ] Orders module

## Author
Amiran Bolotashvili
