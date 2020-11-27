using System;
using System.Runtime.CompilerServices;

using Calc.Classes;
using Calc.Classes.Exceptions;

[assembly: InternalsVisibleTo("Tests")]

/*
Ideas for command line options:
-h --help           show help
-f --file           treat the argument as a file name, and get the expression from that file
-c --no-color       don't color the output
-p --precision      set output precision
*/

namespace Calc
{
	class Program
	{
		public static int Main(string[] args)
		{
			var facade = new Facade();
			try
			{
				// This parsing is primitive, but I'll leave it for now
				if (args.Length == 0)
				{
					throw new NoMathExpressionProvided();
				}

				double result = facade.Calculate(args[0]);
				Console.Write(result);
				return (int)ErrorCode.OK;
			}
			catch (NoMathExpressionProvided e)
			{
				Console.Write($"Error: \"{e.Message}\"");
				return (int)ErrorCode.NoExpression;
			}
			catch (InvalidMathExpression e)
			{
				Console.Write($"Error: \"{e.Message}\"");
				return (int)ErrorCode.InvalidExpression;
			}
			catch (Exception e)
			{
				Console.Write($"Unexpected error:\n{e}");
				return (int)ErrorCode.UnexpectedError;
			}
		}

		public enum ErrorCode
		{
			OK = 0,
			UnexpectedError = -1,
			NoExpression = -2,
			InvalidExpression = -3,
		};
	}
}
