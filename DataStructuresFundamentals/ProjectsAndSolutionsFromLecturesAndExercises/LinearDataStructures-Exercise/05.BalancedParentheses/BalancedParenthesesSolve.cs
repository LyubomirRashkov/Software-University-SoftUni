namespace Problem05.BalancedParentheses
{
	using System;
	using System.Collections.Generic;

	public class BalancedParenthesesSolve : ISolvable
	{
		public bool AreBalanced(string parentheses)
		{
			if (string.IsNullOrWhiteSpace(parentheses) || (parentheses.Length % 2 == 1))
			{
				return false;
			}

			Stack<char> symbols = new Stack<char>();

			foreach (var symbol in parentheses)
			{
				if (symbol == '{' || symbol == '[' || symbol == '(')
				{
					symbols.Push(symbol);

					continue;
				}

				char expected;

				if (symbol == '}')
				{
					expected = '{';
				}
				else if (symbol == ']')
				{
					expected = '[';
				}
				else if (symbol == ')')
				{
					expected = '(';
				}
				else
				{
					return false;
				}

				if (symbols.Count == 0 || expected != symbols.Pop())
				{
					return false;
				}
			}

			return symbols.Count == 0;
		}
	}
}
