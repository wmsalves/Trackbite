# Trackbite

This repository contains a habit and nutrition tracking application built with **Angular** and **.NET 7**. The goal is to provide users with a simple dashboard where they can track personal habits and manage daily nutritional intake.

## Objective

The purpose of this project is to solidify my full-stack development skills by building a real-world application from scratch, applying best practices with Angular for the frontend and ASP.NET Core for the backend.

## Current Focus: Habit Management

At the current stage, the application focuses on:

- ✅ **Habit Tracking** – Create, read, update, and delete habits.
- 🔄 **Integration** – Connect Angular frontend with .NET API.
- ⚙️ **REST API** – Secure and scalable backend using Entity Framework and PostgreSQL.
- 🔧 **Development Workflow** – Following industry standards (layered architecture, services, modular frontend, meaningful commits).

## Technologies Used

### Frontend
- [Angular 17](https://angular.io/)
- TypeScript
- RxJS
- Angular Standalone Components
- Angular HTTPClient
- SCSS

### Backend
- ASP.NET Core Web API (.NET 7)
- Entity Framework Core
- PostgreSQL
- CORS configuration
- RESTful design

### Tools
- Visual Studio
- VS Code
- Postman
- Git & GitHub
- IIS Express (development)

## Project Structure

```bash
Trackbite/
├── front-end/                  # Angular application
│   ├── src/
│   │   ├── app/
│   │   │   ├── services/       # Habit service
│   │   │   ├── models/         # Habit model
│   │   │   └── dashboard/      # Dashboard component
│   └── ...
├── Trackbite.API/             # ASP.NET Core Web API
│   ├── Controllers/           # HabitsController
│   ├── Models/                # Habit model
│   ├── Data/                  # ApplicationDbContext
│   └── ...
└── README.md
```

## How to Run

### 1. Clone the repository

```bash
https://github.com/wmsalves/Trackbite.git
cd trackbite
```

### 2. Run the backend (.NET)

```bash
cd Trackbite.API
dotnet ef database update
dotnet run
```

> Make sure your database is configured in `appsettings.json`.

### 3. Run the frontend (Angular)

```bash
cd front-end
npm install
ng serve
```

Then go to: [http://localhost:4200](http://localhost:4200)

---

## Future Additions

- 📊 Nutrition tracking panel with food APIs
- 🧠 AI/ML suggestions based on habit patterns
- 🔐 Authentication (JWT + role-based)
- 🗕️ Calendar & daily view
- 📊 Analytics dashboard
