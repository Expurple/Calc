using System.Globalization;

using Calc.Classes.Exceptions;

namespace Calc.Classes
{
	class NumberFormatter
	{
		string formatString = "G"; // it's default, look up MSDN for double.ToString method

		public NumberFormatter(int? precision, bool scientific, bool _decimal)
		{
			if (scientific && _decimal)
			{
				throw new BadCommandLineArguments(
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

			if (precision.HasValue)
			{
				// This is required by double.ToString method, look up MSDN
				if (0 <= precision.Value && precision.Value <= 100)
				{
					formatString += precision.ToString();
				}
				else
				{
					throw new BadCommandLineArguments(
						"Precision must be in range from 1 to 100.");
				} 
			}
		}

		public string Format(double value)
		{
			return value.ToString(formatString, CultureInfo.InvariantCulture);
		}
	}
}
