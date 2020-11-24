using System.Collections.Generic;
using System.Linq;

namespace Calc.Classes
{
	class Tokenizer
	{
		public List<Token> Tokenize(string expression)
		{
			var tokens = new List<Token>();

			// Assumes that tokens are always separated by a single space.
			// This is very primitive.
			foreach (var tokenStr in expression.Split(' '))
			{
				if (Token.signs.Contains(tokenStr))
				{
					tokens.Add(new Token {
						type = Token.Type.Sign,
						CharValue = tokenStr[0]
					});
				}
				else
				{
					tokens.Add(new Token {
						type = Token.Type.Number,
						NumericValue = double.Parse(tokenStr)
						// If can't parse, throws an exception
					});
				}
			}
			return tokens;
		}
	}
}
