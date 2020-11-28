using NUnit.Framework;

using Calc.Tests.Units;
using Calc.Classes.Exceptions;

namespace Calc.Tests.Functionality
{
	class Brackets : FacadeTestingBase
	{
		[Test]
		public void ValidBracesShouldNotBrake()
		{
			Assert.AreEqual(7, facade.Calculate("+(3+2)+ +2"));
			Assert.AreEqual(0.5, facade.Calculate("((0.2 + 0.3))"));
			Assert.AreEqual(2, facade.Calculate("(1) + (1)"));
		}

		[Test]
		public void InvalidBracesShouldFail()
		{
			Assert.Throws<InvalidMathExpression>(
				() => { facade.Calculate("(3+2)+2)))"); });

			Assert.Throws<InvalidMathExpression>(
				() => { facade.Calculate("1+1)"); });

			Assert.Throws<InvalidMathExpression>(
				() => { facade.Calculate("0.3-(2"); });

			Assert.Throws<InvalidMathExpression>(
				() => { facade.Calculate("1 + ()"); });
		}

		[Test]
		public void BracesPrioritySubtraction()
		{
			Assert.AreEqual(0, facade.Calculate("3 - 2 - 1"));
			Assert.AreEqual(2, facade.Calculate("3 - (2 - 1)"));
		}

		[Test]
		public void BracesPriorityMultiplication()
		{
			Assert.AreEqual(-2.25, facade.Calculate("1 * 2 + 3 / 4 - 5"));
			Assert.AreEqual(-3.75, facade.Calculate("1 * (2 + 3) / 4 - 5"));
			Assert.AreEqual(-1, facade.Calculate("1 * 2 + 3 / (4 - 5)"));
			Assert.AreEqual(-5, facade.Calculate("(1 * 2 + 3) / (4 - 5)"));
			Assert.AreEqual(-5, facade.Calculate("1 * ((2 + 3) / (4 - 5))"));
		}
	}
}
