using System;

namespace _06._Barcode_Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            int startNumber = int.Parse(Console.ReadLine());
            int endNumber = int.Parse(Console.ReadLine());

            int ediniciStartNumber = startNumber % 10;
            int deseticiStartNumber = (startNumber / 10) % 10;
            int stoticiStartNumber = (startNumber / 100) % 10;
            int hilqdniStartNumber = startNumber / 1000;

            int ediniciEndNumber = endNumber % 10;
            int deseticiEndNumber = (endNumber / 10) % 10;
            int stoticiEndNumber = (endNumber / 100) % 10;
            int hilqdniEndNumber = endNumber / 1000;

            for (int i = hilqdniStartNumber; i <= hilqdniEndNumber; i++)
            {
                for (int j = stoticiStartNumber; j <= stoticiEndNumber; j++)
                {
                    for (int k = deseticiStartNumber; k <= deseticiEndNumber; k++)
                    {
                        for (int l = ediniciStartNumber; l <= ediniciEndNumber; l++)
                        {
                            if (i % 2 != 0 && j % 2 != 0 && k % 2 != 0 && l %2 != 0)
                            {
                                Console.Write($"{i}{j}{k}{l} ");
                            }
                        }
                    }
                }
            }
        }
    }
}
