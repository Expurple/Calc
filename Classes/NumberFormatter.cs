using System.Globalization;

namespace Calc.Classes
{
	class NumberFormatter
	{
		string formatString = "G0"; // G is default in C#

		public NumberFormatter(bool scientific, bool _decimal)
		{
			if (scientific && _decimal)
			{
				throw new Exceptions.BadCommandLineArguments(
					"Can't apply scientific and decimal notation simultaneously.");
			}
			else if (scientific)
			{
				formatString = "E";
			}
			else if (_decimal)
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
