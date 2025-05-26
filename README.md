# 🛍️ E-Commerce Microservices Shop

A cloud-native e-commerce application built with modern microservices architecture using **.NET 9**, designed with **DDD**, **CQRS**, and **Clean Architecture** principles.

## 🚀 Features

- ✅ ASP.NET Core 9 Web APIs & Minimal APIs
- 🧱 Modular Microservices: Catalog, Basket, Discount, Ordering, API Gateway, Web UI
- 📦 Event-driven communication with **RabbitMQ** and **MassTransit**
- 🔁 High-performance gRPC communication
- 🗃️ Multi-database support: PostgreSQL, SQL Server, SQLite, Redis
- 🛡️ YARP API Gateway with routing and rate limiting
- 📦 Dockerized setup with Docker Compose

## 🧩 Tech Stack

- **Backend**: ASP.NET Core 9, C# 12, MediatR, FluentValidation, Mapster
- **Databases**: PostgreSQL, SQL Server, SQLite, Redis
- **Communication**: RabbitMQ, MassTransit, gRPC
- **Gateway**: YARP Reverse Proxy
- **Frontend**: ASP.NET Core Razor Pages, Bootstrap 4
- **Other Tools**: Docker, Docker Compose

## 🧪 Modules

- **Catalog**: Minimal APIs, CQRS with MediatR, Marten (PostgreSQL)
- **Basket**: REST API, Redis cache, gRPC integration
- **Discount**: gRPC Service with SQLite
- **Ordering**: DDD, EF Core, CQRS, RabbitMQ consumer
- **API Gateway**: YARP reverse proxy setup
- **WebUI**: Razor Pages frontend with Refit HTTP clients

