## PROBLEMS DESCRIPTION


### Problem 1. Ski Lift

Use the provided skeleton to solve this problem.

Write the missing functionality of this user interface. The functionality is divided in the following steps: 

![изображение](https://user-images.githubusercontent.com/82647282/229631328-8509fd30-ab23-4fd6-a54e-740df89e993f.png)

Your Task

Write the missing JavaScript code to make the Ski Lift work as expected:

All fields (First Name, Last Name, Number of people, From date and Number of days) are filled with the correct input.

  +	First Name, Last Name, Number of people, From date and Number of days are non-empty strings. If any of them is empty, the program should not do anything.

Getting the information from the form

![изображение](https://user-images.githubusercontent.com/82647282/229631461-c98d43fa-6889-4cce-a561-7931eb50bfad.png)

  +	On clicking the ["Next step"] button the information from the input fields is listed in the "info-ticket" section. For the input fields a list item is added to the " ticket-info-list" unordered list. 
  +	The text format and order for the list item should be the same as on the picture below.  
  +	When the button is clicked, the input fields must be cleared and the ["Next step"] button must be disabled. At the same time the "Edit" and the "Continue" buttons must be enabled. 

The HTML structure looks like this:  

![изображение](https://user-images.githubusercontent.com/82647282/229631545-6f31c8d0-63fe-4633-aaff-cadc57d92e3e.png)

The functionality here is the following: 

  +	When the "Edit" button is clicked, all of the information is loaded in the input fields from step 1 and the ["Next step"] button is enabled again.

![изображение](https://user-images.githubusercontent.com/82647282/229631625-ee9f9617-5f4d-4182-b2f7-e85997959a41.png)

  +	The list item must be removed from the " ticket-info-list" and all of the information must go back to the input fields again. 
  
![изображение](https://user-images.githubusercontent.com/82647282/229632546-ad7cc758-52b1-4e5d-9d66-bee22b91f8d7.png)

  +	When the "Continue" button is clicked, the information from "ticket-info-list" unordered list must be transferred to "confirm-ticket" in the same HTML structure. For you, this means removing everything inside of the ul with class "ticket-content" and adding in "confirm-ticket", the list item with same information and class "ticket-info-list", delete "Edit" and "Continue" buttons and add new buttons "Confirm" and "Cancel" with class "confirm-btn" and "cancel-btn".
  
![изображение](https://user-images.githubusercontent.com/82647282/229631843-29102183-dcf3-433a-8677-e86d6eec29d3.png)

  +	This is HTML structure of "confirm-ticket" unordered list:
  
![изображение](https://user-images.githubusercontent.com/82647282/229631896-54d3f422-cb9a-43fe-aa55-38b8ea7dea89.png)

  +	When the "Cancel" button is clicked, the list item must be removed, from the "confirm-ticket", the ["Next step"] button is enabled again.
  
![изображение](https://user-images.githubusercontent.com/82647282/229631936-9749baf1-2331-4774-aac3-6069de62e333.png)

  +	When the "Confirm" button is clicked, the \<div\> element with id="main" must be removed, from the body and  you must add \<h1\> element with id="thank-you" and text "Thank you, have a nice day!" and \<button\> with id="back-btn" and text "Back".
  
![изображение](https://user-images.githubusercontent.com/82647282/229632072-9278cc89-00de-49e3-a916-d12f0bea2c76.png)

  + The HTML structure looks like this:  
  
![изображение](https://user-images.githubusercontent.com/82647282/229632126-090f7976-7fde-43ca-8802-cd1302bc1688.png)

  +	On clicking the ["Back"] button you must reload the page.
  
### Problem 2. Hotel Reservation

Use the provided skeleton to solve this problem.

Write the missing functionality of this user interface. The functionality is divided in the following steps: 

![изображение](https://user-images.githubusercontent.com/82647282/229632807-f006057b-b0e8-4c87-8537-1f9992cb3d00.png)

Your Task

Write the missing JavaScript code to make the Hotel Reservation work as expected:

All fields (First Name, Last Name, Check-in date, Check-out date and Number of guests) are filled with the correct input.

  +	First Name, Last Name, Check-in date, Check-out date and Number of guests are non-empty strings and Check-in date is before Check-out date. If any of them is empty, the program should not do anything.

Getting the information from the form

![изображение](https://user-images.githubusercontent.com/82647282/229632886-0b0c1e79-51de-4d81-a518-35524064c0c1.png)

  +	On clicking the ["Next"] button the information from the input fields is listed in the "Reservation info" section. For the input fields a list item is added to the "info-list" unordered list. 
  +	The text format and order for the list item should be the same as on the picture below.  
  +	When the button is clicked, the input fields must be cleared and the ["Next"] button must be disabled. At the same time the "Edit" and the "Continue" buttons must be enabled. 

The HTML structure looks like this:  

![изображение](https://user-images.githubusercontent.com/82647282/229632967-d483eaac-c013-4136-842f-3212cf32a626.png)

The functionality here is the following: 
  
  +	When the "Edit" button is clicked, all of the information is loaded in the input fields from step 1 and the ["Next"] button is enabled again.

![изображение](https://user-images.githubusercontent.com/82647282/229633017-5ebd28c9-a782-49eb-a0df-85c7cbd6ba1d.png)

  +	The list items must be removed from the "info-list" and all of the information must go back to the input fields again. 
  
![изображение](https://user-images.githubusercontent.com/82647282/229633104-f2198f6e-4cd5-464f-a7af-5878388d1303.png)

  +	When the "Continue" button is clicked, the information from "info-list" unordered list must be transferred to "confirm-list" in the same HTML structure. For you, this means removing everything inside of the ul with class = "info-list" and adding in "confirm-list", the list item with same information and change "Edit" and "Continue" buttons to "Confirm" and "Cancel" with changed class.
  
![изображение](https://user-images.githubusercontent.com/82647282/229633166-5263912e-1a2c-40d6-804c-18fd4e051e65.png)

  +	This is HTML structure of "confirm-list" unordered list:
  
![изображение](https://user-images.githubusercontent.com/82647282/229633222-c63732a4-1ea9-4646-a7d1-d0da5657f1e8.png)

  +	When the "Confirm" button is clicked, the list item must be removed, from the "confirm-list", the ["Next"] button is enabled again you must add new class and add text to \<h1\> element with id="verification". If "Confirm" button is clicked class must be "reservation-confirmed" and text is "Confirmed.".
    +	"Confirm" button:

![изображение](https://user-images.githubusercontent.com/82647282/229633339-d6d78da1-f3fd-48a3-b99b-ef5be196838a.png)

  +	When the "Cancel" button is clicked, the list item must be removed, from the "confirm-list", the ["Next"] button is enabled again you must add new class and add text to \<h1\> element with id="verification". If "Cancel" button is clicked class must be "reservation-cancelled" and text is "Cancelled.".
    +	"Cancel" button:	

![изображение](https://user-images.githubusercontent.com/82647282/229633474-6b8cded4-d4d7-48d7-b8ac-62a1c013a341.png)

### Problem 3. Dish Manager

Use the provided skeleton to solve this problem.

Note: You can't and you have no permission to change directly the given HTML code (index.html file).

![изображение](https://user-images.githubusercontent.com/82647282/229633662-8c7b5f0d-c1c6-4491-9e10-2f44857a0429.png)

Your Task

Write the missing JavaScript code to make the Dish Manager work as expected:

  + All fields (First Name, Last Name, Age and Dish description) are filled with the correct input
    +	First Name, Last Name, Age and Dish description are non-empty strings. If any of them are empty, the program should not do anything.

Getting the information from the form

When you click the ["Submit"] button, the information from the input fields must be added to the ul with the id "in-progress" and then clear input fields. Also the counter with id "progress-count" should be increased by 1.  

The HTML structure looks like this:

![изображение](https://user-images.githubusercontent.com/82647282/229633786-e3e4378e-7254-4866-a8a4-b46b2aefd189.png)

![изображение](https://user-images.githubusercontent.com/82647282/229633805-31b83514-fb00-4667-944d-a71221c55804.png)

Edit information for posts

When the ["Edit"] button is clicked, the information from the post must be sent to the input’s fields and the record should be deleted from the ul "in-progress". Also the counter with id "progress-count" should be decreased by 1.  

![изображение](https://user-images.githubusercontent.com/82647282/229633861-7f3d645d-6676-42bb-afe5-6285df7dcbcc.png)

After editing the information make a new record to the ul with updated information and increase the counter.

![изображение](https://user-images.githubusercontent.com/82647282/229633903-3d95a335-7766-4460-9c6b-ba13984339e3.png)

Complete posts

When you click the ["Mark as complete"] button, the record must be deleted from the ul with id "in-progress", appended to the ul with the id "finished" and the counter with id "progress-count" should be decreased by 1.  

The buttons [“Edit”] and [“Mark as complete”] should be removed from the li element.

![изображение](https://user-images.githubusercontent.com/82647282/229633995-5653478b-30d8-4934-80b8-47241d10c9b3.png)

![изображение](https://user-images.githubusercontent.com/82647282/229634018-dd8f3684-2fb5-4abf-827b-c713780c14a8.png)

Clear posts

When you click the ["Clear"] button, the record for all posts must be deleted from the ul with the id "finished".

![изображение](https://user-images.githubusercontent.com/82647282/229634066-66377ea2-03cb-48b8-a8f5-f86b601665c8.png)

### Problem 4. Car Dealers

Use the provided skeleton to solve this problem.

Note: You can't and you have no permission to change directly the given HTML code (index.html file).

![изображение](https://user-images.githubusercontent.com/82647282/229634287-6e875c56-3149-4b48-915c-f9f60ad2c67d.png)

Your Task

Write the missing JavaScript code to make the Car Dealer work as expected:

  + All fields (make, model, year, fuel, original-cost and selling-price) are filled with the correct input and selling price should have bigger value than original price
    +	Make, model, year, fuel, original-cost and selling price are non-empty strings. If any of them are empty, or original price is bigger than selling price the program should not do anything.

Getting the information from the form

When you click the [“Publish”] button, the information from the input fields must be added to the tbody with the id “table-body”. Then, clear all input fields. 

The HTML structure looks like this:

![изображение](https://user-images.githubusercontent.com/82647282/229634400-16bd20c4-de8b-4f40-86b5-3b55d4faa851.png)

![изображение](https://user-images.githubusercontent.com/82647282/229634430-4a325e96-5b86-4918-aaba-1c22d4c64a92.png)

![изображение](https://user-images.githubusercontent.com/82647282/229634449-98a01ab1-7f39-46d5-9968-48d141466663.png)

Edit information for posts

When the ["Edit"] button is clicked, the information from the post must be sent to the input fields and the record should be deleted from the tbody with the 
id "table-body". 

![изображение](https://user-images.githubusercontent.com/82647282/229634525-a1810196-67f7-4232-ad68-694c0eccc0e1.png)

After editing the information make a new record to the tbody with updated information.

![изображение](https://user-images.githubusercontent.com/82647282/229634572-f5542e3e-9228-4fd1-8508-b9c4aa67f2af.png)

Sell car

When you click the ["Sell"] button, the record must be deleted from the tbody with id "table-body" and a new record must be appended to the ul with the id "cars-list"

The new record should be as the following: 
  
  +	First span should include both car Make and Model as whole string and separated by a single space
  +	Second span should include the Production year
  +	Third span should include the difference between the Selling price and Original price

![изображение](https://user-images.githubusercontent.com/82647282/229634684-9ad05d5d-a3dc-4e7f-858e-5130e159a3f1.png)

Total profit made will be the sum from all sold cars profits which should be rounded to the second digit after the decimal point and should be displayed in strong with id "profit"

![изображение](https://user-images.githubusercontent.com/82647282/229634710-19b31082-f1c4-4dc0-8bfd-638a79d1e5a7.png)

### Problem 5. Forum Posts

Use the provided skeleton to solve this problem.

Note: You can't and you have no permission to change directly the given HTML code (index.html file).

![изображение](https://user-images.githubusercontent.com/82647282/229635814-11258233-8e17-4e4f-8602-90a628ccf886.png)

Your Task

Write the missing JavaScript code to make the Forum work as expected:

  + All fields (title, category, and content) are filled with the correct input
    +	Title, category, and content are non-empty strings. If any of them are empty, the program should not do anything.

Getting the information from the form

When you click the ["Publish"] button, the information from the input fields must be added to the ul with the id "review-list" and then clear input fields.    
The HTML structure looks like this:

![изображение](https://user-images.githubusercontent.com/82647282/229636112-4e48312b-343c-4d60-af2c-6a142487b88f.png)

![изображение](https://user-images.githubusercontent.com/82647282/229636121-ee2b46f2-4a7f-459d-b6c4-a52856ce5a6d.png)

Edit information for posts

When the ["Edit"] button is clicked, the information from the post must be sent to the input’s fields and the record should be deleted from the ul "review-list". 

![изображение](https://user-images.githubusercontent.com/82647282/229636187-3c431332-f38d-4555-98f3-fcbe0f2fa75d.png)

After editing the information make a new record to the ul with updated information.

![изображение](https://user-images.githubusercontent.com/82647282/229636236-c804575d-9ab0-41a7-a734-33a5097a0ca0.png)

Approve posts

When you click the ["Approve"] button, the record must be deleted from the ul with id "review-list"and appended to the ul with the id "published-list".

The buttons [“Edit”] and [“Approve”] should be removed from the li element.

![изображение](https://user-images.githubusercontent.com/82647282/229636303-b90ec1b7-bcee-4849-94f7-fb92aeb00b0c.png)

![изображение](https://user-images.githubusercontent.com/82647282/229636318-78a71cf6-02e8-4a8a-ac48-3b11a32c39bb.png)

Clear posts

When you click the ["Clear"] button, the record for all posts must be deleted from the ul with the id "published-list".

![изображение](https://user-images.githubusercontent.com/82647282/229636373-010f17b2-4588-4c36-825c-68ddd4bc3867.png)

### Problem 6. Mails Delivery

Use the provided skeleton to solve this problem.

Note: You can't and you have no permission to change directly the given HTML code (index.html file).

![изображение](https://user-images.githubusercontent.com/82647282/229636591-86cfcfa9-7db5-441f-8edb-1b4bbd105eca.png)

Your Task

Write the missing JavaScript code to make the Mails Delivery work as expected.

Getting the information from the form

![изображение](https://user-images.githubusercontent.com/82647282/229636661-a25e09fc-ff89-4b5b-9b5d-c8b50014a1d5.png)

  +	All fields are non-empty strings. If any of them are empty, the program should not do anything.
  +	When you click the ["Add to the List"] button, the information from the input fields must be added to the ul in div with class = "list-mails", and inputs must be cleared. The structure must be:

![изображение](https://user-images.githubusercontent.com/82647282/229636753-f6c8a400-b9ca-405b-8554-fff3f9fdbbb4.png)

  +	The Title and Recipient Name must be saved in the h4 tag and the message in the span tag.
  +	The Buttons - Send and Delete - are in div with id = "list-action".

![изображение](https://user-images.githubusercontent.com/82647282/229636832-e053d3ae-0be4-4e10-b38e-af83fbfd1895.png)

  +	When you click ["Reset"], the information from the inputs should be cleared, without any other changes.

Send Mails

  +	When the ["Send"] button is clicked, the information must be sent to the Sent Mails and the li tag should be deleted from the List of Mails.

![изображение](https://user-images.githubusercontent.com/82647282/229636903-93067ca7-40a1-4634-8c28-17b670f2e6cb.png)

  +	The structure must be:
  
![изображение](https://user-images.githubusercontent.com/82647282/229636951-ddd74206-a9c6-4575-ac8a-e4c218c17890.png)

  +	The Title and Recipient Name must both be saved in the span tag.
  +	The Button, Delete, is in div with class = "btn".

Delete Mails

  +	When you click the ["Delete"] button, the information on either the List of mails or the Sent mails div, the information must be sent to the Delete Mails and the record should be deleted from the List of Mails or Sent Mails.

![изображение](https://user-images.githubusercontent.com/82647282/229637066-1596605b-1297-48c0-91bd-ea2f853ff687.png)

![изображение](https://user-images.githubusercontent.com/82647282/229637074-283f2897-85aa-4aaf-9278-14fbe39d2db6.png)

![изображение](https://user-images.githubusercontent.com/82647282/229637095-2aa4da96-267b-4e46-9510-251f5fa4acaa.png)

  +	The structure must be:
  
![изображение](https://user-images.githubusercontent.com/82647282/229637144-442a44b1-f608-406f-b124-5be238a0b9b4.png)

### Problem 7. Work Process

Use the provided skeleton to solve this problem.

Note: You can't and you have no permission to change directly the given HTML code (index.html file).

![изображение](https://user-images.githubusercontent.com/82647282/229637397-92bd17a3-69b5-4e4b-9449-91f32040de38.png)

Your Task

Write the missing JavaScript code to make the Work Process work as expected.

Getting the information from the hired form

![изображение](https://user-images.githubusercontent.com/82647282/229637459-3e9766d0-1ac2-46ba-a512-493e40593c33.png)

  +	All fields are non-empty strings. If any of them are empty, the program should not do anything.
  +	When you click the ["Hire Worker"] button, the information from the input fields must be added to the table and then clear input fields. 
  +	Each input must be saved in td tag and the end must be added buttons – Fired and Edit. Look at the example below.
  +	The HTML structure looks like this:

![изображение](https://user-images.githubusercontent.com/82647282/229637545-a4f106ba-7c83-4377-a027-8726f5a38bf9.png)

![изображение](https://user-images.githubusercontent.com/82647282/229637562-6377d86f-9910-4f32-beb1-0170eb4c81a0.png)

  +	When the record is saved the salary must be added to the budget message. The sum should be rounded to the second decimal number:
  
![изображение](https://user-images.githubusercontent.com/82647282/229637612-202a2bc2-5140-4ff1-baf0-30ece3d4d87d.png)

![изображение](https://user-images.githubusercontent.com/82647282/229637628-c51064b7-b656-417d-afd9-f339c394506f.png)

Edit information for workers

  +	When the ["Edit"] button is clicked, the information from the table must be sent to the input’s fields and the record should be deleted from the table. 
  +	The salary for the edit worker should be taken out from the budget.

![изображение](https://user-images.githubusercontent.com/82647282/229637679-246f80a4-d429-4d0e-a6e4-8d6f3aee1196.png)

  +	After editing the information make a new record to the table with updated information.
  
![изображение](https://user-images.githubusercontent.com/82647282/229637733-90d021bb-83e5-4ec8-81f2-040b1120443d.png)

Fired workers

  +	When you click the ["Fired"] button, the record must be deleted from the table;
  +	The salary for the fired worker should be taken out from the budget.

![изображение](https://user-images.githubusercontent.com/82647282/229637791-47c8e6f1-a718-4801-bf92-0b4e2a5cc602.png)

### Problem 8. Service

Use the provided skeleton to solve this problem.

Note: You can't and you have no permission to change directly the given HTML code (index.html file).

![изображение](https://user-images.githubusercontent.com/82647282/229638003-4a7d7650-5d17-4889-9415-2cfb80540b1f.png)

Your Task

Write the missing JavaScript code to make the Service work as expected:
  +	All fields (description, client name, and client phone) are filled with the correct input
    +	Description, client name, and client phone are non-empty strings. If any of them are empty, the program should not do anything.
    +	Note that the possible values for the Product type are two - Phone and Computer. To see which drop-down menu option is selected, read its parent's properties: value.

Getting the information from the repair form

![изображение](https://user-images.githubusercontent.com/82647282/229638108-0727ea45-b08e-4585-9d9d-0b5e8a7e1e99.png)

  +	When you click the ["Send form"] button, the information from the input fields must be added to the section with the id "received-orders" and then clear input fields.    
  +	The HTML structure looks like this:

![изображение](https://user-images.githubusercontent.com/82647282/229638154-1ea2ddbf-567d-4cdc-bc42-7f7454a7666b.png)

Note: When an order is successfully added, the button ["Finish repair"] must be disabled, as the order cannot be completed if it has not started (Once the button is disabled, its color will turn gray).

![изображение](https://user-images.githubusercontent.com/82647282/229638190-b8bb5584-dcaa-4d96-b228-6b0dcfba010b.png)

  +	When the ["Start repair"] button is clicked, repair on the device begins. Since the process has already started, the worker will not be allowed to restart it, so the ["Start repair"] button must be disabled. (Once the button is disabled, its color will turn gray).
  +	Button ["Finish repair"] must become activated.

![изображение](https://user-images.githubusercontent.com/82647282/229638235-8b368410-257d-4d5c-98b6-06d60e8db4ff.png)

  +	When the ["Finish repair"] button is clicked, repair on the device is complete. Therefore, you need to move the current device in the section with the id "completed-orders".
  
![изображение](https://user-images.githubusercontent.com/82647282/229638278-49050fba-d4c9-41bd-ac7d-ca54ba568b02.png)

  +	The HTML structure looks like this:
  
![изображение](https://user-images.githubusercontent.com/82647282/229638326-329832d1-b635-40fc-a403-e160ebd41a4a.png)

  +	When you click the ["Clear"] button, you must remove all added div elements with class "container" from the section Completed orders.
  
![изображение](https://user-images.githubusercontent.com/82647282/229638355-1238b229-5c0f-40aa-b856-f36268fa0550.png)

  +	The HTML structure looks like this:

![изображение](https://user-images.githubusercontent.com/82647282/229638376-f9b4adc0-b6ba-4963-8293-f490d574014a.png)

### Problem 9. Furniture Store

Use the provided skeleton to solve this problem.

Note: You can't and you have no permission to change directly the given html code (index.html file).

Write the missing JavaScript code to make the Furniture Store work as expected:

![изображение](https://user-images.githubusercontent.com/82647282/229638623-49a20237-81e6-477f-aa2a-aa04fa4c8e08.png)

Your Task

  +	All fields (model, year, description, and price) are filled with the correct input
    +	Model and description are non-empty strings
    + Year and Price need to be positive numbers
    +	All fields must be filled

Getting the furniture information

![изображение](https://user-images.githubusercontent.com/82647282/229638695-cf17ae5d-c123-4aaa-9089-d1f658b021ea.png)

  +	When you click the “Add” button, the information from the input fields must be added to the table and then clear input fields.                     
  +	The table contains Model, Price of furniture and Actions - [More information], [Buy it]. Price must be rounded to second digit after decimal point.

![изображение](https://user-images.githubusercontent.com/82647282/229638786-d8d4b317-140e-419d-8120-39aabd493de9.png)

Each furniture must be appended to "furniture-list" and look like the picture below: 

![изображение](https://user-images.githubusercontent.com/82647282/229638818-68591766-d784-4da8-a5ad-47831f577cf4.png)

Each furniture has main information line (Model, Price) and an additional information line. The additional information line stores the description and year of manufacture of the furniture (hidden until the "More info" button is pressed).

When the "More Info" button is clicked, change button text from "More Info" to "Less Info" and style display of "class = hide" from "none " to  "contents". The second \<td\> must have attribute colspan with value 3. When click "Less Info" button is clicked, change button text from "Less Info" to "More Info" and style from "contents " to "none".

![изображение](https://user-images.githubusercontent.com/82647282/229638908-534e9ff9-47ff-48ca-b1ab-176d3886aa02.png)

![изображение](https://user-images.githubusercontent.com/82647282/229638924-22b6c18e-67a8-449f-8935-bfff18360089.png)

When the "Buy it" button is clicked, should have the following functionality: 

  +	The current furniture must be removed from the row in the table
  +	You need to change the total profit in the store. Take the element with class "total-price" and increase the current total price with the price of the furniture.

![изображение](https://user-images.githubusercontent.com/82647282/229638998-f0f644df-bf8f-4d12-a355-64d46f622b7b.png)

### Problem 10. Travel Agency

Use the provided skeleton to solve this problem.

Write the missing functionality of this user interface. The functionality is divided in the following steps: 

![изображение](https://user-images.githubusercontent.com/82647282/229639189-4ef82488-2513-49a5-ac49-bf83e808e1e2.png)

Getting the user’s personal information

![изображение](https://user-images.githubusercontent.com/82647282/229639232-92cf9cd3-4a11-4225-98e1-1bd1fa9f677d.png)

  +	On clicking the “Submit” button the information from the input fields is listed in the “preview” section. For each input field a list item is added to the “infoPreview” unordered list. 
  +	The text format and order for each list item should be the same as on the second picture below.  
  +	When the button is clicked, the input fields must be cleared and the “Submit” button must be disabled. At the same time the “Edit” button and the “Continue” button must be enabled. 
  +	One can only submit information if the “Full Name” and “Email” input fields are not empty.  

![изображение](https://user-images.githubusercontent.com/82647282/229639350-d88167d6-744f-4298-b91c-a1542001c5a2.png)

Previewing the user’s personal information 

This is an example for the preview section: 

![изображение](https://user-images.githubusercontent.com/82647282/229639400-3a832bbe-dce8-4583-a7ea-c7d903baa7f5.png)

The functionality here is the following: 

  +	When the “Edit” button is clicked, all of the personal information of the user is loaded in the input fields from step I and both the “Edit” and “Continue” buttons are disabled while the “Submit” button is enabled again.

![изображение](https://user-images.githubusercontent.com/82647282/229639466-c80a613e-9673-49e2-b577-f8931a61bac4.png)

  +	 The list items must be removed from the “infoPreview”. 

![изображение](https://user-images.githubusercontent.com/82647282/229639513-9c13c0fa-0513-4bca-8fc8-c481764e5424.png)

  +	When the “Continue” button is clicked, the reservation is completed. For you, this means removing everything inside of the “block” \<div\> and adding there only a \<h3\> tag: "Thank you for your reservation!" message: 
  
![изображение](https://user-images.githubusercontent.com/82647282/229639611-d4cec590-a7e3-4ffc-927c-2df96a72ed84.png)

This is everything your webpage must contain at this step:

![изображение](https://user-images.githubusercontent.com/82647282/229639655-4201c693-ce81-4efa-8925-3440bf0daa65.png)

### Problem 11. SoftBlog

Use the Given Skeleton to Solve This Problem.

Note: You Have NO Permission to Change Directly the Given HTML (Index.html File).

![изображение](https://user-images.githubusercontent.com/82647282/229639795-b43d06af-0a8d-43de-a8c9-7b9035f892c2.png)

Your Task

Write the missing JavaScript code to make the Blog application work as expected.

You should be able to create new articles.

Each article has author, title, category and content. When you click the [Create] button, a new article item should be added to the articles section. 

The new item should have the following structure:

![изображение](https://user-images.githubusercontent.com/82647282/229639865-3fa50101-f802-46d2-a15f-e9ad56bf74ce.png)

![изображение](https://user-images.githubusercontent.com/82647282/229639889-e31dbafc-95ba-4844-beb7-0d96191ce8aa.png)

  +	Append two buttons, which are in a div element with class "buttons" to each article item
    +	[Delete] button should have the following classes: "btn" and "delete"
    +	[Archive] button should have the following classes: "btn" and "archive"

When you click the [Archive] button you should move the article to the ol in the archive section. Archive section should be sorted by title.

Important! Do not move the entire article, but only the title of the article.  

![изображение](https://user-images.githubusercontent.com/82647282/229639964-c5f408a8-471d-4395-b7b9-66ee3bfaac72.png)

![изображение](https://user-images.githubusercontent.com/82647282/229639978-c8788c02-7ff1-46e6-a21b-e0be61735521.png)

When you click the [Delete] button you should delete the entire article. 

![изображение](https://user-images.githubusercontent.com/82647282/229640018-3f86cc2e-1d59-4362-a2e6-9081b768f5fe.png)

### Problem 12. Christmas Gifts Delivery 

Use the given skeleton to solve this problem.

Note: You have NO permission to change directly the given HTML (index.html file).

![изображение](https://user-images.githubusercontent.com/82647282/229640185-fa724422-db4f-4030-94a0-2a5c9ea609a6.png)

Your Task

Write the missing JavaScript code to make the Christmas Gifs Delivery application work as expected.

You should be able to add new gifts to the list of gifts.

Each product has name. When you click the [Add gift] button, a new list item should be added to the List of gifts. To each list item you should put a class “gift”. Upon clicking the [Add gift] button you should sort the gifts in alphabetical order and you should clear the input field.

![изображение](https://user-images.githubusercontent.com/82647282/229640223-24334756-500e-4ab9-b6ff-dae4c5f519a1.png)

The new item should have the following structure:

  +	Append two buttons to each list item
    +	Add class “gift” to each list item
    +	[Send] button with class “sendButton”
    +	[Discard] button with class “discardButton”

![изображение](https://user-images.githubusercontent.com/82647282/229640289-4cc72f02-ac99-4be3-a04a-eee5e4cdb168.png)

When you click the [Send] button you should move the list item to the Sent gifts section. 

Important! Do not move the entire list item, but only the name of the gift. You should leave the buttons behind. 

![изображение](https://user-images.githubusercontent.com/82647282/229640313-96dc44fb-52a4-40ff-a839-95f4d7a8d849.png)

When you click the [Discard] button you should move the list item to the Discarded gifts section. 

Important! Do not move the entire list item, but only the name of the gift. You should leave the buttons behind.

![изображение](https://user-images.githubusercontent.com/82647282/229640387-178f7c88-90ed-4b49-ab6b-77cd7d3a569d.png)

![изображение](https://user-images.githubusercontent.com/82647282/229640402-7ed0ec65-9408-40af-a7b9-40db4ea25a63.png)

### Problem 13. Task Manager

Use the index.html and app.js files to solve this problem. 

You have NO permission to directly change the given HTML code (index.html file).

![изображение](https://user-images.githubusercontent.com/82647282/229640581-cb5d6427-9420-45b9-85bf-1012bebefc46.png)

Your task

Write the missing JavaScript code to make the Task Manager Functionality works as follows: 

When the Add button is clicked, first you need to validate the inputs. If any of the input fields is empty, the function doesn’t make anything. 

After validating the input fields, you need to add the new task (article) in “Open” section. 

The HTML structure looks like this:

![изображение](https://user-images.githubusercontent.com/82647282/229640649-636a2a01-da69-4c2e-8b00-8fbc959a52fc.png)

The article should have two buttons “Start” and “Delete”. Be careful to set the classes for the buttons and the parent-div.

When the “Start” button is clicked, you need to move the Task in the section “In Progress”. Be careful with the buttons! The HTML structure looks like this: 

![изображение](https://user-images.githubusercontent.com/82647282/229640688-3506c8c8-d2b7-48ec-8662-832022202657.png)

When the “Delete” button is clicked, the Task (whole article) should be removed from the HTML. 

After clicking the “Finish” button, the Task will be completed, and you should move the article in the section “Complete”. The buttons with their parent div-element should be removed.

![изображение](https://user-images.githubusercontent.com/82647282/229640729-ec7fd16b-d6ce-4acc-99f7-fc4b66940113.png)

![изображение](https://user-images.githubusercontent.com/82647282/229641049-46b89dc6-2811-49a5-975b-54ffe63146f7.png)