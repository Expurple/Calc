using System.CommandLine;

namespace Calc.Classes
{
	static class CommandLineParser
	{
		public static RootCommand DescribeRootCommand()
		{
			var argument = new Argument<string>("argument",
				"An arithmetic expression to solve.\n" +
				"Supported operators are +-*/()\n" +
				"Variables and other operators are not supported.");

			// Options:

			var scientific = new Option<bool>(new string[] { "-E", "--scientific-output" },
					"Force output in scientific notation,\n" +
					"can't be used together with -d\n");
			var _decimal = new Option<bool>(new string[] { "-d", "--decimal-output" },
					"Force output in decimal notation,\n" +
					"can't be used together with -E\n");

			// End of options

			var rootCommand = new RootCommand
			{
				argument,
				scientific,
				_decimal
			};
			
			rootCommand.Name = "Calc";
			rootCommand.Description = "A tool to calculate arithmetic expressions.\n" +
				"Prints either a number, \"Infinity\", \"-Infinity\", " + "\"Nan\" or an error.\n" +
				"For more info on usage visit https://github.com/Expurple/Calc";
			
			return rootCommand;
		}
	}
}
