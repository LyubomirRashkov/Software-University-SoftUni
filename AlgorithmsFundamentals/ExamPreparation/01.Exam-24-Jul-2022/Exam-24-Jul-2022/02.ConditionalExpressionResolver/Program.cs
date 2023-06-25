using System;

namespace _02.ConditionalExpressionResolver
{
	public class Program
	{
		public static void Main(string[] args)
		{
			string expression = Console.ReadLine();

			while (expression.Length > 1)
			{
				int lastIndexOfQuestionMark = expression.LastIndexOf('?');

				string str1 = expression.Substring(0, lastIndexOfQuestionMark - 2);

				string currentExpression = expression.Substring(lastIndexOfQuestionMark - 2, 9);

				string str2 = expression.Substring(lastIndexOfQuestionMark + 7);

				string result = SolveExpression(currentExpression);

				expression = str1 + result + str2;
			}

			Console.WriteLine(expression);
        }

		private static string SolveExpression(string expression)
		{
			return expression[0] == 't' ? expression[4].ToString() : expression[8].ToString();
		}
	}
}
