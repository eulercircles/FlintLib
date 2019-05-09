using FLib.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLib.Testing
{
	public class NotifierProperty<T>
	{
		private readonly SafeEvent<PropertyAccessedEventArgs> _propertyAccessed;
		public Event<PropertyAccessedEventArgs> PropertyAccessed { get; }

		private readonly object _owner;
		private readonly string _propertyName;

		private T _property;
		public T Property
		{
			get
			{
				_propertyAccessed.Invoke(_owner, new PropertyAccessedEventArgs(Accessors.Get, _propertyName, _property));
				return _property;
			}
			set
			{
				_propertyAccessed.Invoke(_owner, new PropertyAccessedEventArgs(Accessors.Set, _propertyName, value));
				_property = value;
			}
		}

		public NotifierProperty(object owner, string propertyName, T initialValue = default)
		{
			_owner = owner;
			_propertyName = propertyName;
			_property = initialValue;

			_propertyAccessed = new SafeEvent<PropertyAccessedEventArgs>();
			PropertyAccessed = new Event<PropertyAccessedEventArgs>(_propertyAccessed);
		}

	}
}
