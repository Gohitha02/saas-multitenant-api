![.NET](https://img.shields.io/badge/.NET-8.0-purple)
![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-Web%20API-blue)
![EF Core](https://img.shields.io/badge/Entity%20Framework-Core-green)
![Multi-Tenant](https://img.shields.io/badge/Architecture-Multi--Tenant-orange)
![Swagger](https://img.shields.io/badge/API-Swagger-brightgreen)

![CI](https://github.com/Gohitha02/saas-multitenant-api/actions/workflows/ci.yml/badge.svg)
![Build](https://img.shields.io/github/actions/workflow/status/Gohitha02/saas-multitenant-api/ci.yml?branch=main)
![Last Commit](https://img.shields.io/github/last-commit/Gohitha02/saas-multitenant-api)
![License](https://img.shields.io/github/license/Gohitha02/saas-multitenant-api)

![Stars](https://img.shields.io/github/stars/Gohitha02/saas-multitenant-api?style=social)
![Forks](https://img.shields.io/github/forks/Gohitha02/saas-multitenant-api?style=social)


# SaaS Multi-Tenant API (.NET 8)

A production-ready **multi-tenant SaaS backend API** built with **ASP.NET Core**, **Entity Framework Core**, and **middleware-based tenant resolution**.  
Designed using clean separation of concerns and industry best practices to demonstrate real-world SaaS architecture.

---

## 🚀 Features

- 🏢 **Multi-Tenant Architecture**
  - Tenant resolution via custom middleware
  - Tenant context scoped per request
  - Header-based tenant isolation (`X-Tenant-ID`)

- ⚙️ **ASP.NET Core Web API**
  - RESTful endpoints
  - Swagger / OpenAPI documentation

- 🗄️ **Entity Framework Core**
  - Code-first approach
  - Database migrations
  - SQL Server / PostgreSQL ready

- 🔒 **Production-Ready Setup**
  - Environment-based configuration
  - Proper `.gitignore`
  - CI pipeline with GitHub Actions

- 🧪 **Extensible Design**
  - Ready for JWT authentication
  - Ready for role-based authorization
  - Ready for caching, logging, and cloud deployment

---

## 🧱 Architecture Overview

```text
Request
   ↓
TenantResolutionMiddleware
   ↓
TenantContext (Scoped)
   ↓
Controllers
   ↓
EF Core DbContext
   ↓
Database (Tenant-isolated)

Project Structure:
SaaS.MultiTenant.Api
│
├── Controllers/        # API endpoints
├── Data/               # DbContext & EF configuration
├── Migrations/         # EF Core migrations
├── Models/             # Domain models
├── Tenancy/            # Tenant context & middleware
├── Properties/         # Launch settings
│
├── Program.cs          # Application startup
├── appsettings.json    # Configuration
└── README.md

🛠️ Getting Started
Prerequisites

.NET 8 SDK
Visual Studio 2022+
SQL Server or PostgreSQL


▶️ Run the Application
dotnet restore
dotnet run

Swagger UI will be available at:
https://localhost:{port}/swagger

🧪 Testing Multi-Tenancy

All tenant resolution is handled using an HTTP header.

Required Header
X-Tenant-ID: tenant1
Example (Swagger)
Open Swagger UI
Choose POST /api/projects

Add Header:
X-Tenant-ID: tenant1

Execute the request
Each tenant gets isolated data.

🔄 Database Migrations
dotnet ef migrations add InitialCreate
dotnet ef database update

⚙️ CI/CD

GitHub Actions configured

Automatic build on every push to main

CI status visible on repository

📈 Planned Enhancements
🔐 JWT Authentication & Authorization
👤 Role-based access control
📊 Serilog structured logging
⚠️ Global exception handling
🐳 Docker & docker-compose
🚀 Cloud deployment (Azure/AWS)
⚡ Redis caching
🧪 Unit & integration tests

👩‍💻 Author

Gohitha Reddy
Senior .NET Developer
LinkedIn: https://www.linkedin.com/in/gohitha-r
GitHub: https://github.com/Gohitha02

📄 License

This project is licensed under the MIT License.


