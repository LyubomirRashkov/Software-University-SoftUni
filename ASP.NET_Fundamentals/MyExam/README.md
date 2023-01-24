## PROBLEM DESCRIPTION - ASP.NET Fundamentals Exam – 22 October 2022 - Book Library



BookLibrary is an online platform that is used to create and collect books.

### 1.	Technological Requirements and Overview

  + Use the provided skeleton – Library_Slekenton_6.0. All of the needed packages have been installed.
  + The provided skeleton consists of:
    +	Areas/Identity/Pages/Account – You are free to choose whether you'd like to use scaffolded identity or not
    +	Controllers – you should implement the controllers here
    +	Data – you should hold the entities here
    +	Models – you should implement the models here
    +	Views – you are provided with the needed views. Your task is to implement some logic regarding the logged-in/logged-out user
    +	Appsettings.json – don't forget to change the Connection string
    +	StartUp.cs – don't forget to set the DefaultIdentity options here

NOTE: You should seed the database with provided in advance data regarding the Category and Book entity. In order to do this, remove the comments from the block of code in the protected override void OnModelCreating(ModelBuilder builder) method of the DbContext.

### 2.	Database Requirements

The Database of Library:

#### ApplicationUser	

  +	Has an Id – a string, Primary Key
  +	Has a UserName – a string with min length 5 and max length 20 (required)
  +	Has an Email – a string with min length 10 and max length 60 (required)
  +	Has a Password – a string with min length 5 and max length 20 (before hashed) – no max length required for a hashed password in the database (required)
  +	Has ApplicationUsersBooks – a collection of type ApplicationUserBook

#### Book

  +	Has Id – a unique integer, Primary Key
  +	Has Title – a string with min length 10 and max length 50 (required)
  +	Has Author – a string with min length 5 and max length 50 (required)
  +	Has Description – a string with min length 5 and max length 5000 (required)
  +	Has ImageUrl – a string (required)
  +	Has Rating – a decimal with min value 0.00 and max value 10.00 (required)
  +	Has CategoryId – an integer, foreign key (required)
  +	Has Category – a Category (required)
  +	Has ApplicationUsersBooks – a collection of type ApplicationUserBook

#### Category

  +	Has Id – a unique integer, Primary Key
  +	Has Name – a string with min length 5 and max length 50 (required)
  +	Has Books – a collection of type Books

#### ApplicationUserBook

  +	ApplicationUserId – a  string, Primary Key, foreign key (required)
  +	ApplicationUser – ApplicationUser
  +	BookId – an integer, Primary Key, foreign key (required)
  +	Book – Book

Implement the entities with the correct datatypes and their relations. 

### 3.	Page Requirements

#### Index Page (logged-out user)

![изображение](https://user-images.githubusercontent.com/82647282/209884683-311d26e6-241a-47d6-ba66-38f74c0e8e66.png)

#### Login Page (logged-out user)

![изображение](https://user-images.githubusercontent.com/82647282/209884701-e8f86e52-08a8-4fb2-bcbe-f067c486219d.png)

#### Register Page (logged-out user)

![изображение](https://user-images.githubusercontent.com/82647282/209884718-d6d1ed28-2037-4331-8feb-70a8151dbee2.png)

#### /Books/All (logged-in user)

![изображение](https://user-images.githubusercontent.com/82647282/209884737-b10509dd-1ee7-49e7-99c5-130549d0f50b.png)

NOTE: If the user is logged in and tries to go to the Home page, the application must redirect them to the /Books/All.

#### /Books/Mine (logged-in user)

![изображение](https://user-images.githubusercontent.com/82647282/209884777-e9891d04-06d6-490a-9d57-74aa8ae9e231.png)

#### /Books/Add (logged-in user)

![изображение](https://user-images.githubusercontent.com/82647282/209884800-3f462f4e-8fbb-48f3-9584-61c9a8f2a629.png)

#### /Books/AddToCollection?bookId={bookId} (logged-in user)

Adds the selected book to the user's collection of books. If the book is already in their collection, it shouldn't be added. If everything is successful, the user must be redirected to the home "/Books/All" page.

#### /Books/RemoveFromCollection?bookId={bookId} (logged-in user)

Removes the selected book from the user's collection of books. If everything is successful, the user must be redirected to their collection "/Books/Mine" page.

### 4.	Functionality

The functionality of the BookLibrary Platform is very simple.

#### Users

Guests can Register, Login and view the Index Page. 

Users can Add Books and see added Books by all Users on the Home Page (/Books/All). From the Home Page (/Books/All), they can also view Info about each one of those Books and Add them to their collection.

#### Books

Books can be Added by Users. All created Books are visualized on the Home Page (/Books/All), each one in its separate rectangular element. 

Books are visualized on the Home Page (/Books/All) with all their information. 

Books are visualized on the Home Page (/Books/All) with a button – [Add to Collection].

  +	The [Add to Collection] button adds the Book to the User's collection of Books, unless it is already added.
  
Users have a My Books page where only the Books in their collection are visualized.

  +	The [Remove from Collection] button removes the Book from the User's collection of Books.

#### Redirections

  +	Upon successful Registration of a User, you should be redirected to the Login Page.
  +	Upon successful Login of a User, you should be redirected to the /Books/All.
  +	Upon successful Creation of a Book, you should be redirected to the /Books/All.
  +	Upon successful Adding a Book to the User's collection, should be redirected to the /Books/All.
  +	Upon successful Removal of a Book from the User's collection, should be redirected to the /Books/Mine.
  +	If a User tries to add an already added Book to their collection, they should be redirected to /Books/All (or just a page refresh).
  +	Upon successful Logout of a User, you should be redirected to the Index Page.
  +	If any of the validations in the POST forms don't pass, redirect to the same page (reload/refresh it).
  
### 5.	Security

The Security section mainly describes access requirements. Configurations about which users can access specific functionalities and pages:

  +	Guest (not logged in) users can access the Index page.
  +	Guest (not logged in) users can access the Login page.
  +	Guest (not logged in) users can access the Register page.
  +	Guests (not logged in) cannot access Users-only pages.
  +	Users (logged in) cannot access Guest pages.
  +	Users (logged in) can access the Books/Add page and functionality.
  +	Users (logged in) can access the Books/All page.
  +	Users (logged in) can access the My Books page.
  +	Users (logged in) can access Logout functionality.

### 6.	Code Quality

Make sure you provide the best architecture possible. Structure your code into different classes, follow the principles of high-quality code (SOLID). You will be scored for the Code Quality and Architecture of your project.