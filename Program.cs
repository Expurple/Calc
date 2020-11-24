using System;

using Calc.Classes;

/*
Ideas for command line options:
-h --help       show help
-f --file       treat the argument as a file name, and get the expression from that file
-c --no-color   don't color the output
*/

namespace Calc
{
	class Program
	{
		static int Main(string[] args)
		{
			// This parsing is primitive, but I'll leave it for now
			if (args.Length == 0)
			{
				Console.Write("Error: \"No math expression provided!\"");
				return (int)ErrorCode.NoExpression;
			}

			var facade = new Facade();
			try
			{
				double result = facade.Calculate(args[0]);
				Console.Write(result);
				return (int)ErrorCode.OK;
			}
			catch (Exception e)
			{
				Console.Write($"Error: \"{e.Message}\"");
				return (int)ErrorCode.UnexpectedError;
			}
		}

		enum ErrorCode
		{
			OK = 0,
			UnexpectedError = -1,
			NoExpression = -2,
		};
	}
}
