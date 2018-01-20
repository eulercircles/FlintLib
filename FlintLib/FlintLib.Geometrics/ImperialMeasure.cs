using System;

using FlintLib.Common;
using FlintLib.Mathematics;

namespace FlintLib.Geometrics
{
	public struct ImperialMeasure
	{
		/// <summary>
		/// The value of the measure, always in *inches*.
		/// </summary>
		private readonly double _value;

		public double DecimalInches { get { return _value; } }

		public double DecimalFeet { get { return Math.Round((_value / (int)ImperialUnits.Feet), InternalResources.Instance.MaxDecimalResolution); } }

		public double DecimalYards { get { return Math.Round((_value / (int)ImperialUnits.Yards), InternalResources.Instance.MaxDecimalResolution); } }

		#region Operator Overloads
		#region Binary Operators
		public static ImperialMeasure operator +(ImperialMeasure lhs, ImperialMeasure rhs)
		{ return new ImperialMeasure(lhs._value + rhs._value); }

		public static ImperialMeasure operator -(ImperialMeasure lhs, ImperialMeasure rhs)
		{ return new ImperialMeasure(lhs._value - rhs._value); }

		public static ImperialMeasure operator *(ImperialMeasure lhs, ImperialMeasure rhs)
		{ return new ImperialMeasure(lhs._value * rhs._value); }

		public static ImperialMeasure operator /(ImperialMeasure lhs, ImperialMeasure rhs)
		{ return new ImperialMeasure(lhs._value / rhs._value); }
		#endregion Binary Operators

		#region Comparison Operators
		public static bool operator ==(ImperialMeasure lhs, ImperialMeasure rhs)
		{ return (lhs._value == rhs._value); }

		public static bool operator !=(ImperialMeasure lhs, ImperialMeasure rhs)
		{ return (lhs._value != rhs._value); }

		public static bool operator <(ImperialMeasure lhs, ImperialMeasure rhs)
		{ return (lhs._value < rhs._value); }

		public static bool operator >(ImperialMeasure lhs, ImperialMeasure rhs)
		{ return (lhs._value > rhs._value); }

		public static bool operator <=(ImperialMeasure lhs, ImperialMeasure rhs)
		{ return (lhs._value <= rhs._value); }

		public static bool operator >=(ImperialMeasure lhs, ImperialMeasure rhs)
		{ return (lhs._value >= rhs._value); }
		#endregion Comparison Operators
		#endregion Operator Overloads

		public ImperialMeasure(double value, ImperialUnits unit = ImperialUnits.Inches)
		{
			_value = Math.Round(value, InternalResources.Instance.MaxDecimalResolution) * (int)unit; // Converts to inches.
		}

		public static bool TryParse(string input, out ImperialMeasure? output)
		{
			if (string.IsNullOrWhiteSpace(input))
			{ output = null; return false; }

			var parseString = input;
			ImperialUnits parsedUnit = ImperialUnits.Inches;
			foreach (var designator in InternalResources.Instance.AcceptableImperialUnitDesignators)
			{
				if (parseString.EndsWith(designator))
				{
					parsedUnit = designator.ToImperialUnit().Value;
					parseString = parseString.Replace(designator, string.Empty).Trim();
					break;
				}
			}

			var parts = parseString.Split(' ');

			if (parts.Length == 1 && !parts[0].Contains("/"))
			{
				if (parts[0].IsNumericValue())
				{
					output = new ImperialMeasure(double.Parse(parts[0]), parsedUnit);
					return true;
				}
			}
			else if (parts.Length == 1 && parts[0].Contains("/"))
			{
				var fractionalParts = parts[0].Split('/');

				if (fractionalParts[0].IsNumericValue() && fractionalParts[1].IsNumericValue())
				{
					var numerator = double.Parse(fractionalParts[0]);
					var denominator = double.Parse(fractionalParts[1]);

					if (denominator > 0)
					{
						output = new ImperialMeasure((numerator / denominator), parsedUnit);
						return true;
					}
				}
			}
			else if (parts.Length == 2)
			{
				var wholePart = parts[0];
				var fractionalParts = parts[1].Split('/');

				if (wholePart.IsNumericValue())
				{
					if (fractionalParts[0].IsNumericValue() && fractionalParts[1].IsNumericValue())
					{
						var numerator = double.Parse(fractionalParts[0]);
						var denominator = double.Parse(fractionalParts[1]);

						if (denominator > 0)
						{
							var value = double.Parse(wholePart);

							value += value.IsNegative() ? -(numerator / denominator) : (numerator / denominator);
							
							output = new ImperialMeasure(value, parsedUnit);
							return true;
						}
					}
				}
			}

			output = null; return false;
		}

		public MetricMeasure ConvertToMetric()
		{
			return new MetricMeasure(_value * Constants.InchToCentimeterMultiplier);
		}

		public string ToFractionalInchString(ImperialDenominators maxResolution = ImperialDenominators.HundredTwentyEighth)
		{
			if (_value == 0) { return $"{_value}\""; }

			bool isNegative = false;
			var intermediaryValue = _value;

			if (_value < 0)
			{
				isNegative = true;
				intermediaryValue = -_value;
			}
			
			var whole = Math.Truncate(intermediaryValue);
			var numerator = 0;
			var denominator = 1;

			var fractionalPart = intermediaryValue - whole;
			var intermediary = fractionalPart * (ushort)maxResolution;
			var intermediaryNumerator = (ushort)Math.Round(intermediary);

			var gcd = Functions.GCD(intermediaryNumerator, (ushort)maxResolution);

			if (gcd > 0)
			{
				numerator = (ushort)(intermediaryNumerator / gcd);
				denominator = (ushort)((ushort)maxResolution / gcd);
			}

			var wholeString = (whole > 0) ? $"{whole}" : string.Empty;

			var fractionalString = string.Empty;
			if (numerator != 0)
			{
				if (!string.IsNullOrWhiteSpace(wholeString))
				{ fractionalString = " "; }
				fractionalString += $"{numerator}/{denominator}";
			}

			var signString = isNegative ? "-" : string.Empty;

			return ($"{signString}{wholeString}{fractionalString}\"");
		}

		public string ToFeetAndInchesString()
		{
			throw new NotImplementedException();
		}

		public override string ToString() => $"{_value}\"";

		public override bool Equals(object obj)
		{
			if (obj is ImperialMeasure comparator)
			{
				return comparator._value == this._value;
			}

			return base.Equals(obj);
		}

		public override int GetHashCode()
		{
			return this._value.GetHashCode();
		}
	}
}
