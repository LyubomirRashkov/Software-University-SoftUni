## PROBLEMS DESCRIPTION


### Problem 1. The Pianist

On the first line of the standard input, you will receive an integer n – the number of pieces you will initially have. On the next n lines, the pieces themselves will follow with their composer and key, separated by "|" in the following format: "{piece}|{composer}|{key}".

Then, you will be receiving different commands, each on a new line, separated by "|", until the "Stop" command is given:
  
  +	"Add|{piece}|{composer}|{key}":
    +	You need to add the given piece with the information about it to the other pieces and print: "{piece} by {composer} in {key} added to the collection!"
    +	If the piece is already in the collection, print: "{piece} is already in the collection!"
  +	"Remove|{piece}":
    +	If the piece is in the collection, remove it and print: "Successfully removed {piece}!"
    +	Otherwise, print: "Invalid operation! {piece} does not exist in the collection."
  +	"ChangeKey|{piece}|{new key}":
    +	If the piece is in the collection, change its key with the given one and print: "Changed the key of {piece} to {new key}!"
    +	Otherwise, print: "Invalid operation! {piece} does not exist in the collection."

Upon receiving the "Stop" command, you need to print all pieces in your collection in the following format: "{Piece} -> Composer: {composer}, Key: {key}"

Input/Constraints

  +	You will receive a single integer at first – the initial number of pieces in the collection
  +	For each piece, you will receive a single line of text with information about it.
  +	Then you will receive multiple commands in the way described above until the command "Stop".

Examples

| Input | Output |
| --- | --- |
| [ <br> &ensp; '3', <br> &ensp; 'Fur Elise\|Beethoven\|A Minor', <br> &ensp; 'Moonlight Sonata\|Beethoven\|C# Minor', <br> &ensp; 'Clair de Lune\|Debussy\|C# Minor', <br> &ensp; 'Add\|Sonata No.2\|Chopin\|B Minor', <br> &ensp; 'Add\|Hungarian Rhapsody No.2\|Liszt\|C# Minor', <br> &ensp; 'Add\|Fur Elise\|Beethoven\|C# Minor', <br> &ensp; 'Remove\|Clair de Lune', <br> &ensp; 'ChangeKey\|Moonlight Sonata\|C# Major', <br> &ensp; 'Stop' <br> ] | Sonata No.2 by Chopin in B Minor added to the collection! <br> Hungarian Rhapsody No.2 by Liszt in C# Minor added to the collection! <br> Fur Elise is already in the collection! <br> Successfully removed Clair de Lune! <br> Changed the key of Moonlight Sonata to C# Major! <br> Fur Elise -> Composer: Beethoven, Key: A Minor <br> Moonlight Sonata -> Composer: Beethoven, Key: C# Major <br> Sonata No.2 -> Composer: Chopin, Key: B Minor <br> Hungarian Rhapsody No.2 -> Composer: Liszt, Key: C# Minor |
| [ <br> &ensp; '4', <br> &ensp; 'Eine kleine Nachtmusik\|Mozart\|G Major', <br> &ensp; 'La Campanella\|Liszt\|G# Minor', <br> &ensp; 'The Marriage of Figaro\|Mozart\|G Major', <br> &ensp; 'Hungarian Dance No.5\|Brahms\|G Minor', <br> &ensp; 'Add\|Spring\|Vivaldi\|E Major', <br> &ensp; 'Remove\|The Marriage of Figaro', <br> &ensp; 'Remove\|Turkish March', <br> &ensp; 'ChangeKey\|Spring\|C Major', <br> &ensp; 'Add\|Nocturne\|Chopin\|C# Minor', <br> &ensp; 'Stop' <br> ] | Spring by Vivaldi in E Major added to the collection! <br> Successfully removed The Marriage of Figaro! <br> Invalid operation! Turkish March does not exist in the collection. <br> Changed the key of Spring to C Major! <br> Nocturne by Chopin in C# Minor added to the collection! <br> Eine kleine Nachtmusik -> Composer: Mozart, Key: G Major <br> La Campanella -> Composer: Liszt, Key: G# Minor <br> Hungarian Dance No.5 -> Composer: Brahms, Key: G Minor <br> Spring -> Composer: Vivaldi, Key: C Major <br> Nocturne -> Composer: Chopin, Key: C# Minor |

### Problem 2. Scary Story

Use the provided skeleton to solve this problem.

Write the missing functionality of this user interface. The functionality is divided in the following steps: 

