# Chas-Happenings

An all-in-one event & activity calendar for students and faculty at Chas Academy.
Stay updated with workshops, guest lectures, community events, and campus activities—all in one place.

📘 Overview

Chas-Happenings is designed using Clean Architecture to ensure scalability, testability, and clean separation of concerns.

Architecture Layers:

Application – Core logic, services, use cases

Domain – Business rules and entities

Infrastructure – Data access, repositories, migrations

Web – Presentation layer (MVC + API controllers)

Tests – Unit test coverage for controllers and services

⚙️ Setup Instructions
Prerequisites

.NET 8 SDK

SQL Server or LocalDB

Visual Studio / VS Code

EF Core CLI (included with .NET SDK)

1️⃣ Clone the Repository
git clone https://github.com/Zianoz/Chas-Happenings.git
cd Chas-Happenings

2️⃣ Configure the Database

Update your connection string in
Infrastructure/appsettings.json or Web/appsettings.json:

"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=ChasHappeningsDB;Trusted_Connection=True;TrustServerCertificate=True;"
}

3️⃣ Apply EF Core Migrations
cd Infrastructure
dotnet ef database update

4️⃣ Run the Application

From the root or Web project:

dotnet run


App will launch at:

https://localhost:7291
http://localhost:5173

🗂️ Folder Structure
Chas-Happenings/
│
├── Application/
│   ├── DTOs/
│   ├── Interfaces/
│   ├── Mappers/
│   ├── Services/
│   └── Utilities/
│
├── chas_happenings.Tests/
│   ├── Controllers/
│   └── Services/
│
├── Domain/
│   ├── Models/
│   └── Enums/
│
├── Infrastructure/
│   ├── Data/
│   ├── Migrations/
│   ├── Repositories/
│   └── Services/
│
└── Web/
    ├── Controllers/
    │   ├── Api/
    │   └── MVC/
    ├── Models/
    ├── Pages/
    ├── Views/
    └── Program.cs

📡 The example API Endpoints 

👤 User Management
Login User

Method: POST

Route: /api/User/LoginUser

Description: Authenticates a user and returns a JWT token stored in an HTTP-only cookie

Request Body: LoginUserDTO

Response: JWT token + success message or authentication error

Authenticate User

Method: GET

Route: /api/User/Authenticate

Description: Validates JWT token and returns user claims

Headers: Authorization: Bearer {token}

Response: User ID, email, role

Logout User

Method: POST

Route: /api/User/Logout

Description: Clears authentication cookie and logs the user out

Response: Success message

Create New User

Method: POST

Route: /api/User

Description: Registers a new user

Request Body: CreateUserDTO

Response: Created user ID or error message

Update User

Method: PUT

Route: /api/User/UpdateUserById/{userId}

Description: Updates a user’s details

URL Parameter: int userId

Request Body: UpdateUserDTO

Response: Success message or "User not found"

Get User by ID

Method: GET

Route: /api/User/GetUserById/{userId}

Description: Retrieves a single user by ID

URL Parameter: int userId

Response: User details or "User not found"

Delete User

Method: DELETE

Route: /api/User/Delete/{userId}

Description: Deletes a user (Admin only)

Authorization: Admin role required

URL Parameter: int userId

Response: Success message or "User not found"

Get All Users

Method: GET

Route: /api/User/GetAll

Description: Retrieves all users (Admin only)

Authorization: Admin role required

Response: List of users
