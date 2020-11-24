using System.Collections.Generic;

namespace Calc.Classes
{
	class Calculator
	{
		public double Calculate(List<Token> tokens)
		{
			double result = 0;
			foreach (var token in tokens)
			{
				if (token.type == Token.Type.Number)
				{
					result += token.NumericValue;
				}
			}
			return result;
		}
	}
}
