

namespace Calc.Classes
{
	struct Token
	{
		public static string[] signs = { "+" };

		public double NumericValue;
		public char CharValue;
		public Type type;

		public enum Type
		{
			Number,
			Sign,
			Brace,
		}
	}
}
