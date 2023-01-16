## PROBLEMS DESCRIPTION - ASP.NET Core Introduction



### 1.	Create Simple Pages in an ASP.NET Core App

In this task you should implement the pages from the demo from the slides for this topic. To do so, create a new ASP.NET Core MVC app. Open Visual Studio and choose [Create a new project]. On the next step, choose [ASP.NET Core Web App (Model-View-Controller)] as a project template. The steps are shown below:

![изображение](https://user-images.githubusercontent.com/82647282/209885546-16471dc5-89d4-44b0-adfd-9e7fd44f3ee1.png)

![изображение](https://user-images.githubusercontent.com/82647282/209885554-aba081b4-ab60-40e5-be54-406d22d14980.png)

Give a name to your project and solution:

![изображение](https://user-images.githubusercontent.com/82647282/209885585-4d8d66bc-bcba-4c80-92cb-a6c645c29182.png)

On the next step you should choose your target frameworok and click on the [Create] button:

![изображение](https://user-images.githubusercontent.com/82647282/209885600-67db8254-05bd-4086-85de-41b43aebbaf7.png)

Now your app is created and looks as shown below. Note that it has folders for controllers, models and views because of the template we chose:

![изображение](https://user-images.githubusercontent.com/82647282/209885611-a416d5c4-fbc3-48ef-9282-31bda8616321.png)

If you run the app, you will see the default "Home" page, which is served by the HomeController in the app:

![изображение](https://user-images.githubusercontent.com/82647282/209885641-fb2508d8-2556-4e60-8784-7f92bcef8ad3.png)

#### HomeController Pages

#### Modify the "Home" Page

Now we want to modify the "Home" page to look like this:

![изображение](https://user-images.githubusercontent.com/82647282/209885664-4c4040ab-862f-4c05-9219-aea44440fc49.png)

Change the Index() method of the HomeController to change the page. The controller action should return a view, as it does already, but also use the ViewBag class to create a message, which will be used in the view. Modify the method like this:

![изображение](https://user-images.githubusercontent.com/82647282/209885679-d67b4c84-a83a-4541-a8e0-9347559d88f1.png)

Now you should modify the Index.cshtml view in the "/Views/Home" folder to display the page differently. Use the ViewBag class to get the message from the controller. Note how the Razor views able us to use C# code inside HTML:

![изображение](https://user-images.githubusercontent.com/82647282/209885705-2ba13302-44b5-4aa0-b58d-d9960ddc5de6.png)

#### Create the "About" Page

Create an "About" page in the app, which should look like this:

![изображение](https://user-images.githubusercontent.com/82647282/209885728-8a99b6be-bfda-4abf-8273-c6475ea028d2.png)

The page should be accessed on "/Home/About". Create an About() controller action in the HomeController class for the "About" page. The controller method should return a view. It should also use the ViewBag class to pass a message to the returned view. Write the method like this:

![изображение](https://user-images.githubusercontent.com/82647282/209885775-90fa27d5-6600-4a4a-aaaf-b6dae933a044.png)

Now you should create an About.cshtml view in the "/Views/Home" folder. To do this, right-click on the folder and choose [Add] -> [View]:

![изображение](https://user-images.githubusercontent.com/82647282/209885950-0011038c-bbc5-4c04-902c-91529781c1df.png)

![изображение](https://user-images.githubusercontent.com/82647282/209885987-38243dab-a9ef-454d-9b22-d0cbf6c8985e.png)

Now the About.cshtml view should be created. Write it like this:

![изображение](https://user-images.githubusercontent.com/82647282/209886054-2ebad639-83ec-420a-a4fa-901ad0176d40.png)

![изображение](https://user-images.githubusercontent.com/82647282/209886085-1384e56f-6ef3-4ea5-9a80-d10e77e44d62.png)

#### Create the "Numbers 1…50" Page

The "Numbers 1…50" page should display the numbers from 1 to 50. It should be accessed on "/Home/Numbers" and shoud look like this:

![изображение](https://user-images.githubusercontent.com/82647282/209886192-8e1c82c8-7c4a-4e55-921b-7d1563b3d9d5.png)

![изображение](https://user-images.githubusercontent.com/82647282/209886197-95074dd9-249f-44e1-8a88-c32fe5693fdd.png)

Create a Numbers() controller method in the HomeController, which should only return a view:

![изображение](https://user-images.githubusercontent.com/82647282/209886209-ba8d0757-c8be-47f7-9933-4a45608bddd5.png)

Create a Numbers.cshtml view, which should use a for loop to display each number. Write the view like this:

![изображение](https://user-images.githubusercontent.com/82647282/209886228-5a765112-0eb1-4869-956d-ee558fcb13c2.png)

![изображение](https://user-images.githubusercontent.com/82647282/209886232-d9eba3fb-c53f-4f77-ac0c-9e3162efadcb.png)

#### Create the "Numbers 1…N" Page

This page is similar to the previous one but the user should enter a number N. Then, only numbers from 1 to N should be displayed:

![изображение](https://user-images.githubusercontent.com/82647282/209886254-4d0767b3-5b25-41f6-9bce-e34b41925090.png)

Write a NumbersToN() method in the HomeController. It should accept a count parameter from the view (with default value of the parameter 3). Then, it should add the count number to a ViewBag and return a view:

![изображение](https://user-images.githubusercontent.com/82647282/209886272-ec3e8ad8-02d5-48c6-9247-c13a6827e7ea.png)

Then, the NumbersToN.cshtml view should display the numbers in a for loop and should have a form for submitting a count number. The number input field should have a "name" attribute, so that its value is passed to the controller action. Do it like this:

![изображение](https://user-images.githubusercontent.com/82647282/209886280-dde30550-e4d2-4677-b826-4f7eba33d459.png)

Try out the page in the browser on "/Home/NumbersToN". It should display different numbers, depending on the count you enter in the form:

![изображение](https://user-images.githubusercontent.com/82647282/209886298-4562f80f-d4de-43be-b0b2-288968228b26.png)

#### Add Navigation Links

As we have created the pages we need, let's add links to the navigation pane to access them easier. The navigation pane should look like this:

![изображение](https://user-images.githubusercontent.com/82647282/209886328-08d9ef1e-fd9a-4171-9de6-1dfcfcdebbd6.png)

To add links, go the _Layout.cshtml partial view in the "/Views/Shared" folder, as this view is responsible for the common design of all pages. Add the following lines:

![изображение](https://user-images.githubusercontent.com/82647282/209886346-54a1c587-aeee-4dc6-9456-85d64c192f7c.png)

The asp-controller and asp-action tag helpers set the controller and action names of the page, which should be accessed.

#### ProductsController Pages

The ProductsController will have controller actions for displaying hardcoded products on pages. Create the ProductsController in the "Controllers" folder. To create a controller, right-click on the "Controllers" folder, click on [Add] -> [Controller] and choose [MVC Controller – Empty] to create an empty controller class:

![изображение](https://user-images.githubusercontent.com/82647282/209886394-0e4e119c-45eb-486f-9860-d4b33a117d2b.png)

![изображение](https://user-images.githubusercontent.com/82647282/209886404-bd5c8dda-a314-4b8e-91bf-0a97c1e969d4.png)

Set the controller name like this:

![изображение](https://user-images.githubusercontent.com/82647282/209886418-b0a809a3-f025-4fea-94eb-835a08c63168.png)

Now your controller class is created in the "Controllers" folder and inherits the Controller base class:

![изображение](https://user-images.githubusercontent.com/82647282/209886433-97ebb12d-1d90-45ef-b966-b631f8035b53.png)

![изображение](https://user-images.githubusercontent.com/82647282/209886438-8f99c90d-ae4a-4442-b207-3aeb5f7027fd.png)

We will display hardcoded products. First, you should create a model for these products, which should have an id, name and price. Create a ProductViewModel class in the "Models" folder with the following properties:

![изображение](https://user-images.githubusercontent.com/82647282/209886452-8d471dd8-436c-4a5c-9e4f-75fbe20592bf.png)

Now go back to the ProductsController and add a field with products. The field should have a collection of ProductViewModel with three products like this:

![изображение](https://user-images.githubusercontent.com/82647282/209886463-c980e655-2a57-4b6e-b0e7-1c0b126d653d.png)

Now use these products in controller methods.

#### Create the "All Products" Page

![изображение](https://user-images.githubusercontent.com/82647282/209886482-03a511ba-db8a-4a6e-8824-cc071d921bc8.png)

Create an All() controller method in the ProductsController, which should only return a view with the products collection:

![изображение](https://user-images.githubusercontent.com/82647282/209886492-62ed5011-8650-462d-b0be-b10152d27058.png)

Now you should create a "Products" folder in the "Views" folder, which will have all views for the ProductsController methods. In it, add an All.cshtml view, which should accept a collection of ProductViewModel. Then, foreach the products and use the model properties to display the product data like this:

![изображение](https://user-images.githubusercontent.com/82647282/209886510-339f79d9-cdf5-4e0a-9862-5595eca5ad93.png)

#### Create the "Product By Id" Page

![изображение](https://user-images.githubusercontent.com/82647282/209886531-63bae953-c070-4193-aa70-4010a0a875c0.png)

Write the ById(int id) method in the ProductsController. It should pass a product by a given id to the view, if it exists. If it does not, it should return a BadRequest:

![изображение](https://user-images.githubusercontent.com/82647282/209886544-155d8353-7dcd-45dd-a2ec-dbc1d6d98565.png)

The ById.cshtml view is the following:

![изображение](https://user-images.githubusercontent.com/82647282/209886556-0e1d8d6a-ac31-43c4-a404-50cc6652b73b.png)

Go to the "Page By Id" page on "/Products/ById/{id}" with a valid and an invalid product id.

#### Return Products as JSON

Our task now is to return the products in a JSON format when the user accesses "/Products/AllAsJson":

![изображение](https://user-images.githubusercontent.com/82647282/209886578-fe59f502-7675-422d-982c-f2c29fdfe796.png)

Create the AllAsJson() method in the ProductsController, which should return a JSON with the products as shown below. It should use JSON options to display the JSON indented:

![изображение](https://user-images.githubusercontent.com/82647282/209886591-50426326-8d91-4175-9bc3-dd8635381fe5.png)

#### Return Products as Plain Text

Now we should return the products as a plain text in a custom format when the user accesses "/Products/AllAsText":

![изображение](https://user-images.githubusercontent.com/82647282/209886612-998c144d-9860-4191-92e3-c7049b426986.png)

The AllAsText() method in the ProductsController should create a string of all products and return it as a plain text response:

![изображение](https://user-images.githubusercontent.com/82647282/209886627-4848db78-0042-4e19-8b55-1fb36db2a2fd.png)

#### Download Products As Text File

Now we want to download a text file with the products by accessing "/Products/AllAsTextFile":

![изображение](https://user-images.githubusercontent.com/82647282/209886638-4a4821ea-0160-4faa-b16a-e141a8e4b29c.png)

![изображение](https://user-images.githubusercontent.com/82647282/209886649-5fb56327-1d8b-4509-8ab4-22241a4c94c5.png)

The AllAsTextFile() method in the ProductsController should form a text with the products. Then, it should add the Content-Disposition header to the Response, so that the file is downloaded as an attachment. At the end, it should return a file with the text as a byte array and the plain text type. Write it like this:

![изображение](https://user-images.githubusercontent.com/82647282/209886672-557a2973-17e9-4f68-95c1-cb8f8498681b.png)

#### Access the "All Products" Page on Another URL

Now our task is to make the "All Products" page accessible on "/Products/My-Products":

![изображение](https://user-images.githubusercontent.com/82647282/209886692-5d6ae847-ec11-4103-b771-fe975384333b.png)

To do this, add the [Action Name] attribute over the All() method of the ProductsController. In this way, you will set an action name, different from the real one:

![изображение](https://user-images.githubusercontent.com/82647282/209886699-821d7cd5-f9d3-4292-b04b-91e1156830a5.png)

You should also change the All.cshtml view name to "My-Products.cshtml", as the view and the controller action should have the same names:

![изображение](https://user-images.githubusercontent.com/82647282/209886712-936df46c-c98d-4bf0-b152-a533bda9890f.png)

#### Add Search to the "All Products" Page

Finally, we want to modify the "All Products" page to use a keyword in the URL to filter the displayed products like this:

![изображение](https://user-images.githubusercontent.com/82647282/209886737-07ec8915-262f-4f74-8638-affe39756d06.png)

To do this, make the All() controller action accept a keyword and return only the filtered products, when there is a keyword in the URL:

![изображение](https://user-images.githubusercontent.com/82647282/209886750-9bfdb74a-52de-4aa1-bedd-c8ad920bc30d.png)

Enter different keywords on "/Products/My-Products?keyword={keyword}" in the browser and make sure that only products with the keyword in their name are shown.

#### Add Navigation Links

![изображение](https://user-images.githubusercontent.com/82647282/209886774-6cf793a4-b50f-4ef6-937e-42a6b16d2cec.png)

Modify the _Layout.cshtml view like this to have the above links:

![изображение](https://user-images.githubusercontent.com/82647282/209886790-3d84a45e-0c95-42da-ad0c-879e7ea710fa.png)

### 2.	Simple Chat ASP.NET Core MVC App

We will begin this exercise by creating a simple ASP.NET Core MVC app called "ChatApp". Our app will have a page for displaying and adding chat messages. It will look like this:

![изображение](https://user-images.githubusercontent.com/82647282/209886809-55d81c05-22eb-43fc-bc2e-7c7e9bd887b8.png)

#### Create the Project

First, create the app and name it "ChatApp":

![изображение](https://user-images.githubusercontent.com/82647282/209886822-f8c6675a-a93c-4fd4-a0d2-715a264382ff.png)

The workflow of the chat functionality in the app will be the following:

  +	A controller action passes the current messages (if any) to a view as a model
  +	The view displays the messages (if they exist). Also, the view displays a form for creating a new message and passes a model to the controller when the form is submitted
  +	Another controller action accepts the model and adds a new message with the model data to the other messages
  +	The second method invokes the first one by redirection, which again passes all messages to the view (including the new one)

#### Create Controller and Models

Create a ChatController controller class in the "Controllers" folder:

![изображение](https://user-images.githubusercontent.com/82647282/209886865-2a9255a0-127b-429a-b228-0956439e98e6.png)

![изображение](https://user-images.githubusercontent.com/82647282/209886868-1d4a247d-baf2-4b57-b377-90f5e80b0855.png)

Delete the Index() method, as we will create our own actions. The ChatController should have:

  +	A collection of messages, which has the message sender as key and the message text as value
  +	A "GET" method Show(), which returns a view with model (the model may hold the messages)
  +	A "POST" method Send(), which accepts a model from the view and adds a message to the collection. Then, it redirects to the Show() action.

Write the above class field and properties:

![изображение](https://user-images.githubusercontent.com/82647282/209886882-321050ff-9495-4f5f-87b3-361b89fe75ce.png)

Warning: the above code holds the shared app data in a static field in the controller class. This is just for the example, and it is generally a bad practice! Use a database or other persistent storage to hold data, which should survive between the app requests and should be shared between all app users.

Note that the message collection is of type List<KeyValuePair<string, string>>, not Dictionary<string, string>, as it does not allow duplicate keys, but we may want to have several messages by the same sender.

Before we implement the Show() method of the ChatController, create the needed models, which will be passed to the view. In the "/Models" folder, create a MessageViewModel class (this is an ordinary class), which will hold properties for each message (message sender and text):

![изображение](https://user-images.githubusercontent.com/82647282/209886938-826099df-2da6-4fea-a1e1-0dd1d7ec6c4d.png)

![изображение](https://user-images.githubusercontent.com/82647282/209886942-9bdf4496-0734-4a91-b7ba-c90ef10bf723.png)

Then, create the ChatViewModel, which will be passed to the view and then returned to the controller. Write the ChatViewModel class like this:

![изображение](https://user-images.githubusercontent.com/82647282/209886964-b85ba4dd-3461-4f29-b314-376373b2b1e2.png)

The Messages property has a collection of messages (the already created messages), which will be passed to and displayed by the view. Then, the user will submit a form for creating a new message, which will be saved to the CurrentMessage property and passed to the controller.

Now go to the ChatController and implement the above logic. Write the Show() method first. If the messages collection of the class is empty, the controller action should return a view with an empty ChatViewModel. If there are messages, a view with a ChatViewModel should be returned. This time, however, the Messages collection of the ChatViewModel should have the messages as a collection of type MessageViewModel.

Implement the action like this:

![изображение](https://user-images.githubusercontent.com/82647282/209886988-f5a512bb-24ab-43c0-838d-61431ae9f50f.png)

Now write the Send() method, as well. It should have the [HttpPost] attribute, which means that the action will be invoked on a "POST" request to "/Chat/Send". The method should also accept a ChatViewModel (from the view) and use its CurrentMessage property values to add a new message to the message collection. Finally, it should redirect to the Show() action. Do it like this:

![изображение](https://user-images.githubusercontent.com/82647282/209887006-7b182914-5f91-489c-9f71-a038c2772026.png)

#### Create a View

Finally, we should create a Show.cshtml view. First, create a new folder "Chat" (the name of the controller) in the "/Views" folder:

![изображение](https://user-images.githubusercontent.com/82647282/209887030-d5effffe-7fdc-43f2-b4f5-1133b2e6bb66.png)

In it, create a Show.cshtml view:

![изображение](https://user-images.githubusercontent.com/82647282/209887040-a2f209db-6187-42ac-b1f5-5040569327e6.png)

![изображение](https://user-images.githubusercontent.com/82647282/209887050-db364879-2669-425b-8640-06b828435b38.png)

Clear the view file and let's write our own code. First, use the @model directive to make the view accept a ChatViewModel:

![изображение](https://user-images.githubusercontent.com/82647282/209887059-796a2b4d-d942-45dc-8458-125362ecd946.png)

Add a heading to the view with a pure HTML like this:

![изображение](https://user-images.githubusercontent.com/82647282/209887069-885f29d2-5516-4902-b786-2a208a84e998.png)

Next, we want to show each message with its sender and text if the ChatView model has any. Otherwise, we should just display the "No messages yet!" message. To do this, use an if statement and a foreach loop in the Razor view. Also, use the @ symbol to switch to C# code and use the model properties. Do it like this:

![изображение](https://user-images.githubusercontent.com/82647282/209887271-aca62378-0a8b-4f77-8344-38392cd53a5f.png)

Then, create a form, which should send a "POST" request to "/Chat/Send" and fill in the CurrentMessage property of the ChatViewModel. Use different tag helpers (will be examined during the next topics) to set the controller and action and to extract the name of a specified model property into the rendered HTML. Write the rest of the view code like this:

![изображение](https://user-images.githubusercontent.com/82647282/209887295-aa3132b9-06bd-48d4-93d3-25b0ad893faf.png)

Now if we access "/Chat/Show" we will see the Show.cshtml view.

To add a link to the page, go to the _Layout.cshtml.cshtml view in "/Views/Shared" and add the following code:

![изображение](https://user-images.githubusercontent.com/82647282/209887323-2fd78147-46bf-47d0-9471-2415cbaf9f15.png)

#### Try the App

Run the app and examine it in the browser. It should have the "Chat" navigation link, which we have just added:

![изображение](https://user-images.githubusercontent.com/82647282/209887349-a6ddecb8-84a6-403c-a0ae-b0267aab8c1b.png)

Click on the [Chat] link. You should be redirected to "/Chat/Show" and see the Show.cshtml view:

![изображение](https://user-images.githubusercontent.com/82647282/209887363-361f4810-00dd-49c6-9604-c7d1de15f89c.png)

We have no messages yet, so let's add one. Fill in the form and click on the [Send] button. The new message should be displayed on the page:

![изображение](https://user-images.githubusercontent.com/82647282/209887371-4f6c511c-c0a4-4cf1-851d-60cd92b0f06a.png)

![изображение](https://user-images.githubusercontent.com/82647282/209887380-109ddb41-964e-4c38-9621-77acda44b749.png)

Make sure that your app works correctly. Debug the code, so that you fully understand the MVC pattern. Don't forget that messages are deleted every time you close the app because they are stored in a variable – that's why we often create databases for our apps.

### 3.	Text Splitter App

We will begin this exercise by creating a simple ASP.NET Core MVC app called "TextSplitterApp". Our app will split text, entered by the user and then display the splitted words. It will look like this:

![изображение](https://user-images.githubusercontent.com/82647282/209887408-02c0797a-f13d-425c-97e3-c3de0e313742.png)

![изображение](https://user-images.githubusercontent.com/82647282/209887410-6044e8b6-67c8-4419-b320-58094d4908c0.png)

#### Create the Project

First, create the app and name it "TextSplitterApp":

![изображение](https://user-images.githubusercontent.com/82647282/209887424-d2177c26-4cb9-4fc1-94a4-e022a03f1116.png)

#### Create Controller and Models

Before implementing the methods in the HomeController, create the needed models, which will be passed to the view. In the "/Models" folder, create a TextViewModel class (this is an ordinary class), which will hold the properties.

![изображение](https://user-images.githubusercontent.com/82647282/209887442-eee06aaa-d465-4726-a9ed-5ef385031e79.png)

After we have created the TextViewModel class, it's time to modify the Index() method from the HomeController controller class to return a view and a model.

![изображение](https://user-images.githubusercontent.com/82647282/209887449-27688aab-c2c2-4c85-9aad-78e211623309.png)

Now write the Split() method, as well. It should have the [HttpPost] attribute, which means that the action will be invoked on a "POST" request to "/Split". The method should also accept a TextViewModel (from the view), then update it and pass it to the Index() method.

![изображение](https://user-images.githubusercontent.com/82647282/209887457-e65c7965-323e-4dc6-9207-db77abfb7a35.png)

#### Create a View

Now we should modify the Index.cshtml file.

We should accept a model in the view and change the ViewBag.Title to "Text Splitter"

![изображение](https://user-images.githubusercontent.com/82647282/209887477-fef379d9-8c33-4b9c-9d35-20105936dd44.png)

Now, we need to create a form, which should send a "POST" request and submit the information from the form to the Split(TextViewModel model) action of the HomeController. We will use the @ symbol to switch to C# code in order to assign input data to model properties.

![изображение](https://user-images.githubusercontent.com/82647282/209887493-bc0ac026-1435-4f46-9d0d-ee340f572dba.png)

#### Try the App

Run the app and examine it in the browser. Try splitting the sentence "Text should be split" and the result should look like this:

![изображение](https://user-images.githubusercontent.com/82647282/209887528-6b2d16ae-2167-4298-9f87-739c824b6f45.png)

![изображение](https://user-images.githubusercontent.com/82647282/209887535-42420040-93d2-48bf-980c-04aa85f29bf1.png)

#### Adding App Validations

Now, let's add some requirements:

  +	The "Text" field should
  
    +	Be required (not left empty)
    +	Have a minimum length of 2 characters
    +	Have a maximum length of 30 characters

  +	In case any validation fails, an error should be displayed. 
  
If the text field is left empty, a "The Text field is required" message should be displayed like shown below:
    
![изображение](https://user-images.githubusercontent.com/82647282/209887571-ecd441a5-071d-48f4-b6e9-8fc696b7c483.png)

In case the length of the input is shorter than the minimum length or longer than the maximum length, a "The field Text must be a string with a minimum length of 2 and maximum length of 30." should be displayed like shown below:

![изображение](https://user-images.githubusercontent.com/82647282/209887588-c229c5b4-6583-431c-aec6-5d39907c71b3.png)

First, we will add validation attributes to the model property. The [Required] attribute will check if the model property holds any value and the [StringLength] will check the length of the string that is held as a value.

![изображение](https://user-images.githubusercontent.com/82647282/209887604-fc8a9ff7-5b12-4f98-9f93-e3c0ff4dda4f.png)

We will use the following tag helper in order to generate the validation message.

![изображение](https://user-images.githubusercontent.com/82647282/209887611-ff53e5bb-0dce-4750-ae39-ae7e9ef6a285.png)

Finally, we will render a partial view, which executes the validation scripts. In order to do that, first we need to create a new _ValidationScriptsPartial.cshtml file in the "/Views/Shared" folder and write the code as shown below:

![изображение](https://user-images.githubusercontent.com/82647282/209887630-cdd90530-b0e4-4498-9968-6d05d9fe8234.png)

Add the following code to the end of the Index.cshtml file:

![изображение](https://user-images.githubusercontent.com/82647282/209887638-9cfa49a3-9001-4bf5-abea-0f824222d013.png)
