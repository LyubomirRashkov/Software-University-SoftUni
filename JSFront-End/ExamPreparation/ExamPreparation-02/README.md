## PROBLEMS DESCRIPTION


### Problem 1. Shopping List

Input

You will receive an initial list with groceries separated by an exclamation mark "!".

After that, you will be receiving 4 types of commands until you receive "Go Shopping!".

  +	"Urgent {item}" - add the item at the start of the list. If the item already exists, skip this command.
  +	"Unnecessary {item}" - remove the item with the given name, only if it exists in the list. Otherwise, skip this command.
  +	"Correct {oldItem} {newItem}" - if the item with the given old name exists, change its name with the new one. Otherwise, skip this command.
  +	"Rearrange {item}" - if the grocery exists in the list, remove it from its current position and add it at the end of the list. Otherwise, skip this command.

Constraints

  +	There won't be any duplicate items in the initial list

Output

  +	Print the list with all the groceries, joined by ", ": "{firstGrocery}, {secondGrocery}, … {nthGrocery}"

Examples

| Input | Output |
| --- | --- |
| [ <br> &ensp; "Tomatoes!Potatoes!Bread", <br> &ensp; "Unnecessary Milk", <br> &ensp; "Urgent Tomatoes", <br> &ensp; "Go Shopping!" <br> ] | Tomatoes, Potatoes, Bread |
| [ <br> &ensp; "Milk!Pepper!Salt!Water!Banana", <br> &ensp; "Urgent Salt", <br> &ensp; "Unnecessary Grapes", <br> &ensp; "Correct Pepper Onion", <br> &ensp; "Rearrange Grapes", <br> &ensp; "Correct Tomatoes Potatoes", <br> &ensp; "Go Shopping!" <br> ] | Milk, Onion, Salt, Water, Banana |

### Problem 2. Music Site

Use the provided skeleton to solve this problem.

Note: You can't and you have no permission to change directly the given HTML code (index.html file).

![изображение](https://user-images.githubusercontent.com/82647282/229628243-e6ef2857-2bdb-40cb-817a-33f29cfac3c4.png)

Your Task

Write the missing JavaScript code to make the Music Site work as expected:

  +	All fields (genre, name, author, and date) are filled with the correct input
    +	Genre, name, author, and date are non-empty strings
  +	The program should not do anything if any of the input fields are empty.

![изображение](https://user-images.githubusercontent.com/82647282/229628337-0aaf5608-9043-4535-807d-f2bcd01c3ff4.png)

![изображение](https://user-images.githubusercontent.com/82647282/229628352-888c0ac6-9161-4ac1-a2ed-7013ae654a0d.png)

Getting the information about a new song

  +	When you click the ["Add"] button, the information from the input fields must be added to the div with the class "all-hits-container" and then clear input fields.    
  +	The HTML structure looks like this:

![изображение](https://user-images.githubusercontent.com/82647282/229628471-c637dbeb-e200-410b-8b4f-73bb5af11638.png)

![изображение](https://user-images.githubusercontent.com/82647282/229628500-bf39338c-0744-4c8c-bbdf-f43c9c58263d.png)

  +	When the ["Like song"] button is clicked:
    +	You need to take a value of the current number of likes inside the paragraph in the section with the id "total-likes" and increase the value by one.

![изображение](https://user-images.githubusercontent.com/82647282/229628646-d51753d9-0f97-4593-b626-ecdea359dc50.png)

  + The button ["Like song"] for the current song must then be disabled, as the user has the right to like the song only once (Once the button is disabled, its color will turn gray).
    
![изображение](https://user-images.githubusercontent.com/82647282/229628706-be520eab-5348-4f6e-b523-5c5717145cd3.png)

![изображение](https://user-images.githubusercontent.com/82647282/229628729-5d6a29d1-cb3b-4c21-8e05-3a455795aa65.png)

  +	When the ["Save song"] button is clicked, you need to move the current song in the div with class "saved-container". 
  
![изображение](https://user-images.githubusercontent.com/82647282/229628786-7c60f899-4429-4fd9-9a49-e83cb1bf619c.png)

  +	The HTML structure looks like this:
  
![изображение](https://user-images.githubusercontent.com/82647282/229628839-0d76436b-7137-488d-a4e3-7a9e94b0fc1b.png)

![изображение](https://user-images.githubusercontent.com/82647282/229628860-d0cef0ab-7e30-44dd-b8c9-5d2a4a138063.png)

  +	When you click the ["Delete"] button, the song should be removed from the current section.

Note: When deleting a song, you should not reduce the value of the current number of likes.

![изображение](https://user-images.githubusercontent.com/82647282/229628936-144b0644-10cd-4545-a99e-a04a2d4df94e.png)

  +	The HTML structure looks like this:

![изображение](https://user-images.githubusercontent.com/82647282/229629008-42ec83f0-db98-4700-b377-6cde621812ed.png)

### Problem 3. Grocery List

Requirements

Write a JS program that can load, create, remove and edit a list of products. You will be given an HTML template to which you must bind the needed functionality.

First you need to install all dependencies using the "npm install" command.

Then you can start the front-end application with the "npm start" command.

You also must also start the server.js file in the server folder using the "node server.js" command in another console (BOTH THE CLIENT AND THE SERVER MUST RUN AT THE SAME TIME).

At any point, you can open up another console and run "npm test" to test the current state of your application.

Endpoints:

  +	http://localhost:3030/jsonstore/grocery/
  +	http://localhost:3030/jsonstore/grocery/:id

Load Products

Clicking the [Load Products] button should send a GET request to the server to fetch all products in your local database.

Each task is a list item in the following format:

\<tr\>

&ensp; \<td class="name"\>{Product}\</td\>

&ensp; \<td class="count-product"\>{count}\</td\>

&ensp; \<td class="product-price"\>{price}\</td\>

&ensp; \<td class="btn"\>

&ensp; &ensp; \<button class="update"\>Update\</button\> 

&ensp; &ensp; \<button class="delete"\>Delete\</button\>

&ensp; \</td\>

\<tr\>

![изображение](https://user-images.githubusercontent.com/82647282/229630234-8a9188a3-f866-4a34-8952-c43fc445efbc.png)

Add Products

Clicking the [Add Product] button should send a POST request to server, creating a new product with the name, count and price from the input values and after the successful creation you should send another GET request to fetch all products, including the newly added one.

![изображение](https://user-images.githubusercontent.com/82647282/229630287-de08931c-b0d7-4a83-967b-36f8a25d8a44.png)

![изображение](https://user-images.githubusercontent.com/82647282/229630309-416f68b8-96a4-4b9c-b79c-024330fb6286.png)

Delete Products

Clicking the [Delete] button should send a DELETE request to the server and remove the item from your local database. After you’ve removed it successfully, fetch the items again.

Update Products

Clicking the [Update] button should change the DOM Structure for that list element. [Update Product] button must be activate. 

After clicking the [Update Product] button you should send a PATCH request to the server to modify the name, count or price of the changed item, after the successful request you should fetch the items again and see that changes have been made.

![изображение](https://user-images.githubusercontent.com/82647282/229630391-c6ca5f0e-4260-4f2f-8ece-d89b4688b909.png)

![изображение](https://user-images.githubusercontent.com/82647282/229630407-abaa5023-2fdd-4fd4-bd58-8bdd81cfcc54.png)