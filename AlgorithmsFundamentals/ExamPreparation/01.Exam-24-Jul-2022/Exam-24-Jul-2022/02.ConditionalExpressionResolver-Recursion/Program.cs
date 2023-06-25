using System;
using System.Linq;

namespace _02.ConditionalExpressionResolver_Recursion
{
	public class Program
	{
		public static void Main(string[] args)
		{
			char[] expression = Console.ReadLine()
				.Split(' ', StringSplitOptions.RemoveEmptyEntries)
				.Select(s => s[0])
				.ToArray();

			int result = SolveExpression(expression, 0);

			Console.WriteLine(result);
        }

		private static int SolveExpression(char[] expression, int index)
		{
			if (char.IsDigit(expression[index]))
			{
				return expression[index] - '0';
			}

			if (expression[index] == 't')
			{
				return SolveExpression(expression, index + 2);
			}

			int countOfQuestionMark = 0;

			for (int i = index + 2; i < expression.Length; i++)
			{
				char currentSymbol = expression[i];

				if (currentSymbol == '?')
				{
					countOfQuestionMark++;
				}
				else if (currentSymbol == ':')
				{
					countOfQuestionMark--;

					if (countOfQuestionMark < 0)
					{
						return SolveExpression(expression, i + 1);
					}
				}
			}

			throw new InvalidOperationException();
		}
	}
}
