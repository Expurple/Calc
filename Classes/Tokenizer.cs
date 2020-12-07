using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Calc.Classes
{
	class Tokenizer
	{
		// This thread helped a lot: https://stackoverflow.com/questions/4680128
		const string splitPattern = @"([*%()\^\/]|(?<!E)[\+\-])";

		public List<Token> Tokenize(string expression)
		{
			var tokens = new List<Token>();
			expression = expression.Replace(" ", "").Replace("\t", ""); // Remove whitespace
			expression = expression.Replace(',', '.'); // Accept ',' as a decimal point
			string[] tokenStrings = Regex.Split(expression, splitPattern);
			tokenStrings = tokenStrings.Where(str =>  str != "").ToArray();

			foreach (var tokenStr in tokenStrings)
			{
				if (tokenStr == "+" || tokenStr == "-")
				{
					tokens.Add(new Token (Token.Type.PlusMinus, tokenStr));
				}
				else if (tokenStr == "*" || tokenStr == "/")
				{
					tokens.Add(new Token (Token.Type.MultiplyDivide, tokenStr));
				}
				else if (tokenStr == "^")
				{
					tokens.Add(new Token(Token.Type.Power, tokenStr));
				}
				else if (tokenStr == "%")
				{
					tokens.Add(new Token(Token.Type.Percent, tokenStr));
				}
				else if (tokenStr == "(" || tokenStr == ")")
				{
					tokens.Add(new Token (Token.Type.Brace, tokenStr));
				}
				else // It should be a number
				{
					// If can't parse as number, throws an exception
					var numberToken = ParseNumberToken(tokenStr);
					tokens.Add(numberToken);
				}
			}
			return tokens;
		}

		Token ParseNumberToken(string tokenStr)
		{
			try
			{
				// "InvariantInfo" is needed for my Russian system
				// to accept "." as a decimal point instead of ","
				double value = double.Parse(tokenStr, NumberFormatInfo.InvariantInfo);
				return new Token (Token.Type.Number, tokenStr, value);
			}
			catch (FormatException)
			{
				throw new Exceptions.InvalidMathExpression();
			}
		}
	}
}
