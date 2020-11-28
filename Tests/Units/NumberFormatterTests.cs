using NUnit.Framework;

using Calc.Classes;
using Calc.Classes.Exceptions;

namespace Calc.Tests.Units
{
	[TestFixture]
	class NumberFormatterTests
	{
		[Test]
		public void DefaultFormat()
		{
			var numberFormatter = new NumberFormatter(
				precision: null, scientific: false, _decimal: false);
			
			Assert.AreEqual("-15", numberFormatter.Format(-15));
			Assert.AreEqual("0.267", numberFormatter.Format(0.267));
			Assert.AreEqual("1.23E+40", numberFormatter.Format(1.23E+40));
			Assert.AreEqual("1.23E-50", numberFormatter.Format(1.23E-50));
		}

		[Test]
		public void Scientific()
		{
			var numberFormatter = new NumberFormatter(
				precision: null, scientific: true, _decimal: false);

			Assert.IsTrue(numberFormatter.Format(-15).Contains("E"));
			Assert.IsTrue(numberFormatter.Format(0.267).Contains("E"));
			Assert.IsTrue(numberFormatter.Format(1.23E+40).Contains("E"));
			Assert.IsTrue(numberFormatter.Format(1.23E-50).Contains("E"));
		}

		[Test]
		public void Decimal()
		{
			var numberFormatter = new NumberFormatter(
				precision: null, scientific: false, _decimal: true);

			Assert.IsFalse(numberFormatter.Format(-15).Contains("E"));
			Assert.IsFalse(numberFormatter.Format(0.267).Contains("E"));
			Assert.IsFalse(numberFormatter.Format(1.23E+40).Contains("E"));
			Assert.IsFalse(numberFormatter.Format(1.23E-50).Contains("E"));
		}

		[Test]
		public void ScientificDecimalCollision()
		{
			Assert.Throws<BadCommandLineArguments>(
				() => new NumberFormatter(
					precision: null, scientific: true, _decimal: true
				)
			);
		}

		[Test]
		public void DecimalPrecision()
		{
			var numberFormatter = new NumberFormatter(
				precision: 1, scientific: false, _decimal: true);

			Assert.AreEqual("-15.0", numberFormatter.Format(-15));
			Assert.AreEqual("0.3", numberFormatter.Format(0.267));
			Assert.AreEqual("0.0", numberFormatter.Format(1.23E-50));
		}

		[Test]
		public void ScientificPrecision()
		{
			var numberFormatter = new NumberFormatter(
				precision: 4, scientific: true, _decimal: false);

			Assert.AreEqual("-1.5000E+001", numberFormatter.Format(-15));
			Assert.AreEqual("2.6700E-001", numberFormatter.Format(0.267));
			Assert.AreEqual("1.2300E+040", numberFormatter.Format(1.23E+40));
			Assert.AreEqual("1.2300E-050", numberFormatter.Format(1.23E-50));
		}

		[Test]
		public void BadPrecisionValue()
		{
			Assert.Throws<BadCommandLineArguments>(
				() => new NumberFormatter(
					precision: -1, scientific: false, _decimal: false
				)
			);

			Assert.Throws<BadCommandLineArguments>(
				() => new NumberFormatter(
					precision: 200, scientific: false, _decimal: false
				)
			);
		}
	}
}
