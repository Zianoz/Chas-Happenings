# Chas-Happenings
An All-in-one Calander Application for all events and activities at Chas Academy.
At Chas Academy, we believe that learning extends beyond the classroom. Our event calendar brings together students, faculty, and the community through workshops, guest talks and lectures, social events and career opportunities. We hope you like it and stay updated with all upcoming across campus!

This app uses Clean Architecture:
•	Application
•	chas_happenings.Tests
•	Domain
•	Infrastructure
•	web
________________________________________
Application
The application layer containing use cases, services, and application logic:
•	DTOs
•	Interfaces
•	Mappers
•	Services
•	Utilitys Helpers
Chas_happenings.Tests
Comprehensive unit tests to ensure code quality and reliability:
•	Controllers – API endpoint tests and HTTP behaviour validation
•	Services – Business logic tests and use case verification
Domain
The core business entities and domain logic rules are here.
•	Enums
•	Models
Infrastructure
Handles external concerns and data persistence implementation.
•	Data
•	Migrations
•	Repositories
•	Services
Web
Presentation layer handling HTTP requests and responses:
•	Controllers 
o	Api
o	MVC
•	Models
•	Pages
•	Views
•	Program.cs
________________________________________
API Endpoints
Table of Contents
•	Comment
•	Event
•	Tag
•	User
•	OpenAI
________________________________________
User Management
Login User
•	Method: POST
•	Route: /api/User/LoginUser
•	Description: Authenticates user and returns JWT token in HTTP-only cookie
•	Request Body: LoginUserDTO
•	Response: JWT token and success message or authentication error
Authenticate User
•	Method: GET
•	Route: /api/User/Authenticate
•	Description: Validates JWT token and returns user claims (requires authentication)
•	Headers: Authorization: Bearer {token}
•	Response: User ID, email, and role
Logout User
•	Method: POST
•	Route: /api/User/Logout
•	Description: Clears authentication cookie and logs user out
•	Response: Success message
Create New User
•	Method: POST
•	Route: /api/User
•	Description: Registers a new user in the system
•	Request Body: CreateUserDTO
•	Response: Created user ID or error message
Update User
•	Method: PUT
•	Route: /api/User/UpdateUserById/{userId}
•	Description: Updates user information by user ID
•	URL Parameter: int userId
•	Request Body: UpdateUserDTO
•	Response: Success message or "User not found" error
Get User by ID
•	Method: GET
•	Route: /api/User/GetUserById/{userId}
•	Description: Retrieves specific user details by user ID
•	URL Parameter: int userId
•	Response: User details or "User not found" error
Delete User
•	Method: DELETE
•	Route: /api/User/Delete/{userId}
•	Description: Deletes a user by ID (Admin role required)
•	Authorization: Requires Admin role
•	URL Parameter: int userId
•	Response: Success message or "User not found" error
Get All Users
•	Method: GET
•	Route: /api/User/GetAll
•	Description: Retrieves list of all users (Admin role required)
•	Authorization: Requires Admin role
•	Response: List of all users

