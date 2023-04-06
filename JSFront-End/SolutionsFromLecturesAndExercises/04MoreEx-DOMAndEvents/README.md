## PROBLEMS DESCRIPTION - DOM AND EVENTS (More Exercises)


### Problem 1.	Edit Element 

Create function edit() that takes three parameters.

Input/Output

The first parameter is a reference to an HTML element, the other two parameters are string–match and replacer.

You have to replace all occurrences of the match inside the text content of the given element with a replacer.

Example

![изображение](https://user-images.githubusercontent.com/82647282/229575340-5c51f5b4-c35b-4772-a02e-a2b1e1434930.png)

![изображение](https://user-images.githubusercontent.com/82647282/229575339-d5ffcc6f-1214-419f-bf01-a01fcbbb5c96.png)

### Problem 2.	Extract Parenthesis

Write a JS function that when executed, extracts all parenthesized text from a target paragraph by given element ID. The result is a string, joined by "; " (semicolon, space).

Input

Your function will receive a string parameter, representing the target element ID, from which text must be extracted. The text should be extracted from the DOM.

Output

Return a string with all matched text, separated by "; " (semicolon, space).

Example

![изображение](https://user-images.githubusercontent.com/82647282/229575552-31930eb7-60d3-4ece-aba8-924225ad7177.png)

| Sample call | Result (stored in variable text) |
| --- | --- |
| let text = extract("content"); | Bulgaria; Kazanlak; Rosa demascena Mill |

### Problem 3.	Mouse Gradient

Write a program that detects and displays how far along a gradient the user has moved their mouse. The result should be rounded down and displayed as a percentage inside the \<div\> with id "result". 

### Problem 4.	Dynamic Validation

Write a function that dynamically validates an email input field when it is changed. If the input is invalid, apply the class "error". Do not validate on every keystroke, as it is annoying for the user, consider only change events.

A valid email is considered to be in the format: \<name\>@\<domain\>.\<extension\>

Only lowercase Latin characters are allowed for any of the parts of the email. If the input is valid, clear the style.

Example

![изображение](https://user-images.githubusercontent.com/82647282/229576323-ab6586d2-a167-45d4-af92-ef39bf3002db.png)

![изображение](https://user-images.githubusercontent.com/82647282/229576343-eb732289-ecba-43f4-8618-49b26a5a850d.png)

### Problem 5.	Shopping Cart

You will be given some products that you should be able to add to your cart. Each product will have a name, picture, and price.

When the "Add" button is clicked, append the current product to the textarea in the following format: "Added {name} for {money} to the cart.\n". The price must be fixed to the second digit.

When the button "Checkout" is clicked, calculate the total money that you need to pay for the products that are currently in your cart. Append the result to the textarea in the following format: "You bought {list} for {totalPrice}.".

The list should contain only the unique products, separated by ", ". The total price should be rounded to the second decimal point.

Also, after clicking over "Checkout" and every from above is done you should disable all buttons. (You can't add products or checkout again if once the checkout button is clicked).

Example

![изображение](https://user-images.githubusercontent.com/82647282/229576670-c425829c-0eba-46c7-a226-2ed840f5c8aa.png)

### Problem 6.	Pascal or Camel Case

An HTML file is given and your task is to write a function that takes two string parameters as an input and transforms the first parameter to the type required by the second parameter.

  +	The first parameter will be the text that you need to modify depending on the second parameter. The words in it will always be separated by space.
  +	The second parameter will be either "Camel Case" or "Pascal Case". In case of different input, your output should be "Error!".

When the button is clicked the function should convert the first string to either of the cases. The output should consist of only one word - the string you have modified. Once your output is done, you should set it as HTML to the \<span\> element.

Example

| Input | Output |
| --- | --- |
| "this is an example", "Camel Case" | thisIsAnExample |
| "secOND eXamPLE", "Pascal Case" | SecondExample |
| "Invalid Input", "Another Case" | Error! |

### Problem 7.	Search in List

An HTML page holds a list of towns, a search box, and a [Search] button. Implement the search function to bold and underline the items from the list which include the text from the search box. Also, print the number of items the current search matches in the format '${matches} matches found'.

Note: It is necessary to clear the results of the previous search.

Example

![изображение](https://user-images.githubusercontent.com/82647282/229577535-bd1b387b-8861-4fcd-8157-490367cec302.png)

### Problem 8.	Hell's Kitchen

You will be given an array of strings, which represents a list of all the restaurants with their workers.

![изображение](https://user-images.githubusercontent.com/82647282/229577674-524aeb81-7a37-4729-a201-ce7fed714f10.png)

When the [Send] button is clicked:

  +	Display the best restaurant of all the added restaurants with its average salary and best salary. 
  +	If there is a restaurant in the input array that is added more than once, you need to add new workers to the old ones and update the values of the average salary and the best salary.
  +	The best restaurant is the restaurant with the highest average salary. If two restaurants have the same average salary the best restaurant is the first one added.
  +	Display all workers in the best restaurant with their salaries. The best restaurant's workers should be sorted by their salaries in descending order.

![изображение](https://user-images.githubusercontent.com/82647282/229577900-5583ef1e-98f0-4340-9db9-ac39fc16370f.png)

Input

The input will be received from the given textarea in the form of an array of strings. Each string represents a restaurant with its workers: ["Mikes - Steve 1000, Ivan 200, Paul 800", "Fleet - Maria 850, Janet 650"]

![изображение](https://user-images.githubusercontent.com/82647282/229577994-950b91bd-016e-4926-824c-ee2499da1cc5.png)

![изображение](https://user-images.githubusercontent.com/82647282/229578037-32a2438b-5532-4ba1-8ef8-370c0a6f00f1.png)

Output

  +	The output contains two strings
    + The first one is the best restaurant in the format: 'Name: {restaurant name} Average Salary: {restaurant avgSalary} Best Salary: {restaurant bestSalary}' - avgSalary and bestSalary must be formatted to the second decimal point.
    +	The second one is all the workers in that restaurant in the following format: 'Name: {worker name} With Salary: {worker salary} Name: {worker2 name} With Salary: {worker2 salary} Name: {worker3 name} With Salary: {worker3 salary}…'

Output strings must be set like text content in the following elements:

![изображение](https://user-images.githubusercontent.com/82647282/229578268-2cc930dc-a807-4364-a694-547590695561.png)

Constraints

  +	The workers will be always unique

Examples

| Input | Output |
| --- | --- |
| [ <br> &ensp; "PizzaHut - Peter 500, George 300, Mark 800", <br> &ensp; "TheLake - Bob 1300, Joe 780, Jane 660" <br> ] | Name: TheLake Average Salary: 913.33 Best Salary: 1300.00 <br> Name: Bob With Salary: 1300 Name: Joe With Salary: 780 Name: Jane With Salary: 660 |
| [ <br> &ensp; "Mikes - Steve 1000, Ivan 200, Paul 800", <br> &ensp; "Fleet - Maria 850, Janet 650" <br> ] | Name: Fleet Average Salary: 750.00 Best Salary: 850.00 <br> Name: Maria With Salary: 850 Name: Janet With Salary: 650 |

### Problem 9.	Generate Report

You will be given a web page, containing a table and output area. 

![изображение](https://user-images.githubusercontent.com/82647282/229579385-e3491419-48dc-43ee-a667-8c9e72275186.png)

When the "Generate Report" button is pressed:

  +	You must generate a JSON report from the data inside the table, by only taking the columns, which are selected.
  
Each table header has a checkbox. If the checkbox is checked, then the data from this column must be included in the report. Unchecked columns must be omitted. 

![изображение](https://user-images.githubusercontent.com/82647282/229579533-44439ade-4719-4570-95ee-590fdf5d04fd.png)

For every row (excluding the header):

  +	Create an object with properties for each of its columns.
  +	The name of each property is the name attribute of the column’s header, and the value is the text content of the cell.
  +	Store the result in an array and output it as a JSON string display it inside the \<textarea\> with id "output". See the example for details.

![изображение](https://user-images.githubusercontent.com/82647282/229579686-9bc6b525-c6a6-4d13-bd88-e8f913ca526c.png)

Input/Output

There will be input, your program must execute based on the page content. The output must be a JSON string, displayed in the \<textarea\> with id "output".

![изображение](https://user-images.githubusercontent.com/82647282/229579811-9c57f77f-d8c2-47a2-abb9-b33403442cc5.png)

Example

![изображение](https://user-images.githubusercontent.com/82647282/229579845-0e981a01-7171-43be-a624-02196d082964.png)

### Problem 10.	Number Convertor

Write a function that converts a decimal number to binary and hexadecimal.

![изображение](https://user-images.githubusercontent.com/82647282/229579939-acc8794d-afdd-4edd-94b0-da4a0fa02fb8.png)

The given number will always be in decimal format. The "From" select menu will only have a Decimal option, but the "To" select menu will have two options: Binary and Hexadecimal. 

This means that our program should have the functionality to convert decimal to binary and decimal to hexadecimal. When you convert to hexadecimal it must be upper case.

Note that the "To" select menu by default is empty. You have to insert the two options ('Binary' and 'Hexadecimal') inside before continuing. Also, they should have values ('binary' and 'hexadecimal').

  +	When the [Convert it] button is clicked, the expected result should appear in the [Result] input field.

![изображение](https://user-images.githubusercontent.com/82647282/229580125-64894fa6-7ebf-4f03-8a06-964efbcfb31a.png)

![изображение](https://user-images.githubusercontent.com/82647282/229580152-c2d4ef24-3fc9-4d61-8805-dd9c75cd7577.png)

### Problem 11.	Time Converter

Create a program that converts different time units. Your task is to add a click event listener to all [CONVERT] buttons. When a button is clicked, read the corresponding input field, convert the value to the three other time units and display it in the input fields.

Examples

![изображение](https://user-images.githubusercontent.com/82647282/229580277-15a223b5-0645-47ec-b5b4-0e2585f4dd12.png)

![изображение](https://user-images.githubusercontent.com/82647282/229580304-75c836b4-9337-488d-8bfd-de34fbca153a.png)

One day is equal to 24 hours/1440 minutes/86400 seconds. Whichever button we click, the input fields should change depending on the added value on the left. (For example, if we write 48 hours and click convert the days, the field value should change to 2).

### Problem 12.	Encode and Decode Messages

In this problem, you should create a JS functionality that encodes and decodes some messages which travel to the network.

![изображение](https://user-images.githubusercontent.com/82647282/229580454-e30e5eba-79ff-422e-967b-4f082f34ffce.png)

This program should contain two functionalities.

The first one is to encode the given message and send it to the receiver. 

The second one is to decode the received message and read it (display it).

When the [Encode and send it] button is clicked, you should get the given message from the first textarea. When you get the current message, you should encode it as follows:

  +	Change the ASCII CODE on every single character in that message when you add 1 to the current ASCII NUMBER, that represents the current character in that message
  +	Clear the sender textarea and add the encoded message to the receiver textarea

![изображение](https://user-images.githubusercontent.com/82647282/229580578-0af0a4d4-182d-48c3-a868-068e131f5738.png)

After clicking the [Encode and send it] button the result should be:

![изображение](https://user-images.githubusercontent.com/82647282/229580620-bb8a1392-4256-4b71-9ecc-72f2145b328c.png)

After that, when the [Decode and read it] button is clicked. You need to get the encoded message from the receiver textarea and do the opposite logic from encoding:

  +	Subtract 1 from the current ASCII NUMBER, that represents the current character in that message
  +	Replace the encoded message with the already decoded message in the receiver textarea, to make it readable

![изображение](https://user-images.githubusercontent.com/82647282/229580757-82659390-8e78-4ad4-af82-8f614bbbce53.png)

### Problem 13.	Distance Converter

Your task is to convert from one distance unit to another by adding a click event listener to a button. When it is clicked, read the value from the input field and get the selected option from the input and output units dropdowns. Then calculate and display the converted value in the disabled output field.

Example

![изображение](https://user-images.githubusercontent.com/82647282/229580905-1ab438d2-ff36-469e-b64e-618fbb3143a6.png)

Use the following table information 

| Unit | Meters |
| --- | --- |
| 1 km | 1000 m |
| 1 m | 1 m |
| 1 cm | 0.01 m |
| 1 mm | 0.001 m |
| 1 mi | 1609.34 m |
| 1 yrd | 0.9144 m |
| 1 ft | 0.3048 m |
| 1 in | 0.0254 m |

### Problem 14.	Sudomu

Write a function that implements SUDOMU (Sudoku inside the DOM).

![изображение](https://user-images.githubusercontent.com/82647282/229582007-4f6cf784-367a-444e-9039-ac353d0dde70.png)

The rules are simple and they are the same as the typical sudoku game.

If the table is filled with the right numbers, and the ["Quick Check"] button is clicked, the expected result should be:

![изображение](https://user-images.githubusercontent.com/82647282/229582137-5c545246-b262-439d-89fd-e50c28a5d3ed.png)

The table border should be changed to: "2px solid green". The text content of the paragraph inside the div with an id "check" must be "You solve it! Congratulations!". The text color of that paragraph must be green.

Otherwise, when the filled table does not solve the sudomu, the result should be:

![изображение](https://user-images.githubusercontent.com/82647282/229582287-7d859515-091f-4bcb-a54d-5ad2d973adc2.png)

The table border should be changed to: "2px solid red". The text content of the paragraph inside the div with an id "check" must be: "NOP! You are not done yet...". The text color of that paragraph must be red!

The ["Clear"] button clears the whole SUDOMU (removes all numbers) and the paragraph which contains the messages. It also removes the table border. 

![изображение](https://user-images.githubusercontent.com/82647282/229582413-58184ade-f12a-4fe9-a20b-7391d41be3f7.png)

### Problem 15.	JavaScript Quizz

Write a function that has the functionality of a quiz. 

![изображение](https://user-images.githubusercontent.com/82647282/229582492-9a31e928-9643-4bd0-98d3-21586355f199.png)

Three sections contain one question and 2 possible answers. The right answer is only one!

When one of the list elements is clicked, the next section must appear (if any…).

After all three questions have been answered, the results ul must appear, (Use 'none' and 'block' to hide and show the question sections), and the results must be added in the h1.

If all questions are answered correctly, you should print the following message: "You are recognized as top JavaScript fan!".

Otherwise, just print "You have {rightAnswers} right answers".

The right answers are: 

  +	onclick
  +	JSON.stringify() 
  +	 A programming API for HTML and XML documents

![изображение](https://user-images.githubusercontent.com/82647282/229582695-ff5dba96-2b18-4857-b3fd-dab9f187055a.png)

![изображение](https://user-images.githubusercontent.com/82647282/229582729-df134f36-5f39-4f95-a382-45598e9bebae.png)

![изображение](https://user-images.githubusercontent.com/82647282/229582754-b97bbbda-0e9b-4b70-abf7-b645c4240d3e.png)

![изображение](https://user-images.githubusercontent.com/82647282/229582776-c393c907-bb2c-43c0-9e05-aedebfc7c704.png)

![изображение](https://user-images.githubusercontent.com/82647282/229582804-6a016bac-3e40-4f2d-a0a8-8d2734df7f5b.png)