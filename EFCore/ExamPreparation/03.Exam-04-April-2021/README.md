## PROBLEMS DESCRIPTION - DATABASES ADVANCED EXAM - 4 APRIL 2021


Your task is to create a database application, using Entity Framework Core, using the Code First approach. Design the domain models and methods for manipulating the data, as described below. AutoMapper is optional.

### TeisterMask

![изображение](https://user-images.githubusercontent.com/82647282/182932960-66408c94-7a39-4955-9c64-0eee8d4f54d0.png)

### 1. Project Skeleton Overview

You are given a project skeleton, which includes the following folders:
  
  +	Data - contains the TeisterMaskContext class, Models folder which contains the entity classes and the Configuration class with connection string
  +	DataProcessor - contains the Serializer and Deserializer classes, which are used for importing and exporting data
  +	Datasets - contains the .json and .xml files for the import part
  +	ImportResults - contains the import results you make in the Deserializer class
  +	ExportResults - contains the export results you make in the Serializer class

### 2. Model Definition 

The application needs to store the following data:

##### Employee

  +	Id - integer, Primary Key
  +	Username - text with length [3, 40]. Should contain only lower or upper case letters and/or digits. (required)
  +	Email – text (required). Validate it! There is attribute for this job.
  +	Phone - text. Consists only of three groups (separated by '-'), the first two consist of three digits and the last one - of 4 digits. (required)
  +	EmployeesTasks - collection of type EmployeeTask

##### Project

  +	Id - integer, Primary Key
  +	Name - text with length [2, 40] (required)
  +	OpenDate - date and time (required)
  +	DueDate - date and time (can be null)
  +	Tasks - collection of type Task

##### Task

  +	Id - integer, Primary Key
  +	Name - text with length [2, 40] (required)
  +	OpenDate - date and time (required)
  +	DueDate - date and time (required)
  +	ExecutionType - enumeration of type ExecutionType, with possible values (ProductBacklog, SprintBacklog, InProgress, Finished) (required)
  +	LabelType - enumeration of type LabelType, with possible values (Priority, CSharpAdvanced, JavaAdvanced, EntityFramework, Hibernate) (required)
  +	ProjectId - integer, foreign key (required)
  +	Project - Project 
  +	EmployeesTasks - collection of type EmployeeTask

##### EmployeeTask

  +	EmployeeId - integer, Primary Key, foreign key (required)
  +	Employee -  Employee
  +	TaskId - integer, Primary Key, foreign key (required)
  +	Task - Task

### 3. Data Import 

For the functionality of the application, you need to create several methods that manipulate the database. The project skeleton already provides you with these methods, inside the Deserializer class. Usage of Data Transfer Objects and AutoMapper is optional.

Use the provided JSON and XML files to populate the database with data. Import all the information from those files into the database.

If a record does not meet the requirements from the first section, print an error message: "Invalid Data!".

#### XML Import

##### Import Projects

Using the file projects.xml, import the data from the file into the database. Print information about each imported object in the format described below.

Constraints

  +	If there are any validation errors for the project entity (such as invalid name or open date), do not import any part of the entity and append an error message to the method output.
  +	If there are any validation errors for the task entity (such as invalid name, open or due date are missing, task open date is before project open date or task due date is after project due date), do not import it (only the task itself, not the whole project) and append an error message to the method output.
  + Dates will be in format dd/MM/yyyy, do not forget to use CultureInfo.InvariantCulture
  + Success message: "Successfully imported project - {projectName} with {tasksCount} tasks.".
  
Upon correct import logic, you should have imported 42 projects and 62 tasks.

#### JSON Import

##### Import Employees

Using the file employees.json, import the data from that file into the database. Print information about each imported object in the format described below.

Constraints

  +	If any validation errors occur (such as invalid username, email or phone), do not import any part of the entity and append an error message to the method output.
  +	Take only the unique tasks.
  +	If a task does not exist in the database, append an error message to the method output and continue with the next task.
  + Success message: "Successfully imported employee - {employeeUsername} with {employeeTasksCount} tasks.".
  
Upon correct import logic, you should have imported 30 employees and 249 employee tasks.

### 4. Data Export

Use the provided methods in the Serializer class. Usage of Data Transfer Objects and AutoMapper is optional.

#### JSON Export

##### Export Most Busiest Employees

Select the top 10 employees who have at least one task that its open date is after or equal to the given date with their tasks that meet the same requirement (to have their open date after or equal to the given date). For each employee, export their username and their tasks. For each task, export its name and open date (must be in format "d"), due date (must be in format "d"), label and execution type. Order the tasks by due date (descending), then by name (ascending). Order the employees by all tasks (meeting above condition) count (descending), then by username (ascending).

NOTE: Do not forget to use CultureInfo.InvariantCulture. You may need to call .ToArray() function before the selection in order to detach entities from the database and avoid runtime errors (EF Core bug). 

#### XML Export

##### Export Projects with Their Tasks

Export all projects that have at least one task. For each project, export its name, tasks count, and if it has end (due) date which is represented like "Yes" and "No". For each task, export its name and label type. Order the tasks by name (ascending). Order the projects by tasks count (descending), then by name (ascending).

NOTE: You may need to call .ToArray() function before the selection in order to detach entities from the database and avoid runtime errors (EF Core bug). 