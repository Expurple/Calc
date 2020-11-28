using System.Globalization;

namespace Calc.Classes
{
	class NumberFormatter
	{
		string formatString = "G0";

		public NumberFormatter(bool scientific)
		{
			if (scientific)
			{
				formatString = "E";
			}
		}

		public string Format(double value)
		{
			return value.ToString(formatString, CultureInfo.InvariantCulture);
		}
	}
}
