using NUnit.Framework;

namespace Calc.Tests.Functionality
{
	class ErrorCodes
	{
		[Test]
		public void Ok()
		{
			int expected = (int)Calc.Program.ErrorCode.OK;
			int actual = Calc.Program.Main(new string[] { "0.2 + 0.3" });
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void MultipleArguments()
		{
			int expected = (int)Calc.Program.ErrorCode.BadCommandLineArguments;
			int actual = Calc.Program.Main(new string[] { "0.2", "+", "0.3" });
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void BadOptionsCombination()
		{
			int expected = (int)Calc.Program.ErrorCode.BadCommandLineArguments;
			int actual = Calc.Program.Main(new string[] { "0.2 + 0.3", "-Ed" });
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void NoArguments()
		{
			int expected = (int)Calc.Program.ErrorCode.BadCommandLineArguments;
			int actual = Calc.Program.Main(new string[] { });
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void InvalidExpression()
		{
			int expected = (int)Calc.Program.ErrorCode.InvalidExpression;
			int actual = Calc.Program.Main(new string[] { "not a math expression" });
			Assert.AreEqual(expected, actual);
		}
	}
}
