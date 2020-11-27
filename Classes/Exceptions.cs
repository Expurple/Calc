using System;

namespace Calc.Classes.Exceptions
{
	class NoMathExpressionProvided : ArgumentException
	{
		public NoMathExpressionProvided(string message = "No math expression provided")
			: base(message)
		{ }
	}

	class TooManyArguments : ArgumentException
	{
		public TooManyArguments(string message =
						"Too many expressions to solve, expected one. " +
						"Try putting your expression in quotes")
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
