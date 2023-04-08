## PROBLEMS DESCRIPTION - HTTP AND REST (Lecture)


### Problem 1. GitHub Repos

Your task is to write a JS function that loads a github repository asynchronously with AJAX. You should use the Fetch API. Obtain the data by making  a GET request to the following URL: “https://api.github.com/users/testnakov/repos”

Transform the body to text with res.text() and in the second then() block of the Promise replace the text content of a div element with id "res" with the value from the response. Do not format the response in any way.

Example

![изображение](https://user-images.githubusercontent.com/82647282/229606185-c4fdb69e-2caf-40e6-9964-b49eb1faa6a0.png)

![изображение](https://user-images.githubusercontent.com/82647282/229606198-505bda52-73f7-41f2-8412-80c8c46ba736.png)

### Problem 2. Github Repos By Username

Your task is to write a JS function that executes an AJAX request with Fetch API and loads all user github repositories by a given username (taken from an input field with id "username") into a list (each repository as a list-item) with id "repos". Use the properties full_name and html_url of the returned objects to create a link to each repo’s GitHub page. If an error occurs (like 404 "Not Found"), append to the list a list-item with text the current instead. Clear the contents of the list before any new content is appended.

Example

![изображение](https://user-images.githubusercontent.com/82647282/229606564-0d4cbe6f-626a-4858-a039-8585177247ad.png)

![изображение](https://user-images.githubusercontent.com/82647282/229606579-15cc4f14-4f33-4cbd-92de-9c0753f0fd76.png)

### Problem 3. Github Commits

Write a JS program that loads all commit messages and their authors from a github repository using a given HTML. 

The loadCommits() function should get the username and repository from the HTML textboxes with IDs "username" and "repo" and make a GET request to the Github API: https://api.github.com/repos/<username>/<repository>/commits

Swap \<username\> and \<repository\> with the ones from the HTML:

  +	In case of success, for each entry add a list item (\<li\>) in the unordered list (\<ul\>) with id "commits" with text in the following format: "\<commit.author.name\>: \<commit.message\>" 
  +	In case of an error, add a single list item (\<li\>) with text in the following format: "Error: \<error.status\> (Not Found)"

Screenshots:

![изображение](https://user-images.githubusercontent.com/82647282/229606950-ba648004-c7a5-43fb-8f28-3bb2d2c1b513.png)

![изображение](https://user-images.githubusercontent.com/82647282/229606982-67bd228a-b35a-464d-9ff9-1a3188dd7e74.png)