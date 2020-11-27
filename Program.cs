using System;
using System.Reflection;
using System.Runtime.CompilerServices;

using Calc.Classes;


[assembly: AssemblyVersion("0.1.0.0")]
[assembly: InternalsVisibleTo("Tests")]


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
