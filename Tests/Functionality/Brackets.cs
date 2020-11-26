using NUnit.Framework;

using Calc.Tests.Units;

namespace Calc.Tests.Functionality
{
	class Brackets : FacadeTestingBase
	{
		[Test]
		public void ValidBracesShouldNotBrake()
		{
			Assert.AreEqual(7, facade.Calculate("+(3+2)+ +2"));
			Assert.AreEqual(0.5, facade.Calculate("((0.2 + 0.3))"));
		}

		[Test]
		public void BracesPriority()
		{
			Assert.AreEqual(0, facade.Calculate("3 - 2 - 1"));
			Assert.AreEqual(2, facade.Calculate("3 - (2 - 1)"));
		}
	}
}
