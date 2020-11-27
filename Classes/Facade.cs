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

		public Program.Result Process(string[] args)
		{
			var result = new Program.Result();
			try
			{
				// This parsing is primitive, but I'll leave it for now
				if (args.Length == 0)
				{
					throw new NoMathExpressionProvided();
				}
				else if (args.Length > 1)
				{
					throw new TooManyArguments();
				}

				double answer = Calculate(args[0]);
				result.Output = answer.ToString(CultureInfo.InvariantCulture);
				result.ReturnCode = Program.ErrorCode.OK;
			}
			catch (NoMathExpressionProvided e)
			{
				result.Output = $"Error: \"{e.Message}\"";
				result.ReturnCode = Program.ErrorCode.NoExpression;
			}
			catch (InvalidMathExpression e)
			{
				result.Output = $"Error: \"{e.Message}\"";
				result.ReturnCode = Program.ErrorCode.InvalidExpression;
			}
			catch (TooManyArguments e)
			{
				result.Output = $"Error: \"{e.Message}\"";
				result.ReturnCode = Program.ErrorCode.TooManyArguments;
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
