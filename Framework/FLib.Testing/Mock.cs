using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FLib.Common;

namespace FLib.Testing
{
	public abstract class Mock
	{
		protected readonly SafeEvent<PropertyAccessedEventArgs> _propertyAccessed;
		public Event<PropertyAccessedEventArgs> PropertyAccessed { get; }

		protected readonly SafeEvent<MethodCalledEventArgs> _methodCalled;
		public Event<MethodCalledEventArgs> MethodCalled { get; }

		public Mock()
		{
			_propertyAccessed = new SafeEvent<PropertyAccessedEventArgs>();
			PropertyAccessed = new Event<PropertyAccessedEventArgs>(_propertyAccessed);

			_methodCalled = new SafeEvent<MethodCalledEventArgs>();
			MethodCalled = new Event<MethodCalledEventArgs>(_methodCalled);
		}
	}
}
