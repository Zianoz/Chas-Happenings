# Chas-Happenings

## Description

**Chas-Happenings** is an all-in-one event platform for Chas Academy, offering a unified calendar for students and faculty along with a simple admin dashboard. The app also uses AI to generate weekly news updates, built on Clean Architecture for long-term reliability.

## Funktioner

MVP:

- all-in-one
- AI-generated weekly news
- Userful admin dashboard with event/user/comment/tag management, ability to log in, publish events, add and remove users etc.
- Upcoming feature proposals include event filter, upload a profile picture so users can personalize their account and weekly and upcoming events automated sending by email.

## Team

- Max        - [samihoy]([https://github.com/samihoy]
- Zian       - [Zianoz](https://github.com/Zianoz)
- Jing Zhang - [lucine1029](https://github.com/lucine1029)

## Architecture Layer

- Application – Core logic, services, use cases
- Domain – Business rules and entities
- Infrastructure – Data access, repositories, migrations
- Web – Presentation layer (MVC + API controllers)
- Tests – Unit test coverage for controllers and services

## Setup Instructions

### Prerequisites

- .NET 8 SDK
- MSSQL LocalDB
- Visual Studio / VS Code

### Clone the Repository

git clone https://github.com/Zianoz/Chas-Happenings.git

cd Chas-Happenings

### Configure the Database

- Update your connection string in Web/appsettings.json:

"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=ChasHappeningsDb;Trusted_Connection=True;TrustServerCertificate=True;"
}

### Apply EF Core Migrations

Go to: Tools → NuGet Package Manager → Package Manager Console

- add migration init
- update database

### Run the Application

From the Web project: run Program.cs

### App will launch at:

https://localhost:7291
http://localhost:5173

# API Endpoints (User Management)

## Login User

- Method: POST

- Route: /api/User/LoginUser

- Description: Authenticates a user and returns a JWT token stored in an HTTP-only cookie

- Request Body: LoginUserDTO

- Response: JWT token + success message or authentication error

## Authenticate User

- Method: GET

- Route: /api/User/Authenticate

- Description: Validates JWT token and returns user claims

- Headers: Authorization: Bearer {token}

- Response: User ID, email, role

## Logout User

- Method: POST

- Route: /api/User/Logout

- Description: Clears authentication cookie and logs the user out

- Response: Success message

## Create New User

- Method: POST

- Route: /api/User

- Description: Registers a new user

- Request Body: CreateUserDTO

- Response: Created user ID or error message

## Update User

- Method: PUT

- Route: /api/User/UpdateUserById/{userId}

- Description: Updates a user’s details

- URL Parameter: int userId

- Request Body: UpdateUserDTO

- Response: Success message or "User not found"

## Get User by ID

- Method: GET

- Route: /api/User/GetUserById/{userId}

- Description: Retrieves a single user by ID

- URL Parameter: int userId

- Response: User details or "User not found"

## Delete User

- Method: DELETE

- Route: /api/User/Delete/{userId}

- Description: Deletes a user (Admin only)

- Authorization: Admin role required

- URL Parameter: int userId

- Response: Success message or "User not found"

## Get All Users

- Method: GET

- Route: /api/User/GetAll

- Description: Retrieves all users (Admin only)

- Authorization: Admin role required

- Response: List of users
