using NUnit.Framework;

using Calc.Tests.Units;

namespace Calc.Tests.Functionality
{
	[TestFixture]
	class Whitespace : FacadeTestingBase
	{
		[Test]
		public void OneSpaceSeparation()
		{
			Assert.AreEqual(7, facade.Calculate("+ 3 + 2 + + 2"));
			Assert.AreEqual(0.5, facade.Calculate("0.2 + 0.3"));
		}

		[Test]
		public void NoWhitespace()
		{
			Assert.AreEqual(7, facade.Calculate("+3+2++2"));
			Assert.AreEqual(0.5, facade.Calculate("0.2+0.3"));
		}

		[Test]
		public void RandomWhitespace()
		{
			Assert.AreEqual(7, facade.Calculate("	+3 +2+  +2		 "));
			Assert.AreEqual(0.5, facade.Calculate(" 0.2+	0.3 "));
		}
	}
}
