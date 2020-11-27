using System;
using System.Reflection;
using System.Runtime.CompilerServices;

using System.CommandLine;
using System.CommandLine.Invocation;

using Calc.Classes;


[assembly: AssemblyVersion("0.1.0.0")]
[assembly: InternalsVisibleTo("Tests")]

namespace Calc
{
	class Program
	{
		public static int Main(string[] args)
		{
			var arg = new Argument<string>("argument",
				"An arithmetic expression to solve.\n" +
				"Supported operators are +-*/()\n" +
				"Variables and other operators are not supported.");

			var rootCommand = new RootCommand
			{
				arg
			};
			rootCommand.Name = "Calc";
			rootCommand.Description = "A tool to calculate arithmetic expressions.\n" +
				"Prints either a number, \"Infinity\", \"-Infinity\", " + "\"Nan\" or an error.\n" +
				"For more info on usage visit https://github.com/Expurple/Calc";
			
			rootCommand.Handler = CommandHandler.Create<string>(
				(argument) =>
			{
				var facade = new Facade();
				var result = facade.Process(argument);

				if (result.ReturnCode != 0)
					Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine(result.Output);
				Console.ResetColor();

				return (int)result.ReturnCode;
			});

			return rootCommand.Invoke(args);
		}

		public enum ErrorCode
		{
			BadCommandLineArguments = 1,
			OK = 0,
			UnexpectedError = -1,
			InvalidExpression = -2,
		};

		public struct Result
		{
			public string Output;
			public ErrorCode ReturnCode;
		}
	}
}
