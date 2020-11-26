using System;

namespace Calc.Classes.Exceptions
{
	class NoMathExpressionProvided : ArgumentException
	{
		public NoMathExpressionProvided(string message = "No math expression provided")
			: base(message)
		{ }
	}

	class InvalidMathExpression : ArgumentException
	{
		public InvalidMathExpression(string message = "Invalid math expression")
			: base(message)
		{ }
	}

	class LogicError : Exception
	{
		public LogicError(string message = "Logic error in code")
			: base(message)
		{ }
	}
}
