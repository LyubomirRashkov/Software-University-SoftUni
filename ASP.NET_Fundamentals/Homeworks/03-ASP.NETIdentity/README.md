## PROBLEM DESCRIPTION - ASP.NET Core Identity



In this workshop we will create the TaskBoardApp – a Trello style app, that will hold a board of tasks. Each task will consist of a title and a description. The tasks will be organized in boards, which will be displayed as columns (sections): Open, In Progress and Done.

The app will support the following operations:

  +	Home page: '/'
  +	View the boards with tasks: '/Boards'
  +	View task details (by id): '/Tasks/Details/:id'
  +	Add new task (title + description + board): '/Tasks/Create'
  +	Edit task / move to board: '/Tasks/Edit/:id'
  +	Delete task: '/Tasks/Delete/:id'

Here is how each page in our app will look like:

![изображение](https://user-images.githubusercontent.com/82647282/209890733-e3e4e432-9ef5-434e-9538-3c41538e72e9.png)

![изображение](https://user-images.githubusercontent.com/82647282/209890740-8ca0ccbd-eed2-455a-a549-ac2b75068745.png)

![изображение](https://user-images.githubusercontent.com/82647282/209890747-fe681fac-ca5e-4416-9ff1-fc3f65d87cd1.png)

![изображение](https://user-images.githubusercontent.com/82647282/209890754-e1da0390-24b6-4c3b-917d-d8263f51c4bc.png)

![изображение](https://user-images.githubusercontent.com/82647282/209890756-813575d9-13ae-4694-9e89-dd5905d54d81.png)

![изображение](https://user-images.githubusercontent.com/82647282/209890761-3f9cb076-0926-4136-ba13-831a1d878880.png)

### 1.	Create New Project

First, we need to create a ASP.NET Core MVC application in Visual Studio. Open VS and follow the steps to create the app. The app name should be TaskBoardApp.

![изображение](https://user-images.githubusercontent.com/82647282/209890783-8340bd59-c9bd-46d2-bc87-62be241281f4.png)

![изображение](https://user-images.githubusercontent.com/82647282/209890796-9b2f86f8-45d5-4d96-a115-3f5bb5761017.png)

![изображение](https://user-images.githubusercontent.com/82647282/209890800-e083cc2f-2276-4fe7-a218-197fe1afe3ea.png)

Set up the app with "Individual Accounts", as we want to have "Register" and "Login" functionalities. 

![изображение](https://user-images.githubusercontent.com/82647282/209890821-26a410f3-b94a-443e-99d6-8a3bf5e3e8c2.png)

### 2.	Examine the App and Clean the Project

#### Examine the App

Run the created app in the browser. The "Home" page looks like this:

![изображение](https://user-images.githubusercontent.com/82647282/209890839-3958df5a-53e5-4090-bce9-cb9d1784ba48.png)

The difference between the projects from the previous sessions and this one is that our project now has "Register" and "Login" pages. They come from the "Individual Accounts" functionality that we added to the app.  

The "Register" page looks like shown below but the register functionality is still not working:

![изображение](https://user-images.githubusercontent.com/82647282/209890862-1e78d00e-ad77-4d56-b5f9-051b195e28f7.png)

The "Login" page looks like shown below but the register functionality is also still not working.

![изображение](https://user-images.githubusercontent.com/82647282/209890878-48c663fa-41d0-4f04-873c-e5b920c450b5.png)

#### Clean the Project

First, let's take a look at the Program.cs class. In the previous session we had to add the following code by hand, but because of the type of the project template that we chose, it is added automatically.

![изображение](https://user-images.githubusercontent.com/82647282/209890901-cfe2597d-c4e0-4c2c-877e-32edee02fa85.png)

Let's take a look at the "appsettings.json" file. As you can see, the file already has the connection string. This also comes from the project template that we chose. 

![изображение](https://user-images.githubusercontent.com/82647282/209890914-8e814c59-6c7d-4941-87da-c4a89d2b992e.png)

Now, let's examine the HomeController class. We'll be needing only the Index() action, so we can delete the unnecessary code. The class should look like this:

![изображение](https://user-images.githubusercontent.com/82647282/209890921-35644793-7004-421e-87b2-bc98529de0cb.png)

As we deleted the Privacy() action from the HomeController, it's best to delete the view from our project. Find it Find it in the "/Views/Home" folder and delete it:

![изображение](https://user-images.githubusercontent.com/82647282/209890932-4a471ab8-3d07-4b09-b6a1-d12b18884e78.png)

Let's modify the _Layout.cshtml file and remove the Privacy links as we already deleted the view and the action.

![изображение](https://user-images.githubusercontent.com/82647282/209890953-bb74f8e6-aba8-40fe-b912-8125e7bf8350.png)

![изображение](https://user-images.githubusercontent.com/82647282/209890963-e1b7acae-78de-4d7e-8f0d-1caf1bc3ab32.png)

Now our app should look like this:

![изображение](https://user-images.githubusercontent.com/82647282/209890980-03c70034-314e-4381-bc8b-aa49c8ee4fcf.png)

### 3.	Define Entities

We should start with creating the data models, which we will need for our database. We will have three data model classes – User, Task and Board.

First, create the User class in the "Data" folder of the project. It's a good practice for the data model classes to be in a separate folder from the ApplicationDbContext class – the "Entities" folder. 

![изображение](https://user-images.githubusercontent.com/82647282/209996743-1114a890-0357-4a99-b57a-2b5aed75d9e9.png)

The database should look like this when it is created in SQL Server Management Studio:

![изображение](https://user-images.githubusercontent.com/82647282/209996762-a94a8ef4-3e45-40da-ba31-b113de93a72e.png)

Before we start creating the entity classes, it is a good idea to create a separate class, which will hold the constants for the max and min values of the entities' properties. In the "Data" folder, create the DataConstants class:

![изображение](https://user-images.githubusercontent.com/82647282/209996822-244a24d0-c19a-4184-bd0d-197217aef0b9.png)

#### The User Entity Class

The User class should inherit the IdentityUser (the default user) and should have the following properties:

  +	Id – a unique integer, PrimaryKey
  +	FirstName – a string with max length 15 (required)
  +	LastName – a string with max length 15 (required)

Create the User class in the "Entities" folder with its properties without restrictions:

![изображение](https://user-images.githubusercontent.com/82647282/209996869-7145614e-148e-4894-ab21-796286a0abe3.png)

Note that we use init setters only for properties, which won't be changed after the initialization. For example, the FirstName and the LastName properties of the user will always be the same.

Now, add the [Required] attribute to those properties, which must have a value.

![изображение](https://user-images.githubusercontent.com/82647282/209996907-b8adbae0-e44b-4f2a-b368-8d1c03b8f0c1.png)

Now we should restrict the properties. The only restriction we will set is for the max length, as the database doesn't care about other validations. Min length, range and other restrictions are added to model classes.

The properties, which should have a max length, are FirstName and LastName.

Before that, we should create a User class in the DataConstants class for the constants, connected to the user entity and the constants themselves:

![изображение](https://user-images.githubusercontent.com/82647282/209996953-4b2b595c-99d6-4f76-9ea2-22c3a402d605.png)

Don't forget to add the needed namespace to use the constants class in the User class:

![изображение](https://user-images.githubusercontent.com/82647282/209996977-b428d967-f964-4e20-9864-d5239248fd16.png)

Use the constants in the [MaxLength] attribute to set the max length like this:

![изображение](https://user-images.githubusercontent.com/82647282/209996996-73f1a35e-6de3-4b39-911c-6921a79b2ee4.png)

Now the User entity class is ready. 

Now we should replace the IdentityUser with our custom user everywhere in our code. First, go to the Program class and modify the Identity service:

![изображение](https://user-images.githubusercontent.com/82647282/209997018-73f8a47d-f51c-4ffd-b4af-73c93127acb5.png)

Next, modify the TaskBoardAppDbContext class, which should inherit the IdentityDbContext with User:

![изображение](https://user-images.githubusercontent.com/82647282/209997042-fc582c5d-a0c6-4f7c-8e00-49a2545d4eb6.png)

Finally, go to _LoginPartial.cshtml, which has injected services with IdentityUser. Import the namespace of the User class directly in the view (as we don't need it anywhere else). Then, make the SignInManager and UserManager use the custom user. Modify the view like this:

![изображение](https://user-images.githubusercontent.com/82647282/209997066-e7b9f1b4-0ab1-464b-a621-efd8d139f40a.png)

#### The Task Entity Class

The Task class should have the following properties:

  +	Id – a unique integer, Primary Key
  +	Title – a string with min length 5 and max length 70 (required)
  +	Description – a string with min length 10 and max length 1000 (required)
  +	CreatedOn – date and time
  +	BoardId – an integer
  +	Board – a Board object
  +	OwnerId – an integer (required)
  +	Owner – a User object

First, create constants for the Title and Description properties length in the DataConstansts class:

![изображение](https://user-images.githubusercontent.com/82647282/209997116-ad6dc0f7-41ea-4391-858f-da13b966b25c.png)

Then, use them in the Task class and create its properties as shown below:

![изображение](https://user-images.githubusercontent.com/82647282/209997138-3a910772-dd08-41cd-a4c5-33991a406937.png)

Note that the OwnerId property is of type string and has the [Required] attribute, as the IdentityUser class has strings for ids.

#### The Board Entity Class

The Board class should have the following properties:

  +	Id – a unique integer, Primary Key
  +	Name – a string with min length 3 and max length 30 (required)
  +	Tasks – a collection of Task

First, create constants for the Name property max length in the DataConstants class:

![изображение](https://user-images.githubusercontent.com/82647282/209997194-046e13a5-f2a1-4cc8-a583-b00b252a0587.png)

Then, use the constant in the Board class and create its properties as shown below. Don't forget that you should initialize the Tasks property either inline or in a constructor (use only one of the ways for your whole app):

![изображение](https://user-images.githubusercontent.com/82647282/209997240-2fab530f-2580-4fbc-bd54-5abd041e37b8.png)

Note that you don't need to set the Id property as a primary key in any way – this is done by default in EF Core because of the "Id" property name. Also, that's why we don't need to set the BoardId and OwnerId properties of the Task class as foreign keys, as we have named the properties by the convention "{className}Id" ("Board" + "Id" and "Owner" + "Id").

As you now have all entity classes your app needs, use them for the database.

#### 4.	Define the DbContext

To start with, it is a good idea to rename the ApplicationDbContext class to "TaskBoardAppDbContext", so that it is connected to the idea of our application:

![изображение](https://user-images.githubusercontent.com/82647282/209997309-639f1fb8-9f10-4d8c-a321-a6fe550c7b06.png)

![изображение](https://user-images.githubusercontent.com/82647282/209997318-56ba775a-9f6a-43f8-9f35-49741b474d19.png)

We should use the Migrate() method in the constructor in order for the changes to be applied to tbe database directly.

![изображение](https://user-images.githubusercontent.com/82647282/209997344-d1c4d8fe-6e27-4777-abba-65402d37de86.png)

Create the DbSet properties for the tables in the database:

![изображение](https://user-images.githubusercontent.com/82647282/209997374-f2480bd2-300a-4dfd-8c30-f68d3b77ce18.png)

Warning: EF Core uses a "cascade" delete by default when removing an entity. This means that if a record in the parent table is deleted, then the corresponding records in the child table will automatically be deleted. To prevent this from happening, it's a good practice to set the delete behavior to "restrict", so that an entity, which has connections to other entities in the database, won't be deleted. 

To do this, we should override the OnModelCreating(ModelBuilder builder) method in the TaskBoardAppDbContext class:

![изображение](https://user-images.githubusercontent.com/82647282/209997417-8fbe96ae-c06f-4616-860e-b169ef8b5bd0.png)

Then, we should set the foreign key relations and change the delete behaviour.

At the end, invoke the base OnModelCreating() method:

![изображение](https://user-images.githubusercontent.com/82647282/209997451-873202c1-0a37-4f5b-bf8a-ba3c83a32c43.png)

Now our database structure is ready. If you migrate it now, however, it will be created with empty tables. For this reason, let's see how to seed some data to fill in the database tables.

#### 5.	Seed the Database

Now, we want to populate the database with an initial set of data. This will include four events, three boards (OpenBoard, InProgressBoard and DoneBoard) and one user.

First, create properties for the above objects in the TaskBoardAppDbContext class:

![изображение](https://user-images.githubusercontent.com/82647282/209997496-8732456d-4743-44ca-91b9-20d0d92290ab.png)

Then, we will use separate methods to add data to these objects, which will be added to the corresponding database tables in the OnModelCreating(ModelBuilder builder) method. Add the following lines of code to the method, before invoking the base one:

![изображение](https://user-images.githubusercontent.com/82647282/209997531-6a590814-f52c-4e38-99fb-2aa66b4ed8fe.png)

Warning: When invoking more than one seeding method, it is important that the seeding methods are invoked in the correct order, as they depend on each other.

![изображение](https://user-images.githubusercontent.com/82647282/209997591-31aa5873-a767-457c-b785-1a98fca18dd3.png)

Start by implementing the SeedUsers() method, which will create the GuestUser for the database. 

First, we will need to instantiate the PasswordHasher class, which will save our user's password as a hash in the database:

![изображение](https://user-images.githubusercontent.com/82647282/209997620-0b672eed-ee03-4362-b80b-bbec09ee25f1.png)

Then, create the user with an id (its value does not matter), username, normalized username, email, normalized email, first and last name and with a hashed password. Note that the normalized username and normalized email should be added or the user will not be able to log in the app. Do it like this:

![изображение](https://user-images.githubusercontent.com/82647282/209997643-1aa32081-f1a3-4034-9694-4cf6fac69105.png)

Next, seed the boards, which will be saved as OpenBoard, InProgressBoard and DoneBoard:

![изображение](https://user-images.githubusercontent.com/82647282/209997666-18a0b5c5-24b0-4887-b689-24ca9adad819.png)

The tasks are already created and added with this code:

![изображение](https://user-images.githubusercontent.com/82647282/209997687-09650c52-1a1b-4557-a9d1-96ebc118b6cc.png)

Now we have a db context with seeded data and our database is ready to be migrated.

#### 6.	Create a Migration

We will now create a migration to the database. Before that, however, let's give the database a good name. 

To do that, first we need to add the connection string in the "appsettings.json" file:

![изображение](https://user-images.githubusercontent.com/82647282/209997725-592080ce-2333-490f-a735-687023d2e839.png)

Next, open the Package Manager Console from [Tools] -> [NuGet Package Manager] -> [Package Manager Console] to write commands for managing migrations:

![изображение](https://user-images.githubusercontent.com/82647282/209997765-ad0f46f3-211f-424d-addc-cd70f404ccc5.png)

In the console, write a command for adding a migration to the "Data/Migrations" folder with a given name and press [Enter] to execute it. 

Now you should have a new migration in the "Migrations" folder:

![изображение](https://user-images.githubusercontent.com/82647282/209997792-54f09dc4-dece-4ba7-bcd4-237c66edaf51.png)

![изображение](https://user-images.githubusercontent.com/82647282/209997806-3661ee17-e289-4086-b8d7-583be545d6cc.png)

Note that there's already a migration called 000000000000000_CreateIdentitySchema.cs. This is because of the "Individual accounts" project template that we chose for our project.

Examine the tables and its restrictions in the new migration – if something is wrong, delete the migration with the "Remove-Migration" command or delete the migration file. Don't forget that you should also delete the database from SQL Server Management Studio, or errors will appear.

Now run the app in the browser – there should not be any errors. Then, look at the newly-created database in SQL Server Management Studio and examine the tables – it should be present and have the right restrictions and relationships:

![изображение](https://user-images.githubusercontent.com/82647282/209997848-bfa5704c-c14c-4850-96da-bea4ca22d733.png)

Now run the app in the browser – there should not be any errors. Then, look at the newly-created database in SQL Server Management Studio and examine its tables – all tables we created should be present and have the right restrictions and relationships.

### 7.	Implement Register/Login/Logout

Now we want to clear the "Login" and "Registration" pages from functionalities that we won't use. Also, we want to add new fields to the registration form and implement the "Logout".

#### Scaffold Identity

To change the "Login" and "Register" pages and their logic, we should first access their source code. To do this, we should scaffold the Identity pages, which means to generate the pages code.

The scaffolded pages will be part of the "/Areas/Identity" folder. To scaffold, right-click on the "Identity" folder and choose [Add] -> [New Scaffolded Item…]:

![изображение](https://user-images.githubusercontent.com/82647282/209997931-87fd1be3-ceb0-4596-8d0d-ccc2f5c84e13.png)

On the next step, go to the [Identity] tab and choose its only option:

![изображение](https://user-images.githubusercontent.com/82647282/209997949-f79a6a67-117c-4a71-bdb7-47ba19e52f71.png)

Then, on the "Add Identity" window you should set the _Layout.cshtml as a layout page, check the pages to be scaffolded ("Login" and "Register") and select the db context class of our app. Do it like this:

![изображение](https://user-images.githubusercontent.com/82647282/209997978-176d9bcb-0533-4eaa-856b-e4e9fd85889d.png)

Click the [Add] button and examine the scaffolded pages in the "/Areas/Identity" folder:

![изображение](https://user-images.githubusercontent.com/82647282/209998007-acdd789d-e73f-4f37-b880-7841afddce5f.png)

Note that the generated pages are Razor pages. They have two files – one with extension .cshtml and one with .cshtml.cs. The Login.cshtml and Register.cshtml files are Razor pages and the logic behind them is in the Login.cshtml.cs and Register.cshtml.cs files. The LoginModel and RegisterModel classes hold the logic behind the pages. They have OnGetAsync(…) and OnPostAsync(…) methods, which are responsible for handling requests to the page.

You can now clear some generated folders, files and classes and modify others. For example, 

First, delete the Data folder from the /Areas/Identity folder.

Next, you can move the namespaces from the _ViewImports.cshtml file in the "/Areas/Identity/Pages" folder to the _ViewImports.cshtml file in the "/Areas/Identity/Pages/Account" folder:

![изображение](https://user-images.githubusercontent.com/82647282/209998053-e0dade85-ed03-4f04-8317-8b434fcce805.png)

![изображение](https://user-images.githubusercontent.com/82647282/209998068-e9a5c976-30d7-4a72-b5db-de78e65821cf.png)

Delete the classes in the "Areas" folder, which are not in the "Account" folder. Leave only the _ViewStart.cshtml file – others are unnecessary. The left classes should be the following:

![изображение](https://user-images.githubusercontent.com/82647282/209998091-8fdbe237-16ef-4c2c-8ced-ade89fda75f1.png)

You can also delete the ScaffoldingReadMe.txt file from the solution:

![изображение](https://user-images.githubusercontent.com/82647282/209998158-deca884d-3649-4425-9551-0b70cc25c288.png)

#### Modify the "Register" Page

Now we want to modify our "Register" page. It should not have external logins, but should have fields for username, first and last names. It should look like 
this:

![изображение](https://user-images.githubusercontent.com/82647282/209998273-0e92120e-3537-4f4f-9738-9044dbf38911.png)

Go to the Register.cshtml file to clear the unnecessary view code. We want to remove the section for registering with an external provider. Do it like this:

![изображение](https://user-images.githubusercontent.com/82647282/209998357-991b7374-f058-4945-b825-3b02e62cc471.png)

![изображение](https://user-images.githubusercontent.com/82647282/209998396-d47f30b0-2ec3-424c-b87e-7996af5a4998.png)

Also, we need to add text fields for the username and the first and last names of the user. Add them like this:

![изображение](https://user-images.githubusercontent.com/82647282/209998473-47242ce3-c49d-4d75-84af-c70961f1d1ef.png)

Also, if you want your form to be on the center of the screen, as it looks better, add the following CSS classes:

![изображение](https://user-images.githubusercontent.com/82647282/209998534-5745badc-428e-4457-ab4e-310130f9c400.png)

Now we will add the "Username", "FirstName" and "LastName" properties to the InputModel in the RegisterModel class. Open the Register.cshtml.cs file and do it like this:

![изображение](https://user-images.githubusercontent.com/82647282/209998586-6595559d-6cb1-4812-b0e4-941ee3fe6fa9.png)

![изображение](https://user-images.githubusercontent.com/82647282/209998617-95d52fa1-e8bc-44b6-8797-94498b403c5a.png)

![изображение](https://user-images.githubusercontent.com/82647282/209998654-81cb583f-bca1-4209-938a-46972b095965.png)

As we added the properties, it is important to use them when creating a user to fill the database columns. To do this, modify the OnPostAsync(…) method like this:

![изображение](https://user-images.githubusercontent.com/82647282/209998738-344b4be7-3adc-4c22-a4b7-b73066b77136.png)

Now it's time to clear the RegisterModel class from things we won't use like external logins, email sender, etc. Don't forget to change IdentityUser to our User. Your class should look like this:

![изображение](https://user-images.githubusercontent.com/82647282/209998834-72567923-98a3-4b07-8832-27f617dda9b7.png)

![изображение](https://user-images.githubusercontent.com/82647282/209998867-5fcba0c2-d111-4652-bc2b-b78df971808d.png)

![изображение](https://user-images.githubusercontent.com/82647282/209998908-44fc8312-ca7e-4af8-80b3-2c00b47493a1.png)

If you try to register now, upon successful registration you will be redirected to the "Home" page as a registered user. If you want to be redirected to another page, you should modify the returnUrl string in the OnPostAsyc(…) action.

Now open the "Register" page in the browser. It should look as shown on the beginning of the task. Try to register a new user. You should see the following error messages: 

![изображение](https://user-images.githubusercontent.com/82647282/209999054-333ec047-5e55-416b-90ee-ad35271f2ff5.png)

This is because our app is using the default password requirements, which are too strict. We can change them by adding the following lines to the Program class:

![изображение](https://user-images.githubusercontent.com/82647282/209999124-48885032-962c-4bcd-8480-28c4c1168e43.png)

Let's try again to register a new user. The registration should be successful and the user should appear in the database. They should also have first and last names:

![изображение](https://user-images.githubusercontent.com/82647282/209999196-0f227e9e-946e-4122-900d-7bcb874a9b25.png)

#### Modify the "Logout" Page

Now, if you try to logout of the app, you should receive an error message. This is because we have to change the IdentityUser to User in the Logout.cshtml.cs. The file should look like this:

![изображение](https://user-images.githubusercontent.com/82647282/209999323-1c24edf1-0ba5-420c-99fe-8273830537e5.png)

#### Modify the "Login" Page

It is time to modify the "Login" page as well to clear it from unnecessary code in its generated class. The page should look like this:

![изображение](https://user-images.githubusercontent.com/82647282/209999420-c59732d4-9618-47fc-8132-038716d69c5f.png)

Go to the Login.cshtml view and remove links for email confirmation, external login and forgotten password. Also, add the needed classes to center the page content. The Login.cshtml view should look like this:

![изображение](https://user-images.githubusercontent.com/82647282/209999502-927a75f8-ec2d-43b7-9944-8a8fee191fdd.png)

Now modify the LoginModel class in the Login.cshtml.cs file as shown below:

![изображение](https://user-images.githubusercontent.com/82647282/209999588-612f9fb1-9430-4ad8-a04e-632b06bb1b96.png)

![изображение](https://user-images.githubusercontent.com/82647282/209999636-7d3f606f-5c72-40ba-a544-9543095f58d4.png)

![изображение](https://user-images.githubusercontent.com/82647282/209999673-23f7f85c-f252-41cc-b24b-01fe01fee33a.png)

![изображение](https://user-images.githubusercontent.com/82647282/209999709-b23b8473-cba8-4d7a-9d14-e93fd8ae9143.png)

![изображение](https://user-images.githubusercontent.com/82647282/209999759-5f83c205-db2f-406a-9e17-74525d809ecc.png)

Try to log in with the new user we created. Login should be successful.

Note that if you want to be redirected somewhere else upon login, you should specify the location in the returnUrl string.

### 8.	Modify View for Users

Let's change how the navigation bar looks for a user that is logged in.

#### Display User Names in the Navigation Bar

Let's use the new user data in the welcoming in our navigation bar. It should look like this:

![изображение](https://user-images.githubusercontent.com/82647282/209999947-2679d642-1dc0-4d94-96d2-8048c10b0b46.png)

We want to remove the link from the "My Profile" on the "Hello " message.

Go to the _LoginPartial.cshtml view and remove the link. The file should look as shown below:

![изображение](https://user-images.githubusercontent.com/82647282/210000063-83cb2965-96c0-45fe-8d76-4b82ac651a4d.png)

### 9.	Create the MVC Structure of the App

Now that we are ready with the Login/Logout and Register part, it's time to create the MVC structure of our app. We will have three controllers – HomeController, TasksController and BoardsController. 

#### Home page 

We already have the HomeController in our project and we already modified it, but we still have to modify the view, too.

Go to the /View/Home/Index.cshtml file and change the code as shown below:

![изображение](https://user-images.githubusercontent.com/82647282/210000216-d35da9e7-000a-4c99-80d4-832d52ab3294.png)

Later the index page will display the tasks count according to the board they are attached to. For now, we will leave the view this way.

#### Display Boards

Let's modify our app, so it we can see the three types of boards. In order to do so, first we need to create a boards controller in the "Controllers" folder.

For now we will only inject the TaskBoardAppDbContext through the constructor and assign it to a variable to use it:

![изображение](https://user-images.githubusercontent.com/82647282/210000380-76d0a04a-40ad-4c18-9998-a637de20d776.png)

Our next step should be creating the BoardViewModel in the "Models" folder.

![изображение](https://user-images.githubusercontent.com/82647282/210000468-2e3f8671-c7b0-4b1c-bf06-d184f2d02664.png)

Each of the boards should display the tasks that are assigned to it, so the BoardViewModel should have a property for the collections of tasks. This means that we need another view model for the tasks. Let's add it to the "Models" folder. As we will have several models for the tasks, we can create a "Tasks" folder in the "Models" one, so that the files are more organized.

![изображение](https://user-images.githubusercontent.com/82647282/210000552-1232e703-3a64-4b74-814d-adf8ee35bab7.png)

The TaskViewModel should look like this:

![изображение](https://user-images.githubusercontent.com/82647282/210000631-35b0a5e6-0c05-495b-a87b-617c7f45f07d.png)

Now we can go back the BoardsController and add the action that will display the boards and their tasks. The All() action will extract the boards and their tasks from the database to model collections, which will be passed to a view.

![изображение](https://user-images.githubusercontent.com/82647282/210000715-db3a1f34-80da-4a6d-b0aa-7ce3681c7ba3.png)

Now we should create the "All.csthml" view file. We will create this view in a new folder, called "Boards", which will be located in the "Views" folder.

![изображение](https://user-images.githubusercontent.com/82647282/210000807-43f4f0e6-4618-4ed8-8d1d-15a3f5980e41.png)

Run the app in the browser and go to /Boards/All. 

When you log in with the Guest user, it should look like this:

![изображение](https://user-images.githubusercontent.com/82647282/210001360-382c09d9-7405-4124-98f2-d285f254ab17.png)

When you log in with another user, it should look like this:

![изображение](https://user-images.githubusercontent.com/82647282/210001469-50305afa-d15f-47f8-ad42-3a570e058cba.png)

Now we should add a link to the /Boards/All page in the navigation. The link should be visible only to logged in users.

In order to do so, go to the "_Layout.cshtml" file and modify the code as shown below:

![изображение](https://user-images.githubusercontent.com/82647282/210001580-56ea0750-de2a-4d53-b094-da13688d1812.png)

When you run the app, the navigation should look like this:

![изображение](https://user-images.githubusercontent.com/82647282/210001655-58f81ea3-0d1b-491b-a0e1-5267e772ad12.png)

#### Create task

Now, let's extend the functionality of our app and modify it so that each user may be able to add a new task. The app should display a form for adding a task and it will look like this:

![изображение](https://user-images.githubusercontent.com/82647282/210001766-91581532-b410-445f-a463-78380625860e.png)

First, we need to create a TaskFormModel in the "/Models/Task" folder. We will add validation attributes to the model property. The [Required] attribute will check if the model property holds any value and the [StringLength] will check the length of the string that is held as a value.

![изображение](https://user-images.githubusercontent.com/82647282/210001843-035f1f30-8358-4db3-bef5-999c92ec0022.png)

As you can see, we will need another model, called TaskBoardModel, so you should create it in the "/Models/Task" folder , too.

![изображение](https://user-images.githubusercontent.com/82647282/210001910-ba5194f6-8b5b-4485-8806-280dce58537a.png)

We don't have a TasksController yet, so you should create it in the "Controllers" folder. Don't forget to inject the TaskBoardAppDbContext through the constructor and assign it to a variable to use it:

![изображение](https://user-images.githubusercontent.com/82647282/210002011-85b86cce-9236-47ed-a771-96dcc9444481.png)

Now that we have created the needed models, we should go to TasksController and implement the Create() method. This method will create a new Task object and then add it to the DbSet.

![изображение](https://user-images.githubusercontent.com/82647282/210002088-729e6e48-bd34-4aa6-8049-42c02c8bae87.png)

![изображение](https://user-images.githubusercontent.com/82647282/210002114-e0bc3297-ddac-4ee1-aed9-4cfeaaff4d6e.png)

You should add the following code to the TasksController. 

![изображение](https://user-images.githubusercontent.com/82647282/210002212-7eff1583-2a6b-4fd0-9043-79b8529e3b23.png)

The ClaimTypes.NameIdentifier returns the user id when requested. 

Our next step is to create a new folder – "Tasks" in the "Views" folder, so that we can add a new "Create.cshtml" in it for the "Create Task" Page view.

Run the app in the browser and go to /Tasks/Create. It should look like this:
 
![изображение](https://user-images.githubusercontent.com/82647282/210002401-5de708d3-72fd-406d-a6ac-ea02d8cd1897.png)

All that is left to do is add a link to the "/Tasks/Create" page in the navigation. Go to the "_Layout.cshtml" file and modify the code as shown below:

![изображение](https://user-images.githubusercontent.com/82647282/210002510-dcd0506e-dff3-4145-8749-f631623e517a.png)

Finally, when you run the app in the browser again, the navigation should look like this:

![изображение](https://user-images.githubusercontent.com/82647282/210002578-c8a9b55c-c3f2-4b5c-b5e2-8bdbb28f8aca.png)

#### View task details

Now, let's extend the functionality of our app and modify it so that each user may be able to see each task details. The app should look like this:

![изображение](https://user-images.githubusercontent.com/82647282/210002690-e390afa0-497e-4d84-ae17-efdc29e1e2ff.png)

![изображение](https://user-images.githubusercontent.com/82647282/210002728-6c8dc431-422f-476f-aeaa-915d3ee08f19.png)

Note that the different users see different views – the reason for this is that in the first screenshot the logged in user is the owner of the task and in the second screenshot the logged in user is not the owner.

Let's create a TaskDetailsViewModel which will inherit the TaskViewModel. It will have two additional properties – CreatedOn and Board.

![изображение](https://user-images.githubusercontent.com/82647282/210002822-a4b0e2b4-fb35-45f8-8993-85d5f3b68024.png)

Now that we have the model, we can go to the TasksController and add the Details() action.

![изображение](https://user-images.githubusercontent.com/82647282/210002925-c1f81c58-94a8-41f4-a98b-c692da37bfdb.png)

Now we have to create the view for the "/Tasks/Details/{id}" page. 

#### Edit task

The next step in creating the TaskBoardApp is adding the "Edit Task" page. It will display a form for editing a task and it will look like this:

![изображение](https://user-images.githubusercontent.com/82647282/210003096-3b7cc65f-34ae-421b-b36d-0488ff498f2a.png)

We already have a TaskFormModel and we'll use it again. First, we need to modify the TasksController and add an Edit() action, which will pass a Task model to the view and find and update the task in the database.

![изображение](https://user-images.githubusercontent.com/82647282/210003141-b6f38f14-35e6-495d-815a-1a1f418fd8a4.png)

![изображение](https://user-images.githubusercontent.com/82647282/210003155-12df3397-3423-4f14-80e6-ddbfe18e5825.png)

Our next step is to create the view for editing a task. 

#### Delete task

The view for deleting a task is similar to the view for editing a task. It should look like this:

![изображение](https://user-images.githubusercontent.com/82647282/210003200-b291d36d-dce8-4254-8778-cbb463d2154f.png)

But first, let's add the Delete() action to the TasksController:

![изображение](https://user-images.githubusercontent.com/82647282/210003238-66760d5a-c1cd-482e-b858-58c7c155415e.png)

![изображение](https://user-images.githubusercontent.com/82647282/210003246-7f9313a8-c20c-4b44-942a-091264326766.png)

After we have added the Delete() action, let's create the Delete view file.

#### Home page

Finally, we can go back to the Home page so that we can modify it to show the tasks count. Let's go back to the HomeController. Don't forget to inject the TaskBoardAppDbContext through the constructor and assign it to a variable to use it:

![изображение](https://user-images.githubusercontent.com/82647282/210003295-5ac300cb-f742-444f-b25c-141e435bb4af.png)

Now we need to create a HomeBoardModel and a HomeViewModel in the "Models" folder. 

![изображение](https://user-images.githubusercontent.com/82647282/210005519-6034d70e-5702-45bc-ba2c-8ab0f52ab20e.png)

![изображение](https://user-images.githubusercontent.com/82647282/210005536-fda8f4ca-0bcd-4b7f-bc3e-b6b2b4856683.png)

Now that we have created the models, go back to the controller and this code:

![изображение](https://user-images.githubusercontent.com/82647282/210005567-3f364c83-dff6-4729-a223-ce4804ab1134.png)

And finally, we have to modify the view file. Go to "/Home/Index.cshtml" file and modify it.

Run the app in the browser and it should look like shown below:

![изображение](https://user-images.githubusercontent.com/82647282/210005647-1c3cf6ef-2c86-4f7e-abda-16c89ed53458.png)
