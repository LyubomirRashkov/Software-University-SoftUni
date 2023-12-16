using System;
using System.Collections.Generic;
using System.Text;

namespace Exam.Expressionist
{
	public class Expressionist : IExpressionist
	{
		private Expression root;
		private readonly Dictionary<string, Expression> expressionsById;

		public Expressionist()
		{
			this.expressionsById = new Dictionary<string, Expression>();
		}

		public void AddExpression(Expression expression)
		{
			if (this.root != null)
			{
				throw new ArgumentException();
			}

			this.root = expression;

			this.expressionsById.Add(expression.Id, expression);
		}

		public void AddExpression(Expression expression, string parentId)
		{
			if (!this.expressionsById.ContainsKey(parentId)
				|| this.expressionsById[parentId].RightChild != null)
			{
				throw new ArgumentException();
			}

			Expression parent = this.expressionsById[parentId];

			if (parent.LeftChild is null)
			{
				parent.LeftChild = expression;
			}
			else
			{
				parent.RightChild = expression;
			}

			expression.Parent = parent;

			this.expressionsById.Add(expression.Id, expression);
		}

		public bool Contains(Expression expression) => this.expressionsById.ContainsKey(expression.Id);

		public int Count() => this.expressionsById.Count;

		public Expression GetExpression(string expressionId)
		{
			this.ValidateExpressionExists(expressionId);

			return this.expressionsById[expressionId];
		}

		public void RemoveExpression(string expressionId)
		{
			this.ValidateExpressionExists(expressionId);

			Expression expression = this.expressionsById[expressionId];

			Expression parent = expression.Parent;

			if (parent is null)
			{
				this.root = null;

				this.expressionsById.Clear();

				return;
			}

			if (parent.LeftChild.Id == expression.Id)
			{
				parent.LeftChild = parent.RightChild;
			}

			parent.RightChild = null;

			this.RemoveFromDictionary(expression);
		}

		public string Evaluate()
		{
			if (this.root is null)
			{
				return string.Empty;
			}

			StringBuilder sb = new StringBuilder();

			this.EvaluateExpression(this.root, sb);

			return sb.ToString();
		}

		private void ValidateExpressionExists(string expressionId)
		{
			if (!this.expressionsById.ContainsKey(expressionId))
			{
				throw new ArgumentException();
			}
		}

		private void RemoveFromDictionary(Expression expression)
		{
			if (expression.LeftChild != null)
			{
				this.RemoveFromDictionary(expression.LeftChild);
			}

			if (expression.RightChild != null)
			{
				this.RemoveFromDictionary(expression.RightChild);
			}

			this.expressionsById.Remove(expression.Id);
		}

		private void EvaluateExpression(Expression expression, StringBuilder sb)
		{
			if (expression.Type == ExpressionType.Value)
			{
				sb.Append(expression.Value);
			}
			else
			{
				sb.Append("(");

				if (expression.LeftChild != null)
				{
					this.EvaluateExpression(expression.LeftChild, sb);

					sb.Append($" {expression.Value} ");

					if (expression.RightChild != null)
					{
						this.EvaluateExpression(expression.RightChild, sb);
					}
				}

				sb.Append(")");
			}
		}
	}
}
