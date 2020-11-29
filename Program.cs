using System;
using System.Reflection;
using System.Runtime.CompilerServices;

using Calc.Classes;


[assembly: AssemblyVersion("0.1.0.0")]
[assembly: InternalsVisibleTo("Tests")]

namespace Calc
{
	public class Program
	{
		/// <summary>
		/// An entry point of the program,
		/// just lets the command line parser do its job and call the RealMain
		/// </summary>
		public static int Main(string[] args)
		{
			var commandLineParser = new CommandLineParser(callback: RealMain);
			return commandLineParser.Invoke(args);
		}

		/// <summary>
		/// The real Main method, that is called after command line parsing
		/// </summary>
		public static int RealMain(string mathExpression, Options commandLineOptions)
		{
			var facade = new Facade();
			var result = facade.Process(mathExpression, commandLineOptions);

			if (result.ReturnCode != 0)
				Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine(result.Output);
			Console.ResetColor();

			return (int)result.ReturnCode;
		}

		/// <summary>
		/// A struct for storing parsed command line options
		/// </summary>
		public struct Options
		{
			public int? Precision;
			public bool ScientificOutput;
			public bool DecimalOutput;

			public static readonly Options Default = new Options
			{
				Precision = null,
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
