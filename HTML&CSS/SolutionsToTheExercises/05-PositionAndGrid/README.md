## PROBLEMS DESCRIPTION - Position & Grid


### Problem 1.	Simple Site Layout

Create a Web page, holding like the following:

![изображение](https://user-images.githubusercontent.com/82647282/216169468-a691f47b-9d2a-46d7-a34a-4d2e350df291.png)

Create two files: simple-site-layout.html and styles.css. Change the document title to "	".

#### Requirements

\<body> that contains: header, aside, main, footer all with:
  +	border-radius: 3px;
  +	background: rgb(181, 216, 255);
  +	padding: 5px 10px; 

The elements into the body:
  
  +	\<header> with
    +	\<h1> text that is displayed as inline block and is vertically aligned in the middle;
    +	\<aside> tag that contains:
        +	\<ul> tag for unordered list
        +	list-style-type: none;
        +	margin: 0px;
        +	padding: 5px;
        +	\<li> tag for list item
        +	\<a> tag for hyperlink
        +	display: block;
        +	padding: 5px 0px;
        +	color: rgb(86, 40, 129);
        +	text-decoration: none;
  +	\<main> tag that contain:
    +	\<h1> text title for the tasks
    +	\<ul> tag with:
        +	\<li> for the tasks with their status
  +	\<footer> tag that contain:
    +	\<div> with copyright sign and text

CSS Grid

In the styles.css: 

  +	Make the body grid container by displaying the grid.
  +	Define two grid columns and their size. 100px for the first column and auto for the second. 
  +	Define the grid areas: header, main, aside, footer.
  +	Reference the grid areas: "header header", "aside main", "footer footer".
  +	Set gap: 10px.

### Problem 2.	Position Playground

Create a web page like the following:

![изображение](https://user-images.githubusercontent.com/82647282/216170428-9f834ec6-f3e2-4e68-9410-49e00bd6e7df.png)

#### Requirements

  +	Change the document title to "Positioning Playground"
  +	Import Font Awesome into your CSS file
  +	Add two container units (divs) with class viewport inside the body
    +	Inside each one adds section with class card (section.card)
        +	Change the display property to block
        +	Try to center the section with position property absolute

### Problem 3.	Center Position and Transform

Create a web page like the following:

![изображение](https://user-images.githubusercontent.com/82647282/216170768-6a9a4152-4b1e-4a16-b9ab-cc2416b2d697.png)

#### Requirements

  +	Change the document title to "Center Position and Transform"
  +	Section tag must have class="card"
  +	Create section with two divs
    +	First div contains image
    +	Second div contains: \<h3>, \<p> and a tags
  +	Use rgb(238, 238, 238) for body background
  +	Use rgb(255, 255, 255) for card background
  +	Use rgb(0, 153, 0) for card button background
  +	Use font Georgia, serif with size 1em/1.2 for the headings
  +	Set the image position property to absolute

### Problem 4.	Navigation

Create a web page like the following:

![изображение](https://user-images.githubusercontent.com/82647282/216171151-79719ac7-4986-499e-be00-25cdec6b359d.png)

#### Requirements

  +	Change the document title to "Navigation"
  +	Create a header with a h1 for as title
    +	Inside the header add a nav with a ul and 4 li elements
  +	Create a main, which contains an article with a header and h1 heading
    +	Add a section inside the article
  +	Create an aside element with two sections inside
    +	The sections should have a h3 heading and a navigation - nav with ul, li and a elements
  +	Use rgb(0, 102, 0) for the anchors
  +	Use rgb(238, 238, 238) for body background
  +	Use rgb(255, 255, 255) for image background and rgba(0, 0, 0, 0.25) for image box shadow
  +	Use font Georgia, serif for the blockquote
  +	Use font Georgia, serif with size 1em/1.2 for the headings

### Problem 5.	New Offer

Create a web page like the following:

![изображение](https://user-images.githubusercontent.com/82647282/216171432-abafa5a7-ca70-4372-bae9-417705adbfe2.png)

#### Requirements

HTML with \<body> that contains \<main> and two \<img>. \<img> with new.png need class="new".

CSS:

  +	\<main>:
    +	Width: 700px
    + Height: 500px
    +	Margins: 60px
  +	img.new:
    +	Relative position
    +	Top coordinates: -200px
    +	Right coordinates: 150px

### Problem 6.	Social Media Icons

Create a web page like the following:

![изображение](https://user-images.githubusercontent.com/82647282/216171772-8c0f14ff-508d-4263-abcc-2771ca94a4e0.png)

#### Requirements
  +	Change the document title to "Social Media Icons"
  +	Use FontAwesome to add social icons
  +	All you need for your HTML are ul, li and a tags
  +	Change the ul display property to inline-block
  +	Remove list items default style
  +	Each a tag must have border-radius: 50%;
  +	Check the provided screenshots to see the hover effects

### Problem 7.	Interior Design Studio

Create a webpage like the following:

![изображение](https://user-images.githubusercontent.com/82647282/216172062-d3cc7254-18f3-4a89-80f8-a9f9fc80a82e.png)

#### Requirements

HTML with \<body> that contains \<h1> and \<img>.

CSS:
  +	\<h1>
    +	Absolute position
    +	Top coordinates: 60px
    +	Left coordinates: 180px
    +	Text color: antiquewhite
    +	text-shadow: 1px 1px 20px black;

### Problem 8.	Jewellery Website

Create a webpage like the following:

![изображение](https://user-images.githubusercontent.com/82647282/216172379-2b24056e-ac08-461d-a767-c59079022af1.png)

#### Requirements

You will be given a skeleton with filled HTML and an empty CSS file. Write the missing CSS following the guidelines in the task.

  +	\<section>
    +	Set the position to absolute
    +	Use the coordinates: 250px and 180px to position the frame correctly
  +	\<h3>
    +	Font size: 16px
    +	Margin: 0px
  +	\<span>
    +	Padding left: 3px
    +	Text color: gray
    +	Font size: 14px
  +	\<div>
    +	Set the position to relative
    +	Use the coordinates: 50px and 8px to position the text correctly