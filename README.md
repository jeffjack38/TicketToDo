# TicketToDo

TicketToDo is a web application designed to manage tasks, tickets, and their statuses. It provides functionality to add, edit, filter, and change the status of tasks.

## Features

- **Task Management**: Create, edit, and delete tasks with their respective descriptions, due dates, sprint numbers, and point values.
- **Status Tracking**: Monitor the status of tasks with options such as "To Do," "In Progress," "Quality Assurance," and "Done."
- **Filtering**: Filter tasks based on their status and due date, including options for viewing tasks due in the past, today, or in the future.
- **Tag Helpers**: Utilize tag helpers to enhance the user interface, such as custom styling for submit buttons.
  
## Tech Stack

**ASP.NET Core MVC:** Framework used for building the web application.

**Entity Framework Core:** ORM used for interacting with the database.

**C#:** Programming language used for backend logic.

**HTML/CSS/JavaScript:** Frontend technologies for user interface and interaction.

  
## Folder Structure

- **Controllers**: Contains the controller classes responsible for handling HTTP requests.
- **Models**: Defines the data models used in the application, including Tickets, Filters, and Status.
- **Views**: Contains the Razor views responsible for rendering HTML pages.
- **TagHelpers**:  Custom tag helpers to enhance the UI, such as the SubmitButtonTagHelper.
- **lib**:  Includes external libraries and dependencies, such as Bootstrap and jQuery.
- **Properties**: Configuration files for IIS settings and launch profiles.

  ## Usage
  
1. **Add New Ticket:** Navigate to the "Add" page to create a new ticket. Fill in the required details such as name, description, sprint number, point value, due date, and status.
2. **View Ticket:** Access the "Index" page to view a list of all tickets. Filter the tickets based on due date and status using the provided options.
3. **Edit and Delete Tickets:** Modify or delete existing tickets directly from the list on the "Index" page.
4. **Change Ticket Status:** Update the status of a ticket by selecting the appropriate buttons. 
