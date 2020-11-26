using NUnit.Framework;

using Calc.Classes;
using Calc.Classes.Exceptions;

namespace Calc.Tests
{
	public class Errors
	{
		[Test]
		public void ReturnCodes()
		{
			int expected, actual;

			expected = (int)Calc.Program.ErrorCode.OK;
			actual = Calc.Program.Main(new string[] { "0.2 + 0.3" });
			Assert.AreEqual(expected, actual);

			// Not expected to pass null from the command line, for example
			expected = (int)Calc.Program.ErrorCode.UnexpectedError;
			actual = Calc.Program.Main(new string[] { null });
			Assert.AreEqual(expected, actual);

			expected = (int)Calc.Program.ErrorCode.NoExpression;
			actual = Calc.Program.Main(new string[] { });
			Assert.AreEqual(expected, actual);

			expected = (int)Calc.Program.ErrorCode.InvalidExpression;
			actual = Calc.Program.Main(new string[] { "not a math expression" });
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void InvalidBracesShouldFail()
		{
			var facade = new Facade();

			Assert.Throws<InvalidMathExpression>(
				() => { facade.Calculate("(3+2)+2)))"); });

			Assert.Throws<InvalidMathExpression>(
				() => { facade.Calculate("1+1)"); });

			Assert.Throws<InvalidMathExpression>(
				() => { facade.Calculate("0.3-(2"); });
		}
	}
}
