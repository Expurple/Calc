

namespace Calc.Classes
{
	struct Token
	{
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
