using System;
using System.Collections.Generic;

using FLib.Diagnostics;

namespace FLib.Testing.MSTest
{
	public class MockLogger : Mock, ILogger
	{
		public void WriteEntry(LogEntry entry)
		{
			OnMethodCalled(new KeyValuePair<string, object>(nameof(entry), entry));
		}
	}
}
