# Library Management System

## Overview
The Library Management System is a console-based application built in C#. It demonstrates key programming concepts such as inheritance, LINQ, asynchronous operations, and file handling. The system allows users to manage library items, register members, process checkouts and returns, and generate reports.

## Features

### 1. Library Item Management
- **Base Class**: `LibraryItem`
    - **Properties**: `Id`, `Title`, `Author`, `PublicationYear`, `Status` (enum: `Available`, `CheckedOut`, `OnHold`)
    - **Virtual Methods**: `CheckOut()`, `Return()`, `GetItemDetails()`
- **Derived Classes**:
    - `Book`: Includes properties like `Genre` and `PageCount`.
    - `Magazine`: Includes properties like `IssueNumber` and `Publisher`.
    - `DigitalResource`: Includes properties like `Format` and `FileSize`.

### 2. Library Operations
- **LibraryManager**:
    - Maintains a collection of library items.
    - Handles item checkout, return, and reservations.
    - Uses LINQ for searching and filtering items.
    - Implements extension methods for common operations.
- **LibraryMember**:
    - Stores member information (`Id`, `Name`, `Contact`).
    - Maintains a collection of borrowed items.
    - Provides methods for borrowing and returning items.

### 3. Data Handling
- Saves and loads library data asynchronously to/from JSON files.
- Implements exception handling for file operations.
- Includes backup and restore functionality.

### 4. User Interface
- Menu-driven console interface for easy navigation.
- Validates user input and displays formatted results.
- Provides error messages for invalid operations.

### 5. Additional Features
- **Event-Based Notification System**:
    - Notifies members of due dates for borrowed items.
- **Library Statistics**:
    - Generates reports on total items, borrowed items, and registered members.
    
## Usage

### Main Menu
The application provides the following options:

- **Item Management**:
    - Add, view, search, and filter library items.
    - Delete library items.
- **Member Management**:
    - Register new members.
    - View all members.
    - View borrowed items by members.
    - Delete members.
- **Checkout & Return Operations**:
    - Checkout items to members.
    - Return items.
    - Reserve items.
- **Search Library Catalog**:
    - Search for items by title, author, or type.
- **Save and Load Data**:
    - Save the current state of the library to JSON files.
    - Load data from JSON files.
- **Library Statistics**:
    - View reports on total items, borrowed items, and registered members.
- **Exit**:
    - Save data and exit the application.

## File Structure

### Key Files
- **`Program.cs`**:
    - Contains the main entry point and menu-driven interface.
- **`LibraryItem.cs`**:
    - Defines the base class and derived classes for library items.
- **`LibraryManager.cs`**:
    - Manages library items and operations.
- **`LibraryMember.cs`**:
    - Defines the member class and its operations.
- **`MemberManager.cs`**:
    - Manages library members and their activities.
- **`DataHandler.cs`**:
    - Handles saving and loading data to/from JSON files.
- **`LibraryStatistics.cs`**:
    - Generates reports on library statistics.

### Data Files
- **`items.json`**:
    - Stores library item data.
- **`members.json`**:
    - Stores library member data.

## Key Concepts Demonstrated
- **Inheritance**:
    - `LibraryItem` as a base class with derived classes (`Book`, `Magazine`, `DigitalResource`).
- **LINQ**:
    - Used for searching and filtering library items.
- **Asynchronous Operations**:
    - Saving and loading data using `async/await`.
- **File Handling**:
    - JSON serialization and deserialization for data persistence.
- **Event Handling**:
    - Notifications for due dates.
- **Encapsulation**:
    - Proper encapsulation of member and item management logic.
