## PROBLEM DESCRIPTION - C# AUTO MAPPING OBJECTS


### FastFood Restaurant

You are provided with a skeleton of a real web project for simple fast food system. This project stores Employees who work in the fast food restaurant, a Position each employee has, Items which the restaurant offers, Categories for the different items, Orders which were made and the type or order the client choose (for here or to go). You can look at the FastFood.Models project if you want to get familiar with the entities in the database.

The thing you might have seen for the first time is the FastFood.Web project. In this project you will have to do some work to run correctly our Fast Food system. Open the Controllers folder. There you will see controller for each entity in the database.

![изображение](https://user-images.githubusercontent.com/82647282/183092660-252f96e9-953b-4ec9-a11e-fb31e2925b09.png)

If you open the position controller you will see that this is the only one controller which has created mappings and some changes over the database. Your work is to look at this controller understand its methods and what is their purpose and then go to every other controller and create the mappings and do some changes to the database. Don’t forget when you modify the database to save the changes you have made! The final thing to do is to go to MappingConfiguration folder and open the FastFoodProfile class.

![изображение](https://user-images.githubusercontent.com/82647282/183092772-b23c4549-0a96-460c-ac7f-d5f14d39e0fb.png)

As you know a good way to organize your mapping configurations is with profiles. In this class you have to put the mapping configuration in the constructor.

When you are done with the controllers and the profile, start the application and test if it works correctly when you try to create a new employee position, new category and etc.