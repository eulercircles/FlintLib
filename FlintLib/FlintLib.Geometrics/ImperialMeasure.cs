using System;
using System.Linq;
using System.Collections.Generic;

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
			if (string.IsNullOrWhiteSpace(input)) { output = null; return false; }

			var parts = input.Split(' ');

			if (parts.Length < 1 || parts.Length > 2) { output = null; return false; }
			else
			{
				if (parts.Length == 1)
				{
					var wholePartString = parts[0];

					if (!wholePartString.IsInteger()) { output = null; return false; }

					var value = int.Parse(wholePartString);

					output = new ImperialMeasure(value);
					return true;
				}
				else
				{
					var wholePartString = parts[0];
					var fractionalPartString = parts[1];

					if (!wholePartString.IsInteger()) { output = null; return false; }

					var fractionParts = fractionalPartString.Split('/');

					if (fractionParts.Length != 2) { output = null; return false; }

					var numeratorString = fractionParts[0];
					var denominatorString = fractionParts[1];

					if (!numeratorString.IsInteger()) { output = null; return false; }

					if (!denominatorString.IsInteger()) { output = null; return false; }

					var value = (double)int.Parse(wholePartString) + ((double)int.Parse(numeratorString) / (double)int.Parse(denominatorString));

					output = new ImperialMeasure(value);
					return true;
				}
			}
		}

		public MetricMeasure ConvertToMetric()
		{
			return new MetricMeasure(_value * Functions.InchToCentimeterMultiplier);
		}

		public string ToFractionalInchString(ImperialDenominators maxResolution = ImperialDenominators.HundredTwentyEighth)
		{
			ushort whole = 0;
			ushort numerator = 0;
			ushort denominator = 0;

			whole = (ushort)Math.Truncate(_value);

			double fractionalPart = _value - whole;
			double intermediary = fractionalPart * (ushort)maxResolution;
			ushort intermediaryNumerator = (ushort)Math.Round(intermediary);

			int gcd = Functions.GCD(intermediaryNumerator, (ushort)maxResolution);

			if (gcd > 0)
			{
				numerator = (ushort)(intermediaryNumerator / gcd);
				denominator = (ushort)((ushort)maxResolution / gcd);
			}

			string wholeString = string.Empty;
			if (whole != 0)
			{
				wholeString = $"{whole}";
			}

			string fractionalString = string.Empty;
			if (numerator != 0)
			{
				if (!string.IsNullOrWhiteSpace(wholeString))
				{ fractionalString = " "; }
				fractionalString += $"{numerator}/{denominator}";
			}

			return ($"{wholeString}{fractionalString}\"");
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
