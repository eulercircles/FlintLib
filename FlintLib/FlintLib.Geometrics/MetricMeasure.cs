using FlintLib.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlintLib.Geometrics
{
	public struct MetricMeasure
	{
		/// <summary>
		/// The value of the measure, always in *meters*.
		/// </summary>
		private readonly double _value;

		public double Meters { get { return _value; } }

		public double Decimeters { get { return _value * (int)MetricUnits.Decimeters; } }

		public double Centimeters { get { return _value * (int)MetricUnits.Centimeters; } }

		public double Millimeters { get { return _value * (int)MetricUnits.Millimeters; } }

		#region Operator Overloads
		#region Binary Operators
		public static MetricMeasure operator +(MetricMeasure lhs, MetricMeasure rhs)
		{ return new MetricMeasure(lhs._value + rhs._value); }

		public static MetricMeasure operator -(MetricMeasure lhs, MetricMeasure rhs)
		{ return new MetricMeasure(lhs._value - rhs._value); }

		public static MetricMeasure operator *(MetricMeasure lhs, MetricMeasure rhs)
		{ return new MetricMeasure(lhs._value * rhs._value); }

		public static MetricMeasure operator /(MetricMeasure lhs, MetricMeasure rhs)
		{ return new MetricMeasure(lhs._value / rhs._value); }
		#endregion Binary Operators

		#region Comparison Operators
		public static bool operator ==(MetricMeasure lhs, MetricMeasure rhs)
		{ return (lhs._value == rhs._value); }

		public static bool operator !=(MetricMeasure lhs, MetricMeasure rhs)
		{ return (lhs._value != rhs._value); }

		public static bool operator <(MetricMeasure lhs, MetricMeasure rhs)
		{ return (lhs._value < rhs._value); }

		public static bool operator >(MetricMeasure lhs, MetricMeasure rhs)
		{ return (lhs._value > rhs._value); }

		public static bool operator <=(MetricMeasure lhs, MetricMeasure rhs)
		{ return (lhs._value <= rhs._value); }

		public static bool operator >=(MetricMeasure lhs, MetricMeasure rhs)
		{ return (lhs._value >= rhs._value); }
		#endregion Comparison Operators
		#endregion Operator Overloads

		public MetricMeasure(double value, MetricUnits unit = MetricUnits.Meters)
		{
			_value = value / (int)unit; // Be sure to convert to meters.
		}

		public static bool TryParse(string input, out MetricMeasure? output)
		{
			input = input.Trim().CleanWhitespace().ToUpper();

			if (string.IsNullOrWhiteSpace(input))
			{
				output = null;
				return false;
			}

			string designator;

			if (input.IsNumericValue())
			{
				output = new MetricMeasure(double.Parse(input));
			}
			else
			{
				var last2 = input.TrailingLetters(2);
				designator = InternalResources.Instance.AcceptableMetricUnitDesignators.FirstOrDefault(d => input.TrailingLetters(2) == d.ToUpper());
				if (designator != null)
				{
					var unit = designator.GetMetricUnit();
					if (unit != null)
					{
						var split = input.Split(' '); // Expect one or two elements

						if (split.Length > 0 && split.Length < 3)
						{
							if (split.Length == 1)
							{
								// Could either be a numeric value and designator with no space between,
								// or JUST the designator.
								if (split[0] == designator.ToUpper())
								{
									output = new MetricMeasure(0, unit.Value);
								}
								else
								{
									output = new MetricMeasure(double.Parse(split[0].GetLeadingNumerical()), unit.Value);
								}
								return true;
							}
							else
							{
								double numericValue;
								if (double.TryParse(split[0], out numericValue))
								{
									output = new MetricMeasure(numericValue, unit.Value);
									return true;
								}
							}
						}
					}
				}
			}

			output = null;
			return false;
		}

		public ImperialMeasure ConvertToCustomary()
		{
			var decimalInchValue = Centimeters * Mathematics.Functions.CentimeterToInchMultiplier;
			return new ImperialMeasure(Centimeters * Mathematics.Functions.CentimeterToInchMultiplier);
		}

		public override string ToString()
		{
			return _value.ToString();
		}

		public override bool Equals(object obj)
		{
			if (obj is MetricMeasure)
			{
				var comparator = (MetricMeasure)obj;
				return comparator._value == this._value; ;
			}

			return base.Equals(obj);
		}

		public override int GetHashCode()
		{
			return this._value.GetHashCode();
		}
	}
}
