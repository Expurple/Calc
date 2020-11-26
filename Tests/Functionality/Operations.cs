﻿using NUnit.Framework;

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

		[Test]
		public void Multiplication()
		{
			Assert.AreEqual(4, facade.Calculate("2 * 2"));
			Assert.AreEqual(27, facade.Calculate("3 * 3 * 3"));
			Assert.AreEqual(0, facade.Calculate("0.7 * 0"));
		}

		[Test]
		public void MultiplicationPriority()
		{
			Assert.AreEqual(-3, facade.Calculate("1 - 2 * 2"));
			Assert.AreEqual(50, facade.Calculate("5 * 5 + 5 * 5"));
		}

		[Test]
		public void Division()
		{
			Assert.AreEqual(2, facade.Calculate("6 / 3"));
			Assert.AreEqual(-2, facade.Calculate("-10 / 5"));
			Assert.AreEqual(10, facade.Calculate("-100 / -10"));
		}

		[Test]
		public void DivisionPriority()
		{
			Assert.AreEqual(8, facade.Calculate("6 + 6 / 3"));
			Assert.AreEqual(0.5, facade.Calculate("1/2 + 1/2 - 1/2"));
		}
	}
}
