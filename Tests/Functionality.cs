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
		public void ValidBracesShouldWorkFine()
		{
			Assert.AreEqual(7, facade.Calculate("+(3+2)+ +2"));
			Assert.AreEqual(0.5, facade.Calculate("((0.2 + 0.3))"));
		}
	}
}
