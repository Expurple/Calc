using System.CommandLine;
using System.CommandLine.Invocation;

namespace Calc.Classes
{
	public class CommandLineParser
	{
		public delegate int Callback(string expression, Program.Options parsedOptions);

		RootCommand rootCommand;

		// callback is intended to be Program.RealMain,
		// but it can be swapped for testing
		public CommandLineParser(Callback callback)
		{
			rootCommand = DescribeRootCommand();
			rootCommand.Handler = CommandHandler.Create (
				(string argument, bool readStdin, int? precision,
				bool scientificOutput, bool decimalOutput, bool percentOutput) =>
				{
					var parsedOptions = new Program.Options
					{
						ReadStdin = readStdin,
						Precision = precision,
						ScientificOutput = scientificOutput,
						DecimalOutput = decimalOutput,
						PercentOutput = percentOutput
					};
					return callback(argument, parsedOptions);
				}
			);
		}

		public int Invoke(string[] args)
		{
			return rootCommand.Invoke(args);
		}

		RootCommand DescribeRootCommand()
		{
			var argument = new Argument<string>("argument",
				"An arithmetic expression to solve.\n" +
				"Can contain decimal or scientific numbers\n" +
				"and the following operators: + - * / % ^ (  )\n" +
				"Variables and other operators are not supported.");
			argument.Arity = ArgumentArity.ZeroOrOne;

			// Options:

			var readStdin = new Option<bool>(new string[] { "-i", "--read-stdin" },
					"Read the expression from stdin\n" +
					"instead of command line arguments\n");
			var precision = new Option<int?>(new string[] { "-p", "--precision" },
					"Set output precision (from 0 to 100)\n");
			var scientific = new Option<bool>(new string[] { "-E", "--scientific-output" },
					"Force output in scientific notation");
			var _decimal = new Option<bool>(new string[] { "-d", "--decimal-output" },
					"Force output in decimal notation");
			var percent = new Option<bool>(new string[] { "-P", "--percent-output" },
					"Force output as a percent value\n");

			// End of options

			var rootCommand = new RootCommand
			{
				argument, readStdin, precision, scientific, _decimal, percent
			};
			
			rootCommand.Name = "Calc";
			rootCommand.Description = "A tool to calculate arithmetic expressions.\n" +
				"Prints either a number, \"Infinity\", \"-Infinity\", " + "\"Nan\" or an error.\n" +
				"For more info on usage visit https://github.com/Expurple/Calc";
			
			return rootCommand;
		}
	}
}
