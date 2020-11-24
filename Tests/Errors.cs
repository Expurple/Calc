﻿using NUnit.Framework;

using Calc.Classes;

namespace Calc.Tests
{
	public class Errors
	{
		[Test]
		public void TestReturnCodes()
		{
			int expected, actual;

			expected = (int)Calc.Program.ErrorCode.OK;
			actual = Calc.Program.Main(new string[] { "0.2 + 0.3" });
			Assert.AreEqual(expected, actual);

			expected = (int)Calc.Program.ErrorCode.NoExpression;
			actual = Calc.Program.Main(new string[] { });
			Assert.AreEqual(expected, actual);
		}
	}
}
