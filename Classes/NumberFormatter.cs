using System.Globalization;

namespace Calc.Classes
{
	class NumberFormatter
	{
		public string Format(double value)
		{
			return value.ToString(CultureInfo.InvariantCulture);
		}
	}
}
