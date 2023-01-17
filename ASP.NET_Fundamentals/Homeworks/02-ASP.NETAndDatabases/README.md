## PROBLEM DESCRIPTION - ASP.NET and Databases



In this workshop we will create a simple ForumApp, similar to the ShoppingListApp from the slides from the previous session. Our app will have a page for displaying all added forum posts with their content and with [Edit] and [Delete] buttons and an [Add Post] button. It also should display a form for adding a post and editing a post and it should ask for a confirmation when deleting a post. It will look like this:

![изображение](https://user-images.githubusercontent.com/82647282/209888445-d4e6b23a-3984-4e2b-97cd-0d219389bacd.png)

![изображение](https://user-images.githubusercontent.com/82647282/209888448-efffa7d5-91f5-4685-a828-d8edb2eed6c7.png)

### 1.	Define Entities

We should start with creating the data model, which we will need for our database. We will have only one data model class – Post.

Create the Post class in the "Data" folder of the project. It's a good practice for the data model classes to be in a separate folder from the ForumDbContext class – the "Entities folder". 

![изображение](https://user-images.githubusercontent.com/82647282/209889395-f17d0891-80e5-4e88-a805-33e4c01342ba.png)

The Post class should have the following properties:

  +	Id – an unique integer, primary key
  +	Title – a string with min length 10 and max length 50 (required)
  +	Content – a string with min length 30 and max length 1500 (required)

Create the Post class in the "Entities" folder with its properties without restrictions:

![изображение](https://user-images.githubusercontent.com/82647282/209889422-aae427ce-6536-4d12-ba35-4c3fae2b9c6d.png)

Note that we use init setters only for properties, which won't be changed after the initialization. For example, the Id property will always be the same.

Now, add the [Required] attribute to those properties, which must have a value.

![изображение](https://user-images.githubusercontent.com/82647282/209889458-b4810bb0-e984-4720-b330-e51908d0c162.png)

Note that you don't need to set the Id property as a primary key in any way – this is done by default in EF Core because of the "Id" property name. 

Now we should restrict the properties. The only restriction we will set is for the max length, as the database doesn't care about other validations. Min length, range and other restrictions are added to model classes.

The properties, which should have a max length, are Title and Content.

It is a good idea to create a separate class with constants for the max length values. In the "Data" folder, create the DataConstants class:

![изображение](https://user-images.githubusercontent.com/82647282/209889474-76a3f6b4-6294-417d-a5f3-d381f9a46de1.png)

In this class, create a Post class for the constants, connected to a post entity, and the constants themselves:

![изображение](https://user-images.githubusercontent.com/82647282/209889484-da2c9a0d-5177-43f9-ad16-297b36559c06.png)

Add the needed namespace to use the constant class in the Post class:

![изображение](https://user-images.githubusercontent.com/82647282/209889491-65e28038-c6c2-4b40-9bec-067f6c1006d6.png)

Use the constants in the [MaxLength] attribute to set the max length like this:

![изображение](https://user-images.githubusercontent.com/82647282/209889579-a38c7de7-a7a2-4bb0-b367-1b74e6ed8dd0.png)

### 2.	Define the DbContext

Now let's add our ForumAppDbContext class in the "Data" folder.

![изображение](https://user-images.githubusercontent.com/82647282/209889610-2b16ec3e-218c-444c-9959-b9ba50259a35.png)

We should use the Migrate() method in the constructor in order for the changes to be applied to tbe database directly.

![изображение](https://user-images.githubusercontent.com/82647282/209889621-ceddc08c-278a-4247-bc38-c3a67404bdd1.png)

Create the DbSet properties for the table in the database:

![изображение](https://user-images.githubusercontent.com/82647282/209889632-891beb7a-09ec-4da1-b5d9-a691b978ffa0.png)

Warning: EF Core uses a "cascade" delete by default when removing an entity. This means that if a record in the parent table is deleted, then the corresponding records in the child table will automatically be deleted. To prevent this from happening, it's a good practice to set the delete behavior to "restrict", so that an entity, which has connections to other entities in the database, won't be deleted. 

In our case, there's no entity that has connections to other entities If there was such entity, the OnModelCreating(ModelBuilder builer) method in the ForumAppDbContext class should be overridden:

![изображение](https://user-images.githubusercontent.com/82647282/209889650-760169c4-8758-486c-8771-313c156157e7.png)

At the end, invoke the base OnModelCreating() method:

![изображение](https://user-images.githubusercontent.com/82647282/209889660-79a5d35c-5d49-406e-86bd-08bcdafd6ad4.png)

Now our database structure is ready. If you migrate it now, however, it will be created with empty tables. For this reason, let's see how to seed some data to fill in the database tables.

### 3.	Seed the Database

Now, we want to populate the database with an initial set of data. This will include three posts.

First, create properties for the above objects in the ForumAppDbContext class:

![изображение](https://user-images.githubusercontent.com/82647282/209889687-bd3ba614-e9e2-40a6-855e-333f35830809.png)

The, we will use a separate method to add data to these objects, which will be added to the corresponding database table in the OnModelCreating(ModelBuilder builder) method. Add the following lines of code to the method, before invoking the base one:

![изображение](https://user-images.githubusercontent.com/82647282/209889703-e539d67f-af1e-4ba1-9723-6d36297018c8.png)

Let's implement the SeedPosts() method, which will create the posts for the database.

![изображение](https://user-images.githubusercontent.com/82647282/209889728-a51f56a1-3ffd-4ff9-a640-2351328a07f7.png)

Now we have a db context with seeded data and our database is ready to be migrated.

### 4.	Create a Migration

We will now create a migration to the database. 

To do that, first we need to add the connection string in the "appsettings.json" file:

![изображение](https://user-images.githubusercontent.com/82647282/209889739-9db7e5c8-2175-4bdf-936b-cb3c70c18a87.png)

 and set the DbContext to use SQL with the connection string in the Program class.
 
 ![изображение](https://user-images.githubusercontent.com/82647282/209889749-07e2a84a-dcc8-4079-8c0d-168e31817e34.png)

Next, open the Package Manager Console from [Tools] -> [NuGet Package Manager] -> [Package Manager Console] to write commands for managing migrations:

![изображение](https://user-images.githubusercontent.com/82647282/209889759-2a693c5f-7a00-4eac-be88-58acfd3f7025.png)

In the console, write a command for adding a migration to the "Data/Migrations" folder with a given name and press [Enter] to execute it. The result should be the following:

![изображение](https://user-images.githubusercontent.com/82647282/209889765-5202415b-cbb1-47c7-bc74-fb727bf4335b.png)

Now you should have a new migration in the "Migrations" folder:

![изображение](https://user-images.githubusercontent.com/82647282/209889774-d9101bfd-f561-4b14-8c95-8fb9a081a2b4.png)

![изображение](https://user-images.githubusercontent.com/82647282/209889780-7e01c495-5418-4fa6-acef-2c40ad3a5784.png)

Examine the tables and its restrictions in the new migration – if something is wrong, delete the migration with the "Remove-Migration" command or delete the migration file. Don't forget that you should also delete the database from SQL Server Management Studio, or errors will appear.

Now run the app in the browser – there should not be any errors. Then, look at the newly-created database in SQL Server Management Studio and examine the table – it should be present and have the right restrictions and relationships:

![изображение](https://user-images.githubusercontent.com/82647282/209889795-47e08086-9060-4e78-b017-47f66d4d1d79.png)

Look at the "Posts" table – it should contain the three posts that we seeded:

![изображение](https://user-images.githubusercontent.com/82647282/209889810-d85b9567-9442-4732-b09d-5b2b4a737de7.png)

### 5.	CRUD operations

After we have populated our database, we can start executing CRUD operations.  

#### Reading Data

First, we need to create a new PostsController in the "Controllers" folder".

![изображение](https://user-images.githubusercontent.com/82647282/209889828-b35e7069-f5dc-4166-b29d-bd82149778e7.png)

Let's inject the ForumAppDbContext through the constructor and assign it to a variable to use it:

![изображение](https://user-images.githubusercontent.com/82647282/209889837-e60ae16b-7944-4b25-aa49-4d2e8a6353fb.png)

Our next step should be creating the PostViewModel in the "Models" folder.

![изображение](https://user-images.githubusercontent.com/82647282/209889846-1208a8b2-aaf4-41f6-8fc7-8655cbba223a.png)

After the PostViewModel is created, we'll go back to the PostsController and add a new method All(). The task of this method is to extract the products from the database to a model collection, which will be passed to a view.

![изображение](https://user-images.githubusercontent.com/82647282/209889856-0882b392-7512-4e63-9ad9-0a7f04b92ce2.png)

Now we should create the "All.csthml" view file. We will create all of the views in a new folder, called "Posts", which will be located in the "Views" folder.

![изображение](https://user-images.githubusercontent.com/82647282/209889872-7abe6057-e651-4a10-8c34-27187c726fb8.png)

![изображение](https://user-images.githubusercontent.com/82647282/209889879-07476e93-c86f-42e6-9523-2e33b55995d9.png)

Now run the app in the browser – there should not be any errors and the Home page should be displayed:

![изображение](https://user-images.githubusercontent.com/82647282/209889906-b4551f2e-e2f1-4c93-abc3-05db0a330ad2.png)

You can access the page that contains the collection with the posts on "/Posts/All". For our convenience, we will add a link to the navigation pane to access the Posts page. The navigation pane should look like this:
 
![изображение](https://user-images.githubusercontent.com/82647282/209889923-e685c754-474a-486f-976c-3989d0b4c79d.png)

To add links, go the _Layout.cshtml partial view in the "/Views/Shared" folder, as this view is responsible for the common design of all pages. Add the following lines:

![изображение](https://user-images.githubusercontent.com/82647282/209889956-18fcfeb9-06ad-450b-87ae-7414164e4111.png)

If we follow the newly added link, we should be able to see the Posts page and it should look like this:

![изображение](https://user-images.githubusercontent.com/82647282/209889982-3eb1ff1c-625b-471e-918a-7afce157c2a6.png)

#### Creating New Data

The next step in creating the ForumApp is adding the "Add Post" page. It will display a form for adding a post and it will look like this:

![изображение](https://user-images.githubusercontent.com/82647282/209889994-1c394b4d-37b2-4435-8228-e0bec1052a9d.png)

First, we need to create the PostViewModel in the "Models" folder. We will add validation attributes to the model property. The [Required] attribute will check if the model property holds any value and the [StringLength] will check the length of the string that is held as a value.

![изображение](https://user-images.githubusercontent.com/82647282/209890001-f09629fb-4492-49b0-8fe0-40b3c6ab22b3.png)

After we have created the PostViewModel we should go to the PostsController and implement the Add() method. This method will create a new Post object and then add it to the DbSet.

![изображение](https://user-images.githubusercontent.com/82647282/209890010-732d99f5-9e96-4b5b-a931-09a04831f726.png)

Finally, we have to add a new "Add.cshtml" in the "/Views/Posts" folder for the "Add Product" Page view:

![изображение](https://user-images.githubusercontent.com/82647282/209890027-91dc338d-03fc-441d-9522-2442d0ad2ad3.png)

The file should look like this:

![изображение](https://user-images.githubusercontent.com/82647282/209890046-923a76d0-34b6-4cf3-b1e7-72b35827e28d.png)

Let's not forget to add the following code in the Add.cshtml file in order for the app to be able to validate the input data.

![изображение](https://user-images.githubusercontent.com/82647282/209890056-4c9fe4ef-c61f-4ae9-a55d-3b48efee9a27.png)

Now we can run the app in the browser and add a new post. After adding the new post, the All Posts page should look like this:

![изображение](https://user-images.githubusercontent.com/82647282/209890064-5002efc1-d1b8-4a0c-a3b0-5a916851cc17.png)

Now let's check the database in SQL Server Management Studio and examine the "Posts" table – it should contain the new post that we just created:

![изображение](https://user-images.githubusercontent.com/82647282/209890090-a40cb567-4d02-4603-9434-2e47a3ee7397.png)

We can check if the app validates the title and content, which we want to add for our post. If their length doesn't meet the requirements, the app should look like this:

![изображение](https://user-images.githubusercontent.com/82647282/209890116-fe91ac97-4357-4d95-9342-abecd47dde58.png)

#### Updating Existing Data

The next step in creating the ForumApp is adding the "Edit Post" page. It will display a form for editing a post and it will look like this:

![изображение](https://user-images.githubusercontent.com/82647282/209890124-fded5d93-8c53-4d06-a00d-6c16166b01a9.png)

Now let's edit one of the posts that we already have in the collection. First, we need to modify the PostsController and add an Edit() method, which will pass a Post model to the view and find and update the post in the database.

![изображение](https://user-images.githubusercontent.com/82647282/209890135-98c64d60-b522-476f-90e7-e36a2e4767c4.png)

Our next step is to add a new "Edit.cshtml" file to display the form for editing posts.

![изображение](https://user-images.githubusercontent.com/82647282/209890142-d87c604e-d4ba-40af-a4be-bcfa7adc5743.png)

Let's not forget that we have to add validation for the length of the post's title and content.

![изображение](https://user-images.githubusercontent.com/82647282/209890157-c5812903-357a-471e-b6f9-de09eb3fa315.png)

#### Deleting Existing Data

The final step in creating our ForumApp is adding the functionality to perform a Delete operation. This means that when we click on the [Delete] button of a post, it has to send a POST reques to the controller. It's a good practice to add a client-side delete confirmation, so we will do that, too.

In order to do that, we need to add a new method Delete() in the PostsController:

![изображение](https://user-images.githubusercontent.com/82647282/209890178-00bab87d-be5a-430c-bc73-cdd54d950452.png)

Next, we need to go to the "All.cshtml" file and add the following code:

![изображение](https://user-images.githubusercontent.com/82647282/209890191-7928c5c8-4953-45f6-9a2c-fa99403fa788.png)

The onclick attribute of the [Delete] button enables the JavaScript confirm() function, which displays the confirmation dialog to the user. If the [Cancel] button is clicked, the confirm() function returns false and nothing happens. If the [OK] button is clicked, the form is submitted and the post is deleted from the database.

![изображение](https://user-images.githubusercontent.com/82647282/209890204-3f744ed1-8445-4fc8-849f-8b5296ae9170.png)