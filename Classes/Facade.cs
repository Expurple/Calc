using System;
using System.Globalization;

using Calc.Classes.Exceptions;

namespace Calc.Classes
{
	class Facade
	{
		Tokenizer tokenizer;
		Calculator calculator;

		public Facade()
		{
			tokenizer = new Tokenizer();
			calculator = new Calculator();
		}

		public Program.Result Process(string expression)
		{
			var result = new Program.Result();
			try
			{
				double answer = Calculate(expression);
				result.Output = answer.ToString(CultureInfo.InvariantCulture);
				result.ReturnCode = Program.ErrorCode.OK;
			}
			catch (InvalidMathExpression e)
			{
				result.Output = $"Error: {e.Message}";
				result.ReturnCode = Program.ErrorCode.InvalidExpression;
			}
			catch (Exception e)
			{
				result.Output = $"Unexpected error:\n{e}";
				result.ReturnCode = Program.ErrorCode.UnexpectedError;
			}

			return result;
		}

		public double Calculate(string expression)
		{
			var tokens = tokenizer.Tokenize(expression);
			var answer = calculator.Calculate(tokens);
			return answer;
		}
	}
}
