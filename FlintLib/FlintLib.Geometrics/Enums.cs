using System.ComponentModel;

namespace FlintLib.Geometrics
{
	public enum CustomaryDenominators
	{
		Quarter = 4,
		Eighth = 8,
		Sixteenth = 16,
		ThirtySecond = 32,
		SixtyFourth = 64,
		HundredTwentyEighth = 128
	}

	public enum MeasurementSystems
	{
		Customary,
		Metric
	}

	/// <summary>
	/// 
	/// </summary>
	/// Use the following format for unit descriptions:
	/// Abbreviation, full unit name (singular), full unit name (plural), symbol (if any).
	public enum CustomaryUnits
	{
		UNDEFINED = 0,
		[Description("in,inch,inches,\"")]
		Inches = 1,
		[Description("ft,foot,feet,'")]
		Feet = 12,
		[Description("yd,yard,yards")]
		Yards = 36
	}

	/// <summary>
	/// 
	/// </summary>
	/// Use the following format for unit descriptions:
	/// Abbreviation, full unit name (singular), full unit name (plural)
	public enum MetricUnits
	{
		UNDEFINED = 0,
		[Description("mm,millimeter,millimeters")]
		Millimeters = 1000,
		[Description("cm,centimeter,centimeters")]
		Centimeters = 100,
		[Description("dm,decimeter,decimeters")]
		Decimeters = 10,
		[Description("m,meter,meters")]
		Meters = 1
	}
}
