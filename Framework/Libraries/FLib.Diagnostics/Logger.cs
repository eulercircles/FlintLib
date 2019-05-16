using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLib.Diagnostics
{
	public abstract class Logger<T> : ILogger where T : LogEntry
	{
		public abstract void WriteEntry(LogEntry entry);

		protected Dictionary<string, object> GetValues(T entry)
		{
			if (entry == null) { throw new ArgumentNullException(nameof(entry)); }

			var results = new Dictionary<string, object>();

			typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance).ToList().ForEach(property => {
				var key = property.Name;
				var value = property.GetValue(entry);
				results.Add(key, value);
			});

			return results;
		}
	}
}
