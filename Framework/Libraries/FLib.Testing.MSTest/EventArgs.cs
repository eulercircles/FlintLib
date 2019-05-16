using System;
using System.Linq;
using System.Collections.Generic;

namespace FLib.Testing
{
	public class MethodCalledEventArgs: EventArgs
	{
		public string MethodName { get; }
		public IReadOnlyDictionary<string, object> Parameters { get; }

		public MethodCalledEventArgs(string methodName, params KeyValuePair<string, object>[] parameters)
		{
			MethodName = !string.IsNullOrWhiteSpace(methodName) ? methodName : throw new ArgumentNullException(nameof(methodName));

			var methodParams = new Dictionary<string, object>();
			parameters.ToList().ForEach(parameter => {
				methodParams.Add(parameter.Key, parameter.Value);
			});
		}
	}

	public class PropertyAccessedEventArgs: EventArgs
	{
		public Accessors Accessor { get; }
		public string PropertyName { get; }
		public object PropertyValue { get; }

		public PropertyAccessedEventArgs(Accessors accessor, string propertyName, object propertyValue)
		{
			Accessor = accessor != Accessors.UNDEFINED ? accessor : throw new ArgumentException("Please choose 'Get' or 'Set'.", nameof(accessor));
			PropertyName = !string.IsNullOrWhiteSpace(propertyName) ? propertyName : throw new ArgumentNullException(nameof(propertyName));
			PropertyValue = propertyValue;
		}

	}
}
