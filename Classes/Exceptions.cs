using System;

namespace Calc.Classes.Exceptions
{
	class InvalidMathExpression : ArgumentException
	{
		public InvalidMathExpression(string message = "Invalid math expression")
			: base(message)
		{ }
	}

	class BadCommandLineArguments : ArgumentException
	{
		public BadCommandLineArguments(string message =
							"Invalid command line arguments were given")
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
