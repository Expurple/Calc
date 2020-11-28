using System.Globalization;

namespace Calc.Classes
{
	class NumberFormatter
	{
		string formatString = "G0"; // G is default in C#

		public NumberFormatter(bool scientific, bool _decimal)
		{
			if (scientific)
			{
				formatString = "E";
			}
			if (_decimal)
			{
				formatString = "F";
			}
		}

		public string Format(double value)
		{
			return value.ToString(formatString, CultureInfo.InvariantCulture);
		}
	}
}