![изображение](https://user-images.githubusercontent.com/82647282/229620569-b2c9d5ee-aaa0-4c8f-9205-67e3b369c274.png)

Your Task

Write the missing JavaScript code to make the Scary Story work as expected:

All fields (First Name, Last Name, Age, Genre, Story title and Story text) are filled with the correct input
  
  +	First Name, Last Name, Age, Story title and Story text are non-empty strings. If any of them is empty, the program should not do anything.

Getting the information from the form

![изображение](https://user-images.githubusercontent.com/82647282/229620681-c1936d7f-ace1-4a7e-8a6b-cbf4d2cba6a1.png)

  +	On clicking the [“Publish”] button the information from the input fields is listed in the "preview" section. For the input fields a list item is added to the "preview-list" unordered list. 
  +	The text format and order for each list item should be the same as on the picture below.  
  +	When the button is clicked, the input fields must be cleared and the ["Publish"] button must be disabled. At the same time the "Save", "Edit" and the "Delete" buttons must be enabled. 

The HTML structure looks like this:  

![изображение](https://user-images.githubusercontent.com/82647282/229620856-8c0273cf-52af-4a97-a6ba-f41f4f151635.png)

The functionality here is the following: 

  +	When the "Edit" button is clicked, all of the information is loaded in the input fields from step 1 and all buttons in preview section are disabled while the ["Publish"] button is enabled again.

![изображение](https://user-images.githubusercontent.com/82647282/229620931-71e47a1f-518b-42fe-863c-52deb45a3bff.png)

  +	The list item must be removed from the "preview-list" and all of the information must go back to the input fields again. 
  
![изображение](https://user-images.githubusercontent.com/82647282/229620991-0b3f4676-2890-49ea-965c-3a16e9f8d055.png)

  +	When the "Save" button is clicked, the story is completed. For you, this means removing everything inside of the div with id = "main" and adding there only a \<h1\> tag. With message: "Your scary story is saved!"
  
![изображение](https://user-images.githubusercontent.com/82647282/229621121-4d1c02ab-2e6a-4ced-b1c5-d2103404d410.png)

  +	This is everything your webpage must contain at this step:
  
![изображение](https://user-images.githubusercontent.com/82647282/229621207-28e8c307-c4de-4875-b8c3-12cad7ae4494.png)

  +	When the "Delete" button is clicked, the list item must be removed from the "preview-list" and the ["Publish"] button is enabled again.
  
![изображение](https://user-images.githubusercontent.com/82647282/229621252-ace0a960-f61f-462e-bcb5-55bd98b90fae.png)

### Problem 3. To Do List

Requirements

Write a JS program that can load, create, remove and edit a list of tasks. You will be given an HTML template to which you must bind the needed functionality.

First you need to install all dependencies using the “npm install” command.

Then you can start the front-end application with the “npm start” command.

You also must also start the server.js file in the server folder using the “node server.js” command in another console (BOTH THE CLIENT AND THE SERVER MUST RUN AT THE SAME TIME).

At any point, you can open up another console and run “npm test” to test the current state of your application.

Endpoints:

  +	http://localhost:3030/jsonstore/tasks/
  +	http://localhost:3030/jsonstore/tasks/:id

Load Tasks

Clicking the [Load All] button should send a GET request to the server to fetch all tasks in your local database.

Each task is a list item in the following format:

\<li\>

&ensp; \<span\>Go Shopping\</span\>

&ensp; \<button\>Remove\</button\>

&ensp; \<button\>Edit\</button\>

\</li\>

![изображение](https://user-images.githubusercontent.com/82647282/229622077-462ba8e7-9de0-44f3-ace1-60a407e3ccee.png)

Add Task

Clicking the [Add] button should send a POST request to server, creating a new task with the name from the input value and after the successful creation you should send another GET request to fetch all tasks, including the newly added one.

![изображение](https://user-images.githubusercontent.com/82647282/229622144-6b059255-aad0-4e1a-b32d-8a3ad6324dfd.png)

Remove Task

Clicking the [Remove] button should send a DELETE request to the server and remove the item from your local database. After you’ve removed it successfully, fetch the items again.

![изображение](https://user-images.githubusercontent.com/82647282/229622206-5175b2ad-9815-49ef-b38c-f6a71ab1104a.png)

![изображение](https://user-images.githubusercontent.com/82647282/229622226-27e35502-da4f-42cc-85cc-0fb5f72c6b77.png)

Edit Task

Clicking the [Edit] button should change the DOM Structure for that list element, instead of a span you should create an input field with the current name as value and exchange the Edit button with a Submit button.

After clicking the [Submit] button you should send a PATCH request to the server to modify the name of the changed item, after the successful request you should fetch the items again and see that changes have been made.

![изображение](https://user-images.githubusercontent.com/82647282/229622375-378ca298-8568-456f-a8a1-78fddd91cc3a.png)

![изображение](https://user-images.githubusercontent.com/82647282/229622388-3f231961-36f1-4280-8ad3-64bf4aee728a.png)

![изображение](https://user-images.githubusercontent.com/82647282/229622410-dc002dbb-2903-41a8-87e4-fc31e5dc19c2.png)