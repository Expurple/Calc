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
			var rootCommand = CommandLineParser.DescribeRootCommand();
			
			rootCommand.Handler = CommandHandler.Create<string, bool, bool>(
				(argument, scientificOutput, decimalOutput) =>
			{
				var commandLineOptions = new Options
				{
					ScientificOutput = scientificOutput,
					DecimalOutput = decimalOutput
				};

				var facade = new Facade();
				var result = facade.Process(argument, commandLineOptions);

				if (result.ReturnCode != 0)
					Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine(result.Output);
				Console.ResetColor();

				return (int)result.ReturnCode;
			});

			return rootCommand.Invoke(args);
		}

		/// <summary>
		/// A struct for storing parsed command line options
		/// </summary>
		public struct Options
		{
			public bool ScientificOutput;
			public bool DecimalOutput;

			public static readonly Options Default = new Options
			{
				ScientificOutput = false,
				DecimalOutput = false
			};
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
