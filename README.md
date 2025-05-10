# 📍 SpainCities Project

This application provides a complete and interactive visualization of the geographic distribution and hierarchical relationships between regions, provinces, and cities throughout Spain. It serves as an educational tool aimed at improving user familiarity with spatial organization and administrative divisions, primarily for learning, demonstration, and exploration purposes.

---

## 📅 Changelog

- **08/04/2025**:
  - **Architecture**: Added folder with an explanation of the solution's architecture. 
  - **Backend**: Code improvements and refactoring to follow clean code principles. 
  - **Frontend**: UI redesign to display regions, provinces, and cities on the same page. Enabled communication between parent and child components. Integrated `@angular/material` to display popups.
- **07/03/2025**:
  - **Backend/Frontend**: Cleaned up code and removed unnecessary comments. 
  - **Database**: Added ER diagram.
- **26/02/2025**:
  - **Backend**: Updated API to follow RESTful conventions and use proper plural routes.
  - **Frontend**: Fixed URL invocations.
- **13/01/2025**:
  - **Backend**: Improved backend code. Added services for basic unit testing using xUnit and Moq. Removed `bin` and `obj` directories. Deleted `.vs` directory.
- **12/01/2025**:
  - **Frontend**: Improved code structure. Segregated services for cities, provinces, regions, and images.
- **11/01/2025**:
  - **Full Stack**: Improved database, backend, and frontend code.
- **07/01/2025**:
  - **Backend**: Code enhancements.
- **03/01/2025**:
  - Initial release — added backend, frontend, and SQL database code.

---

## 🎯 Objective

Practice with .NET (C#), SQL Server, and Angular (TypeScript). Apply design patterns and Onion Architecture. Gain hands-on experience with Angular forms. Integrate speech-to-text functionality using the Web Speech API for real-time transcription in the browser.

### Technologies:

- **.NET (C#)** and **SQL Server**
- **Angular (TypeScript)**
- **Design Patterns**
- **Onion Architecture**

---

## 🚀 Features

### 🔧 Backend

Implements common design patterns including BaseEntity, Repository, UnitOfWork, and Factory (for task instance creation).

- Based on **Onion Architecture**
- Applies key **Design Patterns**:
  - `BaseEntity`
  - `UnitOfWork`
  - `Repository` (for data access)
  - `DTO` (Data Transfer Object)
  - `Singleton` (for configuration)
  - `Factory` (for instance creation)

- **Key Libraries**:
  - **Encryption**:
    - `System.Security.Cryptography` (AES-256)
  - **Logging**:
    - `Serilog`
    - `Serilog.Extensions.Logging`
    - `Serilog.Sinks.File`
  - **ORM**:
    - `Microsoft.EntityFrameworkCore.SqlServer`
    - `Microsoft.EntityFrameworkCore.Tools`
  - **UI**:
    - `@angular/material` 18.2.14
    - `@angular/cdk` 18.2.14

---

### 💻 Frontend

- Built with **Angular 18.0.2 / 18.2.14**
- Features:
  - Reactive Forms
  - `AuthService` and HTTP Interceptors
  - Modular architecture
  - Service and model generation
  - Custom Pipes and Shared Modules
  - Angular Material components and popups

---

### 🗄️ Database

- Uses **MariaDB**, deployed with **Docker Desktop**
- Includes:
  - ER diagram designed for SQL Server
  - Sample data scripts (`.sql`)
  - **DDL scripts** for schema creation
  - **DML scripts** for inserting sample data

---

## 🧪 Installation

### ✅ Prerequisites

Ensure the following tools are installed:

- [.NET SDK 9.0.200](https://dotnet.microsoft.com/)
- [SQL Express](https://www.microsoft.com/es-es/sql-server/sql-server-downloads)
- [Node.js + npm](https://nodejs.org/) (for the frontend)
- [Postman 11.44.3](https://www.postman.com/downloads/)

---

### 🔧 Setup Steps

1. Clone the repository:
    ```bash
    git clone https://github.com/waltermillan/To-Do-List.git
    ```

2. Follow the setup video guide:
    - [Version 1 - Display Version](https://youtu.be/478V9e3bG60)

3. Complete the remaining setup steps as outlined in the project documentation.

---

## 📄 License

This project is licensed under the [MIT License](LICENSE).
