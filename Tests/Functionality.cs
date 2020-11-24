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
		}

		[Test]
		public void ShouldAlsoWorkWithoutSpaces()
		{
			Assert.AreEqual(7, facade.Calculate("+3+2++2"));
		}

		[Test]
		public void AndWithRandomSpacesAndTabs()
		{
			Assert.AreEqual(7, facade.Calculate("	+3 +2+  +2		 "));
		}
	}
}
