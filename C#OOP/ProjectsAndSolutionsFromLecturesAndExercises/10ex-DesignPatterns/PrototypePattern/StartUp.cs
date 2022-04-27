namespace PrototypePattern
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            SandwichMenu sandwichMenu = new SandwichMenu();

            sandwichMenu["BLT"] = new Sandwich("Wheat", "Bacon", "", "Lettuce, Tomato");
            sandwichMenu["PB&J"] = new Sandwich("White", "", "", "Peanut Butter, Jelly");
            sandwichMenu["Turkey"] = new Sandwich("Rye", "Turkey", "Swiss", "Lettuce, Onion, Tomato");
            sandwichMenu["LoadedBLT"] = new Sandwich("Wheat", "Turkey, Bacon", "American", "Lettuce, Tomato, Union, Olives");
            sandwichMenu["ThreeMeatCombo"] = new Sandwich("Rye", "Turkey, Ham, Salami", "Provolone", "Lettuce, Olives");
            sandwichMenu["Vegeterian"] = new Sandwich("Wheat", "", "", "Lettuce, Union, Tomato, Olives, Spinach");

            Sandwich sandwich1 = sandwichMenu["BLT"].Clone() as Sandwich;
            Sandwich sandwich2 = sandwichMenu["PB&J"].Clone() as Sandwich;
            Sandwich sandwich3 = sandwichMenu["Turkey"].Clone() as Sandwich;
            Sandwich sandwich4 = sandwichMenu["LoadedBLT"].Clone() as Sandwich;
            Sandwich sandwich5 = sandwichMenu["ThreeMeatCombo"].Clone() as Sandwich;
            Sandwich sandwich6 = sandwichMenu["Vegeterian"].Clone() as Sandwich;
        }
    }
}
