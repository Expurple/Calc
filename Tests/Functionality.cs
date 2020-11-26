using NUnit.Framework;

using Calc.Classes;

namespace Calc.Tests
{
	public class Functionality
	{
		Facade facade;

		[SetUp]
		public void Setup()
		{
			facade = new Facade();
		}

		[Test]
		public void AddingPositiveValuesSeparatedByOneSpace()
		{
			Assert.AreEqual(7, facade.Calculate("+ 3 + 2 + + 2"));
			Assert.AreEqual(0.5, facade.Calculate("0.2 + 0.3"));
		}

		[Test]
		public void ShouldAlsoWorkWithoutSpaces()
		{
			Assert.AreEqual(7, facade.Calculate("+3+2++2"));
			Assert.AreEqual(0.5, facade.Calculate("0.2+0.3"));
		}

		[Test]
		public void AndWithRandomSpacesAndTabs()
		{
			Assert.AreEqual(7, facade.Calculate("	+3 +2+  +2		 "));
			Assert.AreEqual(0.5, facade.Calculate(" 0.2+	0.3 "));
		}

		[Test]
		public void ValidBracesShouldNotBrake()
		{
			Assert.AreEqual(7, facade.Calculate("+(3+2)+ +2"));
			Assert.AreEqual(0.5, facade.Calculate("((0.2 + 0.3))"));
		}

		[Test]
		public void UnaryMinusShouldWork()
		{
			Assert.AreEqual(-2, facade.Calculate("-2"));
			Assert.AreEqual(-2, facade.Calculate("3 + (-5)"));
			Assert.AreEqual(-2, facade.Calculate("-1 + -1"));
		}

		[Test]
		public void BinaryMinusShouldWork()
		{
			Assert.AreEqual(0, facade.Calculate("1 - 1"));
			Assert.AreEqual(8, facade.Calculate("3 - (-5)"));
			Assert.AreEqual(0, facade.Calculate("3 - 2 - 1"));
		}

		[Test]
		public void BracesPriorityShouldWork()
		{
			Assert.AreEqual(0, facade.Calculate("3 - 2 - 1"));
			Assert.AreEqual(2, facade.Calculate("3 - (2 - 1)"));
		}
	}
}
