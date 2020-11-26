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
			// Remove brackets around the expression
			while (AreInBrackets(tokens))
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
				else if (nBracesNotClosed == 0 &&
					tokens[i].type == Token.Type.PlusMinus &&
					!tokens[i-1].IsSign) // <-- check if tokens[i] is unary
				{
					return PerformOperation(tokens, i);
				}
			}

			// Find and execute top level multiplication or division, if present
			nBracesNotClosed = 0;
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
				else if (nBracesNotClosed == 0 &&
					tokens[i].type == Token.Type.MultiplyDivide)
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

			// Else, the expression is something invalid
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
				case "*":
					return leftValue * rightValue;
				case "/":
					return leftValue / rightValue;
				default:
					var message = "Calculator.PerformOperation called on invalid sign";
					throw new Exceptions.LogicError(message);
			}
		}

		private bool AreInBrackets(List<Token> tokens)
		{
			if (tokens[0].StrValue != "(" || tokens[^1].StrValue != ")")
				return false;

			// This logic is a fix for situatuons like "(1) + (2)"
			int openBrackets = 1;
			for (int i = 1; i < tokens.Count - 1; i++)
			{
				if (tokens[i].StrValue == "(")
				{
					openBrackets++;
				}
				else if (tokens[i].StrValue == ")")
				{
					openBrackets--;
				}
				
				if (openBrackets == 0)
				{
					return false;
				}
			}

			return true;
		}
	}
}
