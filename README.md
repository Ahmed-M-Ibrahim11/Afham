# 🎓 Teacher Groups Platform

<div align="center">

## 🚀 Modern Learning Management Platform

**Built with ASP.NET Core 8, Clean Architecture, CQRS & MediatR**

*A scalable and maintainable platform that enables teachers to manage educational groups while providing students with a modern online learning experience.*

</div>

---

# 📖 Project Overview

The **Teacher Groups Platform** is a modern **Learning Management System (LMS)** designed to simplify the communication between **Teachers** and **Students**.

The platform allows teachers to create and manage educational groups, schedule online meetings, share recordings, publish announcements, and communicate with students through an integrated group chat.

Students can browse teachers, request to join groups, attend online meetings, watch recordings, and receive important notifications in one centralized platform.

The project follows **Clean Architecture** principles to ensure scalability, maintainability, and separation of concerns.

---

# 🎯 Project Goals

✅ Simplify teacher group management

✅ Provide a modern online learning experience

✅ Support online meetings and recordings

✅ Manage student enrollments

✅ Secure authentication & authorization

✅ Scalable and maintainable architecture

---

# 👥 User Roles

The system supports three different roles.

## 👨‍🏫 Teacher

Teachers can:

* Create unlimited groups
* Manage students
* Accept or reject join requests
* Schedule online meetings
* Share meeting recordings
* Publish announcements
* Control group chat
* Update group information

---

## 👨‍🎓 Student

Students can:

* Browse teachers
* Browse available groups
* Request to join groups
* Cancel pending requests
* Attend online meetings
* Watch recordings
* Read announcements
* Receive notifications

---

## 👑 Administrator

Administrators are responsible for:

* Managing Teacher Ratings
* Managing Platform Users
* Monitoring the system
* Future administration features

---

# 🏛️ System Architecture

The project follows **Clean Architecture** to separate business logic from infrastructure and presentation layers.

```text
Presentation Layer
        │
        ▼
Application Layer
        │
        ▼
Domain Layer
        ▲
        │
Infrastructure Layer
```

Each layer has a single responsibility, making the application easier to maintain, test, and extend.

---

# 📂 Architecture Layers

## 🌐 Presentation Layer

Responsible for:

* API Controllers
* HTTP Requests
* Authentication
* Authorization
* Swagger Documentation

---

## 🧠 Application Layer

Contains:

* CQRS
* MediatR
* Commands
* Queries
* DTOs
* Validators
* Behaviors
* Interfaces
* Mapping Profiles

This layer contains the application's use cases.

---

## ❤️ Domain Layer

Contains:

* Entities
* Enums
* Domain Interfaces
* Business Rules
* Domain Models

The Domain layer contains **pure business logic** without depending on any external libraries.

---

## ⚙️ Infrastructure Layer

Responsible for:

* Entity Framework Core
* SQL Server
* ASP.NET Identity
* JWT Authentication
* Repository Implementations
* External Services

---

# 🛠️ Technology Stack

| Category             | Technology              |
| -------------------- | ----------------------- |
| Framework            | ASP.NET Core 8          |
| Language             | C# 12                   |
| Architecture         | Clean Architecture      |
| Design Pattern       | CQRS                    |
| Mediator             | MediatR                 |
| ORM                  | Entity Framework Core 8 |
| Database             | SQL Server              |
| Authentication       | ASP.NET Identity        |
| Authorization        | JWT Bearer Token        |
| Validation           | FluentValidation        |
| Object Mapping       | AutoMapper              |
| API Documentation    | Swagger / OpenAPI       |
| Dependency Injection | Built-in .NET DI        |
| Logging              | Serilog *(Optional)*    |
| Version Control      | Git & GitHub            |

---

# 🧩 Design Patterns Used

The project uses several modern software design patterns.

### ✅ Clean Architecture

Provides clear separation between business logic and infrastructure.

---

### ✅ CQRS

Separates:

* Commands (Write Operations)
* Queries (Read Operations)

Improves scalability and maintainability.

---

### ✅ MediatR

Used to:

* Handle Commands
* Handle Queries
* Decouple Controllers from Business Logic

---

### ✅ Repository Pattern

Abstracts database operations from business logic.

---

### ✅ Dependency Injection

Provides loose coupling between services.

---

### ✅ SOLID Principles

The entire project follows SOLID principles for better software design.

---

# 🔐 Authentication & Authorization

Authentication is implemented using:

* ASP.NET Identity
* JWT Bearer Tokens

Authorization is based on Roles.

Available Roles:

* 👑 Admin
* 👨‍🏫 Teacher
* 👨‍🎓 Student

Every secured endpoint requires authentication except:

* Login
* Register
* Landing Page

---

# 📚 Core Modules

The application contains the following modules.

### 👤 Authentication

* Register
* Login
* JWT Authentication

---

### 👨‍🏫 Teacher Management

* Teacher Profile
* Teacher Dashboard

---

### 👨‍🎓 Student Management

* Student Profile
* Student Dashboard

---

### 👥 Groups

* Create Group
* Update Group
* Archive Group
* Capacity Management

---

### 🤝 Join Requests

* Create Request
* Cancel Request
* Accept Request
* Reject Request

---

### 👥 Group Members

* Manage Members
* Remove Students

---

### 🎥 Meetings

* Schedule Meeting
* Meeting Link
* Meeting Status

---

### 🎬 Recordings

* Upload Recording
* Watch Recording

---

### 💬 Chat

* Group Chat
* Chat Modes

---

### 📢 Announcements

* Create Announcement
* Publish Announcement

---

### 🔔 Notifications

* Join Request Notifications
* Meeting Notifications
* Announcement Notifications

---

# 📊 Database Design

The database is fully normalized and designed according to the business rules.

Main entities include:

* Users
* Teacher Profiles
* Student Profiles
* Subjects
* Grades
* Teacher Groups
* Join Requests
* Group Members
* Meetings
* Recordings
* Chat Messages
* Announcements
* Notifications

The database follows:

* One-to-One Relationships
* One-to-Many Relationships
* Soft Delete
* Referential Integrity

---

# 🔒 Security

The platform includes:

* JWT Authentication
* Role-Based Authorization
* Secure Password Hashing
* Identity Management
* Request Validation
* Soft Delete Support

---

# 📈 Scalability

The project is designed to support future features without major architectural changes.

Planned future enhancements include:

* 💳 Online Payments
* 📚 Homework System
* 📝 Exams
* ❓ Quiz Module
* ⭐ Reviews
* 👨‍👩‍👧 Parent Accounts
* 📊 Analytics Dashboard
* 📱 Mobile Application

---

# 🚀 Why This Architecture?

This architecture was selected because it provides:

✅ High Maintainability

✅ Easy Unit Testing

✅ Scalability

✅ Separation of Concerns

✅ Independent Business Logic

✅ Better Team Collaboration

✅ Easy Feature Expansion

---

# 📌 Project Summary

Teacher Groups Platform is a scalable Learning Management System built with **ASP.NET Core 8** using **Clean Architecture**, **CQRS**, **MediatR**, and **Entity Framework Core**.

The system enables teachers to manage educational groups while allowing students to enroll in courses, attend meetings, access recordings, receive announcements, and communicate through an integrated chat system.

The project emphasizes maintainability, extensibility, security, and modern software engineering practices, making it suitable for enterprise-level development and future expansion.
