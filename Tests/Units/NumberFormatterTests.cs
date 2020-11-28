using NUnit.Framework;

using Calc.Classes;

namespace Calc.Tests.Units
{
	class NumberFormatterTests
	{
		[Test]
		public void DefaultFormat()
		{
			var numberFormatter = new NumberFormatter();
			Assert.AreEqual("-15", numberFormatter.Format(-15));
			Assert.AreEqual("0.267", numberFormatter.Format(0.267));
			Assert.AreEqual("1.23E+40", numberFormatter.Format(1.23E+40));
			Assert.AreEqual("1.23E-50", numberFormatter.Format(1.23E-50));
		}
	}
}
