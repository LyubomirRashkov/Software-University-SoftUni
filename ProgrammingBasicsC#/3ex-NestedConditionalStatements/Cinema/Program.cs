using System;

namespace Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            // В една кинозала столовете са наредени в правоъгълна форма в r реда и c колони.
            // Има три вида прожекции с билети на различни цени:
            //•	Premiere – премиерна прожекция, на цена 12.00 лева.
            //•	Normal – стандартна прожекция, на цена 7.50 лева.
            //•	Discount – прожекция за деца, ученици и студенти на намалена цена от 5.00 лева.
            //Напишете програма, която чете тип прожекция(стринг), брой редове и брой колони в залата(цели числа), 
            //въведени от потребителя, и изчислява общите приходи от билети при пълна зала.
            //Резултатът да се отпечата във формат като в примерите по-долу, с 2 знака след десетичната точка.  

            string typeProjection = Console.ReadLine();
            int rows = int.Parse(Console.ReadLine());
            int columns = int.Parse(Console.ReadLine());

            int seats = rows * columns;

            double profit = 0;

            switch (typeProjection)
            {
                case "Premiere":
                    profit = seats * 12;
                    break;
                case "Normal":
                    profit = seats * 7.50;
                    break;
                case "Discount":
                    profit = seats * 5;
                    break;
            }
            Console.WriteLine($"{profit:f2} leva");
        }
    }
}
