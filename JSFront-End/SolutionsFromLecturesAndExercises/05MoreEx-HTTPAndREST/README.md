## PROBLEMS DESCRIPTION - HTTP AND REST (More Exercises)


### Problem 1.	Locked Profile

In this problem, you must create a JS program which shows and hides the additional information about users, which you can find by making a GET request to the server at address: http://localhost:3030/jsonstore/advanced/profiles
The response will be an object with the information for all users. Create a profile card for every user and display it on the web page. Every item should have the following structure:

![изображение](https://user-images.githubusercontent.com/82647282/230499039-2b3e533a-5b9b-4dad-ad32-2b5ce7576c17.png)

![изображение](https://user-images.githubusercontent.com/82647282/230499057-35358199-0164-4525-95c4-05e969e9f96d.png)

When one of the [Show more] buttons is clicked, the hiden information inside the div should be shown, only if the profile is not locked! If the current profile is locked, nothing should happen.

![изображение](https://user-images.githubusercontent.com/82647282/230499110-6ac97c85-7cb1-43bc-9d4c-6a93e4149b06.png)

If the hidden information is displayed and we lock the profile again, the [Hide it] button should not be working! Otherwise, when the profile is unlocked and we click on the [Hide it] button, the new fields must hide again.

### Problem 2.	Accordion

An html file is given and your task is to show more/less information for the selected article. At the start you should do a GET request to the server at adress: http://localhost:3030/jsonstore/advanced/articles/list where the response will be an object with the titles of the articles.

By clicking the [More] button for the selected article, it should reveal the content of a hidden div and changes the text of the button to [Less]. Obtain the content by making a GET request to the server at adress: http://localhost:3030/jsonstore/advanced/articles/details/:id where the response will be an object with property id, title, content. When the same button is clicked again (now reading Less), hide the div and change the text of the button to More. Link action should be toggleable (you should be able to click the button infinite amount of times). 

Example 

![изображение](https://user-images.githubusercontent.com/82647282/230499329-77a7bc72-bbc4-4e0e-a3ed-603eba939153.png)

![изображение](https://user-images.githubusercontent.com/82647282/230499338-701b2c0e-3dbf-4241-9427-9089808c3018.png)

Every item should have the following structure:

![изображение](https://user-images.githubusercontent.com/82647282/230499367-bfe2d671-07d4-4cb0-b3d5-2bdd4cb280c4.png)

You are allowed to add new attributes, but do not change the existing ones.