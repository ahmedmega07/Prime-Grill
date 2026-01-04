# Prime-Grill Restaurant Management System – RESTful Web API

A RESTful Web API built with .NET 9 for managing restaurants and their menu items.  
The system enables restaurant owners to manage their establishments and dishes with full CRUD operations, secure authentication, and authorization.

The project follows Clean Architecture principles and applies modern software design patterns to ensure scalability, maintainability, and clear separation of concerns.

---

## Features

- Restaurant and dish management with parent-child relationships
- Full CRUD operations for restaurants and menu items
- Authentication and authorization using ASP.NET Core Identity with JWT Bearer tokens
- API documentation using Swagger / OpenAPI
- Database seeding for initial data population

---

## Architecture & Design Patterns

- Clean Architecture with four-layer separation:
  - API
  - Application
  - Domain
  - Infrastructure
- CQRS pattern using MediatR for command and query segregation
- Repository pattern for data access abstraction
- Dependency Injection across the application

---

## Technologies & Tools

- .NET 9
- ASP.NET Core Web API
- Entity Framework Core 9 (Code-First)
- SQL Server
- ASP.NET Core Identity
- JWT Authentication
- MediatR
- AutoMapper
- FluentValidation
- Serilog (structured logging)
- Swagger / Swashbuckle

---

## Responsibilities & Implementation Details

- Designed and implemented a scalable RESTful API following Clean Architecture principles
- Implemented CQRS pattern to clearly separate read and write operations
- Built custom middleware for global exception handling and request logging
- Configured Entity Framework Core with code-first migrations and database seeding
- Integrated FluentValidation for robust and consistent input validation

---

## Getting Started

### Prerequisites

- .NET SDK 9
- SQL Server

### Setup

1. Clone the repository:
   ```bash
   git clone <repository-url>
