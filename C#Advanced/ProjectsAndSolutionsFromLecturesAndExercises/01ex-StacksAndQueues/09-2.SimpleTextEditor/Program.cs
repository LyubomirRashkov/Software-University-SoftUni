using System;
using System.Collections.Generic;
using System.Text;

namespace _09_2.SimpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = string.Empty;

            Stack<string> textVariants = new Stack<string>();
            textVariants.Push(text);

            int numberOfOperations = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfOperations; i++)
            {
                string currentText = textVariants.Peek();

                StringBuilder sb = new StringBuilder(currentText);

                string[] currentOperationParts = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string command = currentOperationParts[0];

                if (command == "1")
                {
                    string textToAdd = currentOperationParts[1];

                    sb.Append(textToAdd);

                    textVariants.Push(sb.ToString());
                }
                else if (command == "2")
                {
                    int countOfElementsToErase = int.Parse(currentOperationParts[1]);

                    string newText = currentText.Substring(0, currentText.Length - countOfElementsToErase);

                    textVariants.Push(newText);
                }
                else if (command == "3")
                {
                    int index = int.Parse(currentOperationParts[1]);

                    Console.WriteLine(currentText[index - 1]);
                }
                else if (command == "4")
                {
                    textVariants.Pop();
                }
            }
        }
    }
}
