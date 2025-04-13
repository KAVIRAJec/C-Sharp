# Task-10: Book Management API

## Overview
Task-10 is a simple ASP.NET Core Web API project for managing books. It provides CRUD (Create, Read, Update, Delete) operations for books using a RESTful API.

## Features
- **Create a Book**: Add a new book to the database.
- **Retrieve Books**:
  - Get a specific book by its ID.
  - Get a list of all books.
- **Update a Book**: Modify the details of an existing book.
- **Delete a Book**: Remove a book from the database.

## Project Structure
- **Controllers**:
  - `BooksController`: Handles API endpoints for book operations.
- **Services**:
  - `BookService`: Implements the business logic for managing books.
  - `IBookService`: Interface for the `BookService`.
- **Models**:
  - `Book`: Represents the book entity.
- **Data**:
  - `DBContext`: Manages database interactions using Entity Framework Core.

## API Endpoints
### Base URL
The API runs on `http://localhost:5221` or `https://localhost:7079` (as configured in `launchSettings.json`).

### Endpoints
1. **Create a Book**
   - **Method**: `POST`
   - **URL**: `/api/Books/Create`
   - **Body**:
     ```json
     {
       "title": "Book Title",
       "author": "Author Name",
       "yearPublished": 2025
     }
     ```
   - **Response**: Returns the created book.

2. **Get a Book by ID**
   - **Method**: `GET`
   - **URL**: `/api/Books/Get?id={id}`
   - **Response**: Returns the book with the specified ID or `404 Not Found`.

3. **Get All Books**
   - **Method**: `GET`
   - **URL**: `/api/Books/GetAll`
   - **Response**: Returns a list of all books.

4. **Update a Book**
   - **Method**: `PUT`
   - **URL**: `/api/Books/Update?id={id}`
   - **Body**:
     ```json
     {
       "title": "Updated Title",
       "author": "Updated Author",
       "yearPublished": 2025
     }
     ```
   - **Response**: Returns `200 OK` if successful or `404 Not Found` if the book does not exist.

5. **Delete a Book**
   - **Method**: `DELETE`
   - **URL**: `/api/Books/Delete?id={id}`
   - **Response**: Returns `200 OK` if successful or `404 Not Found` if the book does not exist.

## How to Run
1. Clone the repository and navigate to the Task-10 folder.
2. Restore dependencies:
   ```bash
   dotnet restore
   ```
3. Run the application:
   ```bash
   dotnet run
   ```
4. Open the Swagger UI in your browser at `http://localhost:5221/swagger` to test the API.

## Dependencies
- **ASP.NET Core**: For building the Web API.
- **Entity Framework Core**: For database interactions.
