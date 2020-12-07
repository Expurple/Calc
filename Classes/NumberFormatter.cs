using System.Linq;
using System.Globalization;

using Calc.Classes.Exceptions;

namespace Calc.Classes
{
	class NumberFormatter
	{
		string formatString = "G"; // it's default, look up MSDN for double.ToString method
		bool percent;

		public NumberFormatter(int? precision = null, bool scientific = false,
								bool _decimal = false, bool percent = false)
		{
			if (new bool[] { scientific, _decimal, percent }.
				Count(option => option == true) > 1)
			{
				throw new BadCommandLineArguments(
					"Can't apply more than one of -E, -d, -P options at once.");
			}
			else if (scientific)
			{
				formatString = "E";
			}
			else if (_decimal)
			{
				formatString = "F";
			}
			else if (percent)
			{
				// I don't like "P" format, provided by .NET
				this.percent = percent;
				formatString = "F2";
			}

			if (precision.HasValue)
			{
				// This is required by double.ToString method, look up MSDN
				if (0 <= precision.Value && precision.Value <= 100)
				{
					formatString = formatString[0] + precision.ToString();
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
			if (!percent)
				return value.ToString(formatString, CultureInfo.InvariantCulture);
			else
				return (value*100).ToString(formatString, CultureInfo.InvariantCulture) + " %";
		}
	}
}
