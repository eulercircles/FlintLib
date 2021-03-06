using System;

namespace FLib.Common
{
	/// <summary>Reusable messages.</summary>
	public static class Messages
	{
		/// <summary>{0} is the required type and {1} is the passed type.</summary>
		public const string fParameterIsNotAValidType = "Parameter must be of type {0} and not type {1}";
		
		/// <summary>{0} is the enum member.</summary>
		public const string fUnhandledEnumValue = "The value {0} is unhandled.";
		
		/// <summary>{0} is the lower bound and {1} is the upper bound.</summary>
		public const string fValueMustBeBetween = "The value must be between {0} and {1}.";

		public const string StringIsEmpty = "This string is empty.";
		public const string StringIsWhiteSpace = "This string is white space.";
		public const string UnhandledEnumValue = "Unhandled enum value: ";
	}

	public static class Formats
	{
		public const string DateTime_YearFirst = "yyyy-MM-dd";
	}
}
