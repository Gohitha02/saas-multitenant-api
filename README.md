# SaaS Multi-Tenant API (ASP.NET Core)

Production-ready **multi-tenant SaaS backend** built with **ASP.NET Core + EF Core**, designed to demonstrate clean tenant isolation, scalable architecture, and API best practices.

## Why this repo
Recruiter-friendly reference project showing:
- Multi-tenant request resolution (tenant context per request)
- Database-backed data access with EF Core
- Swagger/OpenAPI documentation
- Strong structure that scales to real SaaS products

---

## Tech Stack
- **.NET / ASP.NET Core Web API**
- **Entity Framework Core**
- **Swagger (OpenAPI 3.0)**
- SQL Server / PostgreSQL ready (config-based)

---

## Architecture (High Level)
Request → **Tenant Resolution Middleware** → `TenantContext` → EF Core `DbContext` → Controllers

**Tenant resolution** happens early in the pipeline so every request runs inside the correct tenant scope.

---

## Getting Started

### Prerequisites
- .NET SDK installed (Visual Studio includes it)
- A database (SQL Server / PostgreSQL)

### Run locally
1. Open the solution in Visual Studio
2. Set `SaaS.MultiTenant.Api` as Startup Project
3. Run ▶ (HTTPS)

Swagger UI will open automatically:
- `https://localhost:<port>/swagger`

---

## API Endpoints
- `GET /api/projects`
- `POST /api/projects`

Swagger is the source of truth for request/response formats.

---

## Multi-Tenant Usage
Tenant can be passed via request header (example):

- `X-Tenant-Id: tenant-a`

(Your middleware/tenant context controls how the tenant is detected.)

---

## Roadmap (Next Enhancements)
- JWT Authentication + RBAC
- Tenant onboarding endpoints
- Centralized exception handling + logging
- CI/CD (GitHub Actions)
- Docker compose for local DB + API

---

## Author
**Gohitha Reddy**  
LinkedIn: https://www.linkedin.com/in/gohitha-r/
