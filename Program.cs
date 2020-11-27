using System;
using System.Runtime.CompilerServices;

using Calc.Classes;

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
			var result = facade.Process(args);

			Console.Write(result.Output);
			return (int)result.ReturnCode;
		}

		public enum ErrorCode
		{
			OK = 0,
			UnexpectedError = -1,
			NoExpression = -2,
			InvalidExpression = -3,
			TooManyArguments = -4,
		};

		public struct Result
		{
			public string Output;
			public ErrorCode ReturnCode;
		}
	}
}
