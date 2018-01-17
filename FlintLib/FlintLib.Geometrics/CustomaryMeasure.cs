using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FlintLib.Mathematics;

namespace FlintLib.Geometrics
{
	public struct CustomaryMeasure
	{
		/// <summary>
		/// The value of the measure, always in *inches*.
		/// </summary>
		private readonly double _value;

		public double DecimalInches { get { return _value; } }

		public double DecimalFeet { get { return System.Math.Round((_value / (int)CustomaryUnits.Feet), InternalResources.Instance.MaxDecimalResolution); } }

		public double DecimalYards { get { return System.Math.Round((_value / (int)CustomaryUnits.Yards), InternalResources.Instance.MaxDecimalResolution); } }

		#region Operator Overloads
		#region Binary Operators
		public static CustomaryMeasure operator +(CustomaryMeasure lhs, CustomaryMeasure rhs)
		{ return new CustomaryMeasure(lhs._value + rhs._value); }

		public static CustomaryMeasure operator -(CustomaryMeasure lhs, CustomaryMeasure rhs)
		{ return new CustomaryMeasure(lhs._value - rhs._value); }

		public static CustomaryMeasure operator *(CustomaryMeasure lhs, CustomaryMeasure rhs)
		{ return new CustomaryMeasure(lhs._value * rhs._value); }

		public static CustomaryMeasure operator /(CustomaryMeasure lhs, CustomaryMeasure rhs)
		{ return new CustomaryMeasure(lhs._value / rhs._value); }
		#endregion Binary Operators

		#region Comparison Operators
		public static bool operator ==(CustomaryMeasure lhs, CustomaryMeasure rhs)
		{ return (lhs._value == rhs._value); }

		public static bool operator !=(CustomaryMeasure lhs, CustomaryMeasure rhs)
		{ return (lhs._value != rhs._value); }

		public static bool operator <(CustomaryMeasure lhs, CustomaryMeasure rhs)
		{ return (lhs._value < rhs._value); }

		public static bool operator >(CustomaryMeasure lhs, CustomaryMeasure rhs)
		{ return (lhs._value > rhs._value); }

		public static bool operator <=(CustomaryMeasure lhs, CustomaryMeasure rhs)
		{ return (lhs._value <= rhs._value); }

		public static bool operator >=(CustomaryMeasure lhs, CustomaryMeasure rhs)
		{ return (lhs._value >= rhs._value); }
		#endregion Comparison Operators
		#endregion Operator Overloads

		public CustomaryMeasure(double value, CustomaryUnits unit = CustomaryUnits.Inches)
		{
			_value = System.Math.Round(value, InternalResources.Instance.MaxDecimalResolution) * (int)unit; // Be sure to convert to inches.
		}

		public static bool TryParse(string input, out CustomaryMeasure? output)
		{
			throw new NotImplementedException();
		}

		public MetricMeasure ConvertToMetric()
		{
			return new MetricMeasure(_value * Mathematics.Functions.InchToCentimeterMultiplier);
		}

		public string ToFractionalInchString(CustomaryDenominators maxResolution = CustomaryDenominators.HundredTwentyEighth)
		{
			ushort whole = 0;
			ushort numerator = 0;
			ushort denominator = 0;

			whole = (ushort)System.Math.Truncate(_value);

			double fractionalPart = _value - whole;
			double intermediary = fractionalPart * (ushort)maxResolution;
			ushort intermediaryNumerator = (ushort)System.Math.Round(intermediary);

			int gcd = Mathematics.Functions.GCD(intermediaryNumerator, (ushort)maxResolution);

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

		public override string ToString()
		{
			return $"{_value.ToString()}\"";
		}

		public override bool Equals(object obj)
		{
			if (obj is CustomaryMeasure)
			{
				var comparator = (CustomaryMeasure)obj;
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
