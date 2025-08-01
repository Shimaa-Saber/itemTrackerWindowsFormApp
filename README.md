# Item Tracker System

## 📌 Overview
A desktop application built using Windows Forms and layered architecture (DAL, BLL, UI) for managing inventory items and tracking user actions.

## ✨ Features
- User registration & login (Admin / User)
- Add / update / delete items
- Log actions with timestamp and user
- View logs (Admin only)

## 🏗️ Architecture
- C# .NET Framework 4.7.2
- ADO.NET for database operations
- SQL Server Database

## 🧩 Layers
- `UI`: Windows Forms interface
- `BLL`: Business logic and validation
- `DAL`: Data access using raw SQL
- `Models`: Data entity classes

## 🛠️ How to Run
1. Restore the provided database (`itemTracker.bak`)
2. Open the solution in Visual Studio
3. Update `App.config` connection string if needed
4. Build and Run

## 👤 Admin Credentials
- Username: `Admin`
- Password: `1234`
