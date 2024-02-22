### **Project: Task Management System**

Create a simple task management system where users can add, edit, and delete tasks. This project will help you practice C# fundamentals, object-oriented programming, collections, file I/O, and more.

### Classes:

1. **`Task` Class:**
    - Properties: Task ID, Title, Description, Due Date, Status (e.g., Pending, Completed).
    - Methods: DisplayTaskDetails().
2. **`TaskManager` Class:**
    - Manage a collection (List) of tasks.
    - Methods: AddTask(), EditTask(), DeleteTask(), ViewAllTasks(), ViewPendingTasks(), ViewCompletedTasks(), SaveTasksToFile(), LoadTasksFromFile().
3. **`ConsoleUI` Class:**
    - Handle user input and interaction.
    - Display menus and messages.
    - Use the **`TaskManager`** to perform operations.

### Functionality:

1. **Adding Tasks:**
    - Users can add tasks with a unique ID, title, description, due date, and initial status (default to Pending).
2. **Editing Tasks:**
    - Allow users to edit task details, including title, description, due date, and status.
3. **Deleting Tasks:**
    - Users can delete tasks by providing the task ID.
4. **Viewing Tasks:**
    - Display a list of all tasks.
    - Show pending tasks separately.
    - Show completed tasks separately.
5. **File I/O:**
    - Save the tasks to a file when the application exits.
    - Load tasks from the file when the application starts.
6. **Input Validation:**
    - Validate user input to ensure it meets the expected format.
7. **Exception Handling:**
    - Handle potential errors, such as trying to edit or delete a non-existent task.

### Optional Enhancements:

- Implement priority levels for tasks (low, medium, high).
- Add the ability to mark tasks as important.
- Implement sorting and filtering options for the task list.
- Allow users to set reminders for tasks.