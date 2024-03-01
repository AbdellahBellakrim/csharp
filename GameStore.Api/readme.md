# **GameStoreApi - ASP.NET Core 7**

## **Project Overview**

GameStoreApi is a RESTful API built using C# and ASP.NET Core 7 to manage a game store. The API follows a minimal approach, implementing CRUD operations (POST, GET, PUT, DELETE) with concepts such as route groups, input validation, extension methods, data transfer objects (DTO), dependency injection, singleton pattern, and the repository pattern.

The project utilizes SQL Server with ASP.NET configuration and .NET Secret Manager to securely connect the API to the database. Entity Framework Core is employed as the ORM (Object-Relational Mapping) tool to facilitate querying and modifying the database using C# language. Additionally, the asynchronous programming model is adopted to enhance API performance and scalability.

## **Module 1: Setting Up and Configure a Basic REST API**

### **1. Identify Resources for the REST API**

Define the entities/resources that the API will manage. In this case, it could be "Game" as the primary resource.

### **2. Understand REST API and HTTP Methods in ASP.NET Core**

Familiarize yourself with RESTful principles and HTTP methods (GET, POST, PUT, DELETE). Understand how these methods map to CRUD operations.

### **3. Create and Configure Minimal API in ASP.NET Core**

Set up a minimal API project using ASP.NET Core 7. Configure routing, middleware, and any necessary dependencies.

### **4. Implement Basic REST API**

Create endpoints for basic CRUD operations on the identified resources. Implement the minimal API approach, focusing on simplicity and efficiency.

### **5. Test CRUD Operations Using Postman**

Use Postman or a similar tool to test the API's functionality. Verify that POST, GET, PUT, and DELETE operations work as expected for the Game resource.

## **Module 2: Code Organization and Validation**

### **1. Use Route Groups to Organize API Endpoints**

Organize API endpoints using route groups to enhance code structure and maintainability. Group related endpoints together for better organization and readability.

### **2. Validate API Parameters**

Implement input validation to ensure that the API parameters meet the required criteria. Use validation attributes or custom validation logic to validate incoming data.

### **3. Use Extension Methods for Better Code Organization**

Leverage extension methods to organize and extend the functionality of your code. This promotes cleaner code structure and reusability.

## **Module 3: Using Design Patterns and Best Practices**

### **1. Use Repository Pattern for Better Data Manipulation**

Implement the repository pattern to separate data access logic from business logic. This enhances data manipulation, promotes code maintainability, and allows for easier testing.

### **2. Use Dependency Injection to Write Maintainable Code**

Leverage dependency injection to manage object dependencies and write maintainable and testable code. ASP.NET Core's built-in dependency injection system helps organize and simplify code.

### **3. Understand Service Lifetimes**

Explore different service lifetimes available in ASP.NET Core, including Singleton, Scoped, and Transient. Choose the appropriate lifetime for your services based on the desired behavior and performance characteristics.

### **4. Use Data Transfer Objects (DTOs) to Define Clear Contract Between Client and Server**

Implement Data Transfer Objects (DTOs) to define a clear contract between the client and server. This helps in shaping the data exchanged between different parts of the application and improves communication between layers.

## **Module 4: Using .NET Configuration to Access SQL Server**

### **1. Stand-Up SQL Server Instance Using Docker**

Set up a SQL Server instance using Docker to create a portable and easily reproducible database environment.

### **2. Use the .NET Configuration System**

Leverage the .NET Configuration system to manage application settings, including database connection strings. This allows for flexibility and easy configuration changes.

### **3. Use the .NET Secret Manager**

Enhance security by utilizing the .NET Secret Manager to store sensitive information such as database connection strings. This ensures that sensitive data is kept separate from the codebase and is accessible only to authorized users.