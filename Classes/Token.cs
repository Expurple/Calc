

namespace Calc.Classes
{
	struct Token
	{
		public Type type;
		public string StrValue;
		public double NumericValue;

		public Token(Type type, string strValue, double numericValue = 0)
		{
			this.type = type;
			this.StrValue = strValue;
			this.NumericValue = numericValue;
		}

		public bool IsSign
		{
			get
			{
				return type == Type.PlusMinus || type == Type.MultiplyDivide;
			}
		}

		public enum Type
		{
			Number,
			PlusMinus,
			MultiplyDivide,
			Brace,
		}
	}
}
