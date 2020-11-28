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

			var scientific = new Option<bool>(new string[] { "-E", "--scientific" },
													"Output in scientific notation");

			// End of options

			var rootCommand = new RootCommand
			{
				argument,
				scientific
			};
			
			rootCommand.Name = "Calc";
			rootCommand.Description = "A tool to calculate arithmetic expressions.\n" +
				"Prints either a number, \"Infinity\", \"-Infinity\", " + "\"Nan\" or an error.\n" +
				"For more info on usage visit https://github.com/Expurple/Calc";
			
			return rootCommand;
		}
	}
}
