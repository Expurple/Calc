using System.Collections.Generic;
using System.Linq;

namespace Calc.Classes
{
	class Calculator
	{
		/*
		All valid types of expressions:
		1         (just a number)
		±E        (unary plus/minus before some expression)
		E ± E     (binary plus/minus between two expressions)
		(E)       (expression in braces)
		*/
		public double Evaluate(List<Token> tokens)
		{
			System.Console.Write("Evaluating tokens: ");
			foreach (var token in tokens)
				System.Console.Write($"{token.StrValue}, ");
			System.Console.WriteLine();

			// Remove brackets around the expression
			while (tokens[0].StrValue == "(" && tokens[^1].StrValue == ")")
			{
				tokens = tokens.Skip(1).SkipLast(1).ToList();
			}

			// Find and execute top level addition or subtraction, if present
			int nBracesNotClosed = 0;
			for (int i = tokens.Count - 1; i > 0; i--)
			{
				if (tokens[i].StrValue == ")")
				{
					nBracesNotClosed++;
				}
				else if (tokens[i].StrValue == "(")
				{
					nBracesNotClosed--;
				}
				if (nBracesNotClosed == 0 &&
					tokens[i].type == Token.Type.PlusMinus &&
					tokens[i-1].type != Token.Type.PlusMinus)
				{
					return PerformOperation(tokens, i);
				}
			}

			// If prefixed with unary plus/minus, apply it
			if (tokens[0].type == Token.Type.PlusMinus)
			{
				double value = Evaluate(tokens.Skip(1).ToList());
				if (tokens[0].StrValue == "-")
					return -value;
				else
					return value;
			}

			// If it's a single number, return the value
			if (tokens.Count == 1 && tokens[0].type == Token.Type.Number)
			{
				return tokens[0].NumericValue;
			}

			throw new Exceptions.InvalidMathExpression();
		}

		private double PerformOperation(List<Token> tokens, int signIndex)
		{
			var leftTokens = tokens.Take(signIndex).ToList();
			var rightTokens = tokens.Skip(signIndex + 1).ToList();
			double leftValue = Evaluate(leftTokens);
			double rightValue = Evaluate(rightTokens);
			switch (tokens[signIndex].StrValue)
			{
				case "+":
					return leftValue + rightValue;
				case "-":
					return leftValue - rightValue;
				default:
					var message = "Calculator.PerformOperation called on invalid sign";
					throw new Exceptions.LogicError(message);
			}
		}
	}
}
