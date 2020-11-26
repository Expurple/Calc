using System;
using System.Collections.Generic;
using System.Text;

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

		public double Calculate(string expression)
		{
			var tokens = tokenizer.Tokenize(expression);
			var answer = calculator.Calculate(tokens);
			return answer;
		}
	}
}
