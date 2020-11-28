﻿using NUnit.Framework;

using Calc.Classes;
using Calc.Classes.Exceptions;

namespace Calc.Tests.Units
{
	class NumberFormatterTests
	{
		[Test]
		public void DefaultFormat()
		{
			var numberFormatter = new NumberFormatter(scientific: false, _decimal: false);
			
			Assert.AreEqual("-15", numberFormatter.Format(-15));
			Assert.AreEqual("0.267", numberFormatter.Format(0.267));
			Assert.AreEqual("1.23E+40", numberFormatter.Format(1.23E+40));
			Assert.AreEqual("1.23E-50", numberFormatter.Format(1.23E-50));
		}

		[Test]
		public void Scientific()
		{
			var numberFormatter = new NumberFormatter(scientific: true, _decimal: false);

			Assert.IsTrue(numberFormatter.Format(-15).Contains("E"));
			Assert.IsTrue(numberFormatter.Format(0.267).Contains("E"));
			Assert.IsTrue(numberFormatter.Format(1.23E+40).Contains("E"));
			Assert.IsTrue(numberFormatter.Format(1.23E-50).Contains("E"));
		}

		[Test]
		public void Decimal()
		{
			var numberFormatter = new NumberFormatter(scientific: false, _decimal: true);

			Assert.IsFalse(numberFormatter.Format(-15).Contains("E"));
			Assert.IsFalse(numberFormatter.Format(0.267).Contains("E"));
			Assert.IsFalse(numberFormatter.Format(1.23E+40).Contains("E"));
			Assert.IsFalse(numberFormatter.Format(1.23E-50).Contains("E"));
		}

		[Test]
		public void ScientificDecimalCollision()
		{
			Assert.Throws<BadCommandLineArguments>(
				() => new NumberFormatter(scientific: true, _decimal: true));
		}
	}
}
