using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Calc.Classes
{
	class Tokenizer
	{
		// This thread helped a lot: https://stackoverflow.com/questions/4680128
		const string splitPattern = @"([*()\^\/]|(?<!E)[\+\-])";

		public List<Token> Tokenize(string expression)
		{
			var tokens = new List<Token>();
			expression = expression.Replace(" ", "").Replace("\t", "");
			string[] tokenStrings = Regex.Split(expression, splitPattern);
			tokenStrings = tokenStrings.Where(str =>  str != "").ToArray();

			foreach (var tokenStr in tokenStrings)
			{
				if (Token.signs.Contains(tokenStr))
				{
					tokens.Add(new Token {
						type = Token.Type.Sign,
						StrValue = tokenStr
					});
				}
				else // It should be a number
				{
					tokens.Add(new Token {
						type = Token.Type.Number,
						StrValue = tokenStr,
						NumericValue = double.Parse(tokenStr)
						// If can't parse as number, throws an exception
					});
				}
			}
			return tokens;
		}
	}
}
