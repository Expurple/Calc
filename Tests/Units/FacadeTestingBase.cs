using NUnit.Framework;

using Calc.Classes;

namespace Calc.Tests.Units
{
	[TestFixture]
	abstract class FacadeTestingBase
	{
		protected Facade facade;

		[OneTimeSetUp]
		public void Setup()
		{
			facade = new Facade();
		}
	}
}
