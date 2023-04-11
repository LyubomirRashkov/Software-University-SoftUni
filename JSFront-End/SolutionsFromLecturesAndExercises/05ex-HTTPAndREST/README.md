## PROBLEMS DESCRIPTION - HTTP AND REST (Exercise)


### Requirements

For each task you need to install all dependencies using the “npm install” command.

Then you can start the front-end application with the “npm start” command.

You also must also start the server.js file in the server folder using the “node server.js” command in another console (BOTH THE CLIENT AND THE SERVER MUST RUN AT THE SAME TIME).

At any point, you can open up another console and run “npm test” inside the tests subfolder for the problem to test the current state of your application.

### Problem 1.	Bus Stop

Write a JS program that displays arrival times for all buses by a given bus stop ID when a button is clicked. Use the skeleton from the provided resources.

When the button with ID 'submit' is clicked, the name of the bus stop appears and the list bellow gets filled with all the buses that are expected and their time of arrival. Take the value of the input field with id 'stopId'. Submit a GET request to http://localhost:3030/jsonstore/bus/businfo/:busId and parse the response. 

You will receive a JSON object in the format:

stopId: {

&ensp; name: stopName,

&ensp; buses: { busId: time, … }

}

Place the name property as text inside the div with ID 'stopName' and each bus as a list item with text: "Bus {busId} arrives in {time} minutes".

If the request is not successful, or the information is not in the expected format, display "Error" as stopName and nothing in the list. The list should be cleared before every request is sent.

Note: The service will respond with valid data to IDs 1287, 1308, 1327 and 2334.

Examples

