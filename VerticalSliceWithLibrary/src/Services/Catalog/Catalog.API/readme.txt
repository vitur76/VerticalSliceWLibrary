-===========Microservice common template =============-
ASP.NET Core 8+ Minimal API/ REST API ✔️
PostgreSQL ✔️
-------------------------
==Arhitectura==
Vertical Slice ✔️

==Design Pattern===
CQRS     - MediatR ✔️
Mediator - MediatR ✔️
REPR Design Pattern - MediatR ✔️

Endpoints(cu DTOs) + Handlers - Carter ✔️

Automapare - Mapster ✔️

==Cross-cutting Concerns==
Validare - Fluent Validation ✔️

Logging - Serilog ✔️

Global Handling Exceptions - MediatR ✔️

Pagination - EF Core(SQL) sau Marten(No SQL) ✔️

Seeding Catalog Database(develop) - EF Core(SQL) sau Marten(No SQL) ✔️

AuditableEntityInterceptor(audit) - ✔️

Health check -  AspNetCore.HealthChecks ✔️

==Configurare==
UserSecrets|appsettings+appsettings.dev(dev) | Env-Vault|appsettings+appsettings.prod(prod) ✔️

==Documentation and Testing=====
Swagger                   ✔️      
Postman(env + colectii)   ✔️
test.http                 ✔️
unitTest(fără a accesa resurse externe (bază de date, rețea etc)) ✔️
IntegrationTests          ✔️

==Security==
CORS                                ✔️
UserSecrets(dev)/Env-Vault(prod)    ✔️


==Docker Compose===
Dockerfile 
Docker Compose file 

==Minikube====

==CI/CD===

==Observability&Monitoring==