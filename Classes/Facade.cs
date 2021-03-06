﻿using System;

using Calc.Classes.Exceptions;

namespace Calc.Classes
{
	class Facade
	{
		Tokenizer tokenizer;
		Calculator calculator;
		NumberFormatter numberFormatter;

		public Facade()
		{
			tokenizer = new Tokenizer();
			calculator = new Calculator();
		}

		// An overload for using in tests
		public Program.Result Process(string expression)
		{
			return Process(expression, Program.Options.Default);
		}

		public Program.Result Process(string expression, Program.Options options)
		{
			var result = new Program.Result();
			try
			{
				Check(expression, options);
				Apply(options);
				double answer = Calculate(expression);
				result.Output = numberFormatter.Format(answer);
				result.ReturnCode = Program.ErrorCode.OK;
			}
			catch (BadCommandLineArguments e)
			{
				result.Output = $"Bad arguments: {e.Message}";
				result.ReturnCode = Program.ErrorCode.BadCommandLineArguments;
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

		private void Check(string expression, Program.Options options)
		{
			if (expression == null && options.ReadStdin == false)
			{
				throw new BadCommandLineArguments(
				"Need to provide an expression or use \"-i\" option");
			}
		}

		private void Apply(Program.Options options)
		{
			numberFormatter = new NumberFormatter(
				precision:   options.Precision,
				scientific:  options.ScientificOutput,
				_decimal:    options.DecimalOutput,
				percent:     options.PercentOutput
			);
		}
	}
}