![изображение](https://user-images.githubusercontent.com/82647282/229609501-9d57f2ec-61aa-44c1-9622-017352cf9431.png)

![изображение](https://user-images.githubusercontent.com/82647282/229609524-1d515fb6-310f-4506-aa08-c5e80e27573d.png)

When the button is clicked, the results are displayed in the corresponding elements:

![изображение](https://user-images.githubusercontent.com/82647282/229609574-a2d193d6-2844-4beb-bada-9d9c7cd3f015.png)

![изображение](https://user-images.githubusercontent.com/82647282/229609599-9ee8c5bf-6e92-45c8-8d00-a9a8e2591dd5.png)

If an error occurs, the stop name changes to Error:

![изображение](https://user-images.githubusercontent.com/82647282/229609637-1af8d823-2191-4d57-9ea8-6b3a9be040be.png)

![изображение](https://user-images.githubusercontent.com/82647282/229609656-89f85494-a82a-45c0-92f3-83cd46dac50e.png)

### Problem 2.	Bus Schedule

Write a JS program that tracks the progress of a bus on it’s route and announces it inside an info box. The program should display which is the upcoming stop and once the bus arrives, to request from the server the name of the next one. Use the skeleton from the provided resources.

The bus has two states – moving and stopped. When it is stopped, only the button “Depart” is enabled, while the info box shows the name of the current stop. 

When it is moving, only the button “Arrive” is enabled, while the info box shows the name of the upcoming stop. Initially, the info box shows "Not Connected" and the "Arrive" button is disabled. The ID of the first stop is "depot".

When the "Depart" button is clicked, make a GET request to the server with the ID of the current stop to address http://localhost:3030/jsonstore/bus/schedule/:id. 

As a response, you will receive a JSON object in the following format:

stopId {

&ensp; name: stopName,

&ensp; next: nextStopId

}

Update the info box with the information from the response, disable the “Depart” button and enable the “Arrive” button. The info box text should look like this: Next stop {stopName}

When the "Arrive" button is clicked, update the text, disable the “Arrive” button and enable the “Depart” button. The info box text should look like this: Arriving at {stopName}

Clicking the buttons successfully will cycle through the entire schedule. If invalid data is received, show "Error" inside the info box and disable both buttons.

Examples

Initially, the info box shows “Not Connected” and the arrive button is disabled.

![изображение](https://user-images.githubusercontent.com/82647282/229610213-955906a1-4f8f-4cd7-b47a-018651c23601.png)

![изображение](https://user-images.githubusercontent.com/82647282/229610234-87527e9f-02e8-4690-bab4-49b867f564d3.png)

When Depart is clicked, a request is made with the first ID. The info box is updated with the new information and the buttons are changed:

![изображение](https://user-images.githubusercontent.com/82647282/229610294-10ac2e1e-4571-4c0a-9218-35d17b164382.png)

![изображение](https://user-images.githubusercontent.com/82647282/229610320-918d474e-f242-4870-b4d4-95bca58f7e2c.png)

Clicking Arrive, changes the info box and swaps the buttons. This allows Depart to be clicked again, which makes a new request and updates the information:

![изображение](https://user-images.githubusercontent.com/82647282/229610397-2c2901d2-ef8f-4df9-9eb8-b0c49d69c231.png)

![изображение](https://user-images.githubusercontent.com/82647282/229610416-68ae7860-f860-4a00-937e-1a09f10b9b46.png)

### Problem 3.	Forecaster

Write a program that requests a weather report from a server and displays it to the user. Use the skeleton from the provided resources.

When the user writes the name of a location and clicks “Get Weather”, make a GET request to the server at address http://localhost:3030/jsonstore/forecaster/locations. 

The response will be an array of objects, with the following structure:

{ 

&ensp; name: locationName,

&ensp; code: locationCode

}

Find the object, corresponding to the name that the user submitted in the input field with ID "location" and use its code value to make two more GET requests:

  +	For current conditions, make a request to: http://localhost:3030/jsonstore/forecaster/today/:code

The response from the server will be an object with the following structure:

{ 

&ensp; name: locationName,

&ensp; forecast: { low: temp, high: temp, condition: condition } 

}

  +	For a 3-day forecast, make a request to: http://localhost:3030/jsonstore/forecaster/upcoming/:code

The response from the server will be an object with the following structure:

{ 

&ensp; name: locationName,

&ensp; forecast: [{ low: temp, high: temp, condition: condition }, … ] 

}

Use the information from these two objects to compose a forecast in HTML and insert it inside the page. Note that the \<div\> with ID "forecast" must be set to visible. See the examples for details. 

If an error occurs (the server doesn’t respond or the location name cannot be found) or the data is not in the correct format, display "Error" in the forecast section.

Use the following codes for weather symbols:

  +	Sunny -> \&#x2600; // ☀
  +	Partly sunny -> \&#x26C5; // ⛅
  +	Overcast -> \&#x2601; // ☁
  +	Rain -> \&#x2614; // ☂
  +	Degrees -> \&#176; // °

Examples

When the app starts, the forecast div is hidden. When the user enters a name and clicks on the button Get Weather, the requests being.

![изображение](https://user-images.githubusercontent.com/82647282/229611703-3383a878-52df-4da4-998f-ea13a70222e7.png)

![изображение](https://user-images.githubusercontent.com/82647282/229611724-cc64b702-28a3-40e5-a7bb-e848199144cb.png)

![изображение](https://user-images.githubusercontent.com/82647282/229611743-e9da255c-aa32-473f-8820-e382eaf25462.png)

![изображение](https://user-images.githubusercontent.com/82647282/229611771-50025e1d-adb0-4fdb-a5f9-f58b440946d9.png)

### Problem 4.	Blog

Write a program for reading blog content. It needs to make requests to the server and display all blog posts and their comments.

Request URL’s:

  + Posts - http://localhost:3030/jsonstore/blog/posts
  + Comments - http://localhost:3030/jsonstore/blog/comments

Examples

The button with ID "btnLoadPosts" should make a GET request to "/posts". The response from the server will be an Object of objects.

![изображение](https://user-images.githubusercontent.com/82647282/229611991-f249a820-0c95-4c38-90e2-11c108557f79.png)

Each object will be in the following format:

{

&ensp; body: {postBody},

&ensp; id: {postId},

&ensp; title: {postTitle} 

}

Create an \<option\> for each post using its object key as value and current object title property as text inside the node with ID "posts".

![изображение](https://user-images.githubusercontent.com/82647282/229612148-b7ab88b0-fa07-4c58-a741-f53515aeb138.png)

![изображение](https://user-images.githubusercontent.com/82647282/229612168-aac1c773-4dc4-41d8-9bc2-3d10f77f7cad.png)

When the button with ID "btnViewPost" is clicked, a GET request should be made to:

  +	“/comments“ - to obtain all comments. The request will return a Object of objects.

![изображение](https://user-images.githubusercontent.com/82647282/229612229-8ee2003f-9465-4f7a-a7a0-3077f69ec9a6.png)

Each object will be in the following format: 

{ 

&ensp; id: {commentId},

&ensp; postId: {postId},

&ensp; text: {commentText}

}

You must find this comments that are for the current post (check the postId property).

Display the post title inside h1 with ID "post-title" and the post content inside p with ID "post-body". Display each comment as a \<li\> inside ul with ID "post-comments". Do not forget to clear its content beforehand.

![изображение](https://user-images.githubusercontent.com/82647282/229612362-92888dc5-dce5-4903-b104-5736971f847e.png)

![изображение](https://user-images.githubusercontent.com/82647282/229612374-9739e614-b72b-439c-80bf-57c5040c8d27.png)

### Problem 5.	Messenger

Write a JS program that records and displays messages. The user can post a message, supplying a name and content and retrieve all currently recorded messages.

The url for the requests - http://localhost:3030/jsonstore/messenger

When [Send] button is clicked you should create a new object and send a post request to the given url. 

Use the following message structure:

{

&ensp; author: authorName,

&ensp; content: msgText,

}

If you click over [Refresh] button you should get all messages with GET request and display them into the textarea. 

Use the following message format: "{author}: {message}"

Examples

![изображение](https://user-images.githubusercontent.com/82647282/229612647-2b28f953-198f-433c-aef7-e3ee6e572b95.png)

![изображение](https://user-images.githubusercontent.com/82647282/229612665-9e38331c-00ef-49fe-8ded-5507b4960355.png)

### Problem 6.	Phonebook

Write a JS program that can load, create and delete entries from a Phonebook. You will be given an HTML template to which you must bind the needed functionality.

When the [Load] button is clicked, a GET request should be made to the server to get all phonebook entries. Each  received entry should be in a li inside the ul with id="phonebook" in the following format with text "\<person\>: \<phone\> " and a [Delete] button attached. Pressing the [Delete] button should send a DELETE request to the server and delete the entry. The received response will be an object in the following format: {\<key\>:{person:\<person\>, phone:\<phone\>}, \<key2\>:{person:\<person2\>, phone:\<phone2\>,…} where \<key\> is an unique key given by the server and \<person\> and \<phone\> are the actual values.

When the [Create] button is clicked, a new POST request should be made to the server with the information from the Person and Phone textboxes, the Person and Phone textboxes should be cleared and the Phonebook should be automatically reloaded (like if the [Load] button was pressed).

The data sent on a POST request should be a valid JSON object, containing properties person and phone. Example format: 

{

&ensp; "person": "<person>",

&ensp; "phone": "<phone>"

}

The url’s to which your program should make requests are:
  +	GET and POST requests should go to http://localhost:3030/jsonstore/phonebook
  +	DELETE requests should go to http://localhost:3030/jsonstore/phonebook/:key , where :key is the unique key of the entry (you can find out the key from the key property in the GET request)

Screenshots

![изображение](https://user-images.githubusercontent.com/82647282/229613155-5faf44ed-ccd4-41ce-a87b-08b145bfe2d4.png)

![изображение](https://user-images.githubusercontent.com/82647282/229613174-70ccc0b2-cfec-4926-a917-0d6b1c29f4dc.png)

### Problem 7.	Students

Your task is to implement functionality for creating and listing students from a database. Create a new collection called "students", 

Each student has:
  +	firstName - string, non-empty
  +	lastName - string, non-empty
  +	facultyNumber - string of numbers, non-empty
  +	grade - number, non-empty

You need to write functionality for creating students. When creating a new student, make sure you name the properties accordingly.

You will also need to extract students. You will be given an HTML template with a table in it. Create an AJAX request that extracts all the students.

URL for this task: http://localhost:3030/jsonstore/collections/students

Screenshots

![изображение](https://user-images.githubusercontent.com/82647282/229613380-90a97552-ecbb-4813-a437-7c0da0a18bb9.png)

### Problem 8.	Book Library

First task is to "GET" all books. To consume the request with POSTMAN your url should be the following: http://localhost:3030/jsonstore/collections/books

Using the provided skeleton, write the missing functionalities.

Load all books by clicking the button "LOAD ALL BOOKS"

![изображение](https://user-images.githubusercontent.com/82647282/229613506-10a75a05-85b3-4035-a989-cecc00fc1e0b.png)

Get Book 

This functionality is not needed in this task, but you can try it with postman by sending request to "GET" the Book with id:" d953e5fb-a585-4d6b-92d3-ee90697398a0". Send a GET request to this URL: http://localhost:3030/jsonstore/collections/books/:id

Create Book

Write functionality to create a new book, when the submit button is clicked. Before sending the request be sure the fields are not empty (make validation of the input). To create a book, you have to send a "POST" request and the JSON body should be in the following format: 

{

&ensp; "author": "New Author",

&ensp; "title": "New Title"

}

Update Book 

By clicking the edit button of a book, change the form like this:

![изображение](https://user-images.githubusercontent.com/82647282/229613737-f1f9c046-b2f3-44a7-b28e-b4e652b30f45.png)

The HTTP command "PUT" modifies an existing HTTP resource. The URL is: http://localhost:3030/jsonstore/collections/books/:id

The JSON body should be in the following format:

{

&ensp; "author": "Changed Author",

&ensp; "title": "Changed Title"

}

Delete Book 

By clicking the delete button you have to delete the book, without any confirmation. To delete a book use "DELETE" command and send REQUEST: http://localhost:3030/jsonstore/collections/books/:id