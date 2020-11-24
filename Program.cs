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
		static void Main(string[] args)
		{
			var facade = new Facade();
			try
			{
				double result = facade.Calculate("test");
				Console.Write(result);
			}
			catch (Exception e)
			{
				Console.Write($"Error: \"{e.Message}\"");
			}
		}
	}
}
