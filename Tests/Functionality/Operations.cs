using NUnit.Framework;

using Calc.Tests.Units;

namespace Calc.Tests.Functionality
{
	class Operations : FacadeTestingBase
	{
		[Test]
		public void Addition()
		{
			Assert.AreEqual(7, facade.Calculate("+3 + 2 + +2"));
			Assert.AreEqual(0.5, facade.Calculate("0.2 + 0.3"));
		}

		[Test]
		public void UnaryMinus()
		{
			Assert.AreEqual(-2, facade.Calculate("-2"));
			Assert.AreEqual(-2, facade.Calculate("3 + (-5)"));
			Assert.AreEqual(-2, facade.Calculate("-1 + -1"));
		}

		[Test]
		public void BinaryMinus()
		{
			Assert.AreEqual(0, facade.Calculate("1 - 1"));
			Assert.AreEqual(8, facade.Calculate("3 - (-5)"));
			Assert.AreEqual(0, facade.Calculate("3 - 2 - 1"));
		}
	}
}
