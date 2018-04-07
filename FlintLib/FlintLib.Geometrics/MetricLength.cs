using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FlintLib.Common;
using FlintLib.Mathematics;

namespace FlintLib.Geometrics
{
	public struct MetricLength
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
		public static MetricLength operator +(MetricLength lhs, MetricLength rhs)
		{ return new MetricLength(lhs._value + rhs._value); }

		public static MetricLength operator -(MetricLength lhs, MetricLength rhs)
		{ return new MetricLength(lhs._value - rhs._value); }

		public static MetricLength operator *(MetricLength lhs, MetricLength rhs)
		{ return new MetricLength(lhs._value * rhs._value); }

		public static MetricLength operator /(MetricLength lhs, MetricLength rhs)
		{ return new MetricLength(lhs._value / rhs._value); }
		#endregion Binary Operators

		#region Comparison Operators
		public static bool operator ==(MetricLength lhs, MetricLength rhs)
		{ return (lhs._value == rhs._value); }

		public static bool operator !=(MetricLength lhs, MetricLength rhs)
		{ return (lhs._value != rhs._value); }

		public static bool operator <(MetricLength lhs, MetricLength rhs)
		{ return (lhs._value < rhs._value); }

		public static bool operator >(MetricLength lhs, MetricLength rhs)
		{ return (lhs._value > rhs._value); }

		public static bool operator <=(MetricLength lhs, MetricLength rhs)
		{ return (lhs._value <= rhs._value); }

		public static bool operator >=(MetricLength lhs, MetricLength rhs)
		{ return (lhs._value >= rhs._value); }
		#endregion Comparison Operators
		#endregion Operator Overloads

		public MetricLength(double value, MetricUnits unit = MetricUnits.Meters)
		{
			_value = value / (int)unit; // Be sure to convert to meters.
		}

		public static bool TryParse(string input, out MetricLength? output)
		{
			input = input.Trim().NormalizeSpacing().ToUpper();

			if (string.IsNullOrWhiteSpace(input))
			{
				output = null;
				return false;
			}

			string designator;

			if (input.IsNumericValue())
			{
				output = new MetricLength(double.Parse(input));
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
									output = new MetricLength(0, unit.Value);
								}
								else
								{
									output = new MetricLength(double.Parse(split[0].GetLeadingNumerical()), unit.Value);
								}
								return true;
							}
							else
							{
								double numericValue;
								if (double.TryParse(split[0], out numericValue))
								{
									output = new MetricLength(numericValue, unit.Value);
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

		public CustomaryLength ConvertToCustomary()
		{
			var decimalInchValue = Centimeters * Constants.CentimeterToInchMultiplier;
			return new CustomaryLength(Centimeters * Constants.CentimeterToInchMultiplier);
		}

		public override string ToString()
		{
			return _value.ToString();
		}

		public override bool Equals(object obj)
		{
			if (obj is MetricLength)
			{
				var comparator = (MetricLength)obj;
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
