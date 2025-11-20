E-Commerce Web API

A production-ready E-Commerce Backend API built with .NET, following Clean Architecture, CQRS, and industry best practices.
It provides complete management for products, customers, orders, authentication, and background processing.

🚀 Features
Core Functionality

🔐 Authentication & Authorization — JWT-based, with Admin & Customer roles

🛒 Product Management — CRUD for products & categories with full validation

📦 Order Management — Place, cancel, and complete orders with stock updates

✔️ Fluent Validation — Strong validation for input and domain rules

Bonus & Advanced Features

📨 Background Jobs (Hangfire) — Email notifications for order actions

🔁 Idempotent Order Creation — Prevents duplicate orders on retries

🧱 CQRS with MediatR — Separate Read/Write responsibilities

⚡ Caching — In-memory caching for high-traffic read endpoints

🗑️ Soft Delete — Historical audit instead of hard delete

📊 Pagination & Sorting — Built-in for large datasets

📜 Serilog Logging — Structured logs for debugging & production

🛠️ Tech Stack

.NET Core Web API

Entity Framework Core (SQL Server)

MediatR

Hangfire

Serilog

AutoMapper

Swagger

⚙️ Setup Instructions

1. Clone the Repository
   git clone https://github.com/Ibrahem-Hebish/E-Commerce.git

2. Configure Database

Update the connection string in appsettings.json:

"ConnectionStrings": {
"DefaultConnection": "Server=.;Database=ECommerceDb;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True"
}

3. Configure Email & JWT

Add your SMTP settings + JWT SigningKey

⚠️ Recommended: keep secrets in User Secrets or Environment Variables

4. Apply Migrations
   dotnet ef database update

5. Seed Data

On first run, the system seeds:

Admin user

Admin & Customer roles

▶️ Run the Application
dotnet run

Swagger UI

Navigate to:

https://localhost:7218/swagger

Hangfire Dashboard
https://localhost:7218/hangfire

🎥 Demo Videos
1️⃣ Project Architecture

▶️ https://drive.google.com/file/d/1VeMIgPaky7buBI8ZPNIa_NxRmc9Tg8UQ/view?usp=sharing

2️⃣ Customer Features

▶️ https://drive.google.com/file/d/1c1F7TWkyOLYnovoC6ORX-WNF-5kgF6tb/view?usp=sharing

3️⃣ Admin Features

▶️ https://drive.google.com/file/d/1MqoKQTbde4BVIoq3XxvQxZkSGLjSn08y/view?usp=sharing

🧪 Sample API Request
Register Customer

POST /api/auth/register

Request
{
"name": "Ibrahem",
"email": "ibrahem@gmail.com",
"password": "Hema123#",
"confirmPassword": "Hema123#",
"phoneNumber": "01228485965"
}

Sample Response
{
"data": "User registered successfully.",
"message": "Success",
"statusCode": 200,
"isSuccess": true
}
