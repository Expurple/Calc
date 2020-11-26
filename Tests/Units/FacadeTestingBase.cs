using NUnit.Framework;

using Calc.Classes;

namespace Calc.Tests.Units
{
	class FacadeTestingBase
	{
		protected Facade facade;

		[SetUp]
		public void Setup()
		{
			facade = new Facade();
		}
	}
}
