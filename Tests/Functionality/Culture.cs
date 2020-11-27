using NUnit.Framework;

using Calc.Tests.Units;

namespace Calc.Tests.Functionality
{
	class Culture : FacadeTestingBase
	{
		[Test]
		public void AcceptsComma()
		{
			Assert.AreEqual(0.5, facade.Calculate("0,2 + 0,3"));
		}

		[Test]
		public void AcceptsCommaAndPointMixed()
		{
			Assert.AreEqual(0.5, facade.Calculate("0.2 + 0,3"));
		}

		[Test]
		public void ReturnsWithPoint()
		{
			var result = facade.Process("0,2");
			Assert.AreEqual("0.2", result.Output);

			result = facade.Process("0,2 + 0.2");
			Assert.AreEqual("0.4", result.Output);
		}
	}
}
