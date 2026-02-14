# ExpenseTracker.API
A RESTful ASP.NET Core Web API for managing user expenses.

## Features
- User registration and authentication
- Add, update, delete, and view expenses
- Entity Framework Core (Code First)
- SQL Server database
- Clean architecture with controllers and services

## Tech Stack
- C#
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- Swagger (OpenAPI)

## API Endpoints
### Authentication
| Method | Endpoint | Description |
|------|---------|-------------|
| POST | /api/auth/register | Register a new user |
| POST | /api/auth/login | User login |

### Expenses
| Method | Endpoint | Description |
|------|---------|-------------|
| GET | /api/expenses | Get all expenses |
| GET | /api/expenses/{id} | Get expense by id |
| POST | /api/expenses | Add a new expense |
| PUT | /api/expenses/{id} | Update an expense |
| DELETE | /api/expenses/{id} | Delete an expense |

## How to Run
1. Clone the repository
2. Update connection string in `appsettings.json`
3. Run migrations
4. Start the application
5. Test APIs using Swagger

## Author
Yashodhadevi Kovvuri
Aspiring .NET Backend Developer
