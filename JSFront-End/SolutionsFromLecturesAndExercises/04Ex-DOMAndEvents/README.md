## PROBLEMS DESCRIPTION - DOM AND EVENTS (Exercise)


### Problem 1.	Subtraction

An HTML page holds two text fields with ids "firstNumber" and "secondNumber". Write a function to subtract the values from these text fields and display the result in the div named "result".

Example

![изображение](https://user-images.githubusercontent.com/82647282/229567899-70762491-8109-401e-b5ba-b6e76dd1e2a6.png)

### Problem 2.	Sections

You will receive an array of strings. For each string, create a div with a paragraph with the string in it. Each paragraph is initially hidden (display:none). Add a click event listener to each div that displays the hidden paragraph. Finally, you should append all divs to the element with an id "content".

Example

![изображение](https://user-images.githubusercontent.com/82647282/229568071-94220a50-8f40-415b-aff0-891ae9a38500.png)

![изображение](https://user-images.githubusercontent.com/82647282/229568091-e59d6414-e115-452c-800b-656bb0c393ed.png)

### Problem 3.	Accordion

An HTML file is given and your task is to show more/less information. By clicking the [More] button, it should reveal the content of a hidden div and changes the text of the button to [Less]. When the same link is clicked again (now reading Less), hide the div and change the text of the link to More. Link action should be toggleable (you should be able to click the button an infinite amount of times).

Example

![изображение](https://user-images.githubusercontent.com/82647282/229568292-b877ae65-a5ec-4e10-a6f1-327ac057ffc9.png)

![изображение](https://user-images.githubusercontent.com/82647282/229568322-44003ec4-a9d5-4ea4-961f-e7464e4555b7.png)

### Problem 4.	Locked Profile

In this problem, you should create a JS functionality that shows and hides the additional information about users.

![изображение](https://user-images.githubusercontent.com/82647282/229568458-1d3259f0-4d5a-43ab-9859-082df4a3cead.png)

When one of the [Show more] buttons is clicked, the hidden information inside the div should be shown, only if the profile is not locked! If the current profile is locked, nothing should happen.

![изображение](https://user-images.githubusercontent.com/82647282/229568563-f9772fb9-94d8-497b-8a5a-8b5ecc231251.png)

If the hidden information is displayed and we lock the profile again, the [Hide it] button should not be working! Otherwise, when the profile is unlocked and we click on the [Hide it] button, the new fields must hide again.

### Problem 5.	Fill Dropdown

Your task is to take values from input fields with ids "newItemText" and "newItemValue". Then you should create and append an \<option\> to the \<select\> with id "menu". Don’t forget to clear the input fields.

Example

![изображение](https://user-images.githubusercontent.com/82647282/229568902-ccde1669-ba7c-4b22-9174-fb6e3fbaebca.png)

### Problem 6.	Table - Search Engine

Write a function that searches in a table by given input.

![изображение](https://user-images.githubusercontent.com/82647282/229569000-e27f49de-f1d4-4428-8539-6e215fe7abd3.png)

When the "Search" button is clicked, go through all cells in the table except for the first row (Student name, Student email, and Student course) and check if the given input has a match (check for both full words and single letters).

If any of the rows contain the submitted string, add a class select to that row. Note that more than one row may contain the given string.

Оtherwise, if there is no match, nothing should happen.

Note: After every search ("Search" button is clicked), clear the input field and remove all already selected classes (if any) from the previous search, for the new search to contain only the new result.

For instance, if we try to find eva:

![изображение](https://user-images.githubusercontent.com/82647282/229569216-41815b61-4f0d-4b63-b29c-0ab8171b21e2.png)

The result should be:

![изображение](https://user-images.githubusercontent.com/82647282/229569272-e264367a-d033-4081-9803-f0c3c7c4a258.png)

If we try to find all students who have email addresses in softuni domain, the expected result should be:

![изображение](https://user-images.githubusercontent.com/82647282/229569329-2903e08f-0568-4d81-8a69-7348f64e3283.png)

### Problem 7.	Format the Text

Create a functionality that gets a text from textarea, formats the given text - you need to find out how many sentences there are in the text, simply split the whole text by '.' 

Also, every sentence must have at least 1 character.

![изображение](https://user-images.githubusercontent.com/82647282/229569504-51406b14-beb1-4e11-a741-a1f5be53e3ba.png)

Generate HTML paragraphs as a string (Use interpolation string to create paragraph element: '\<p\> {text} \</p\>') and append it to the div with an id = "output".

![изображение](https://user-images.githubusercontent.com/82647282/229569734-7e3f7b2f-25c4-4912-8a77-5572cf301f9b.png)

![изображение](https://user-images.githubusercontent.com/82647282/229569770-8a99e0e0-4aad-47fa-a241-c0ac35e1f099.png)

When the [Format] button is clicked, get the text inside the textarea with an id="input" and format it. The formatting is done as follows:

  +	Create a new paragraph element that holds no more than 3 sentences from the given input.
  +	If the given input contains less or 3 sentences, you need to create only 1 paragraph, fill it with these sentences and append this paragraph to the div with an id="output". 

Otherwise, when you have more than 3 sentences, create enough paragraphs to get all sentences from the textarea.

Just remember to restrict the sentences in each paragraph to 3.

Example:

  +	If the input textarea contains 2 sentences, create only 1 paragraph with these 2 sentences:

![изображение](https://user-images.githubusercontent.com/82647282/229570057-ef959bf0-4093-44a2-9a6c-9fd0fe2d5464.png)

  +	If the input textarea contains 7 sentences, create 3 paragraphs:
    + The first paragraph must contain the first 3 sentences
    + The second paragraph must contain the other three sentences of the whole text
    + The third paragraph will contain only the last sentence 

![изображение](https://user-images.githubusercontent.com/82647282/229570227-42a6262c-28d1-4619-bc82-ceeb09773f5b.png)

### Problem 8.	Furniture

You will be given some furniture as an array of objects. Each object will have a name, a price, and a decoration factor. 

When the ["Generate"] button is clicked, add a new row to the table for each piece of furniture with image, name, price, and decoration factor (code example below). 

When the ["Buy"] button is clicked, get all checkboxes that are marked and show in the result textbox the names of the piece of furniture that were checked, separated by a comma and single space (", ") in the following format: "Bought furniture: {furniture1}, {furniture2}…".

On the next line, print the total price in the format: "Total price: {totalPrice}" (formatted to the second decimal point). Finally, print the average decoration factor in the format: "Average decoration factor: {decFactor}".

Input Example:

[{"name": "Sofa", "img": "https://res.cloudinary.com/maisonsdumonde/image/upload/q_auto,f_auto/w_200/img/grey-3-seater-sofa-bed-200-13-0-175521_9.jpg", "price": 150, "decFactor": 1.2}]

Example

![изображение](https://user-images.githubusercontent.com/82647282/229570732-ae96be8b-b86b-40d9-8ecf-9a3184d58f09.png)