﻿

namespace Calc.Classes
{
	struct Token
	{
		public static string[] signs = { "+" };

		public Type type;
		public string StrValue;
		public double NumericValue;

		public enum Type
		{
			Number,
			Sign,
			Brace,
		}
	}
}
