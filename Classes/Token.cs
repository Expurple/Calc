

namespace Calc.Classes
{
	struct Token
	{
		public static string[] braces = { "(", ")" };

		public Type type;
		public string StrValue;
		public double NumericValue;

		public Token(Type type, string strValue, double numericValue = 0)
		{
			this.type = type;
			this.StrValue = strValue;
			this.NumericValue = numericValue;
		}

		public enum Type
		{
			Number,
			PlusMinus,
			Brace,
		}
	}
}
