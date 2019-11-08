using System;

namespace FLib.Testing
{
	public static class Messages
	{
		/// <summary>{0} is the exception type; {1} is the full exception string.</summary>
		public const string fExpectedNoException = "Caught unexpected '{0}': {1}";

		/// <summary>{0} is the expected exception type, {1} is the caught exception type, {2} is the full exception string.</summary>
		public const string fUnexpectedException = "Expected '{0}' but caught '{1}': {2}";

		/// <summary>{0} is the expected exception type.</summary>
		public const string fExpectedException = "Expected '{0}' but no exception was caught.";

		public const string TestNotImplemented = "Test not implemented.";
		public const string LogEntryNotWriten = "Log entry was not written.";
	}
}
