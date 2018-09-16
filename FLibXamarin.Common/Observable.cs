using System;
using System.Linq;

namespace FLibXamarin.Common
{
	public class Observable<T>
	{
		private T _value;
		public T Value
		{
			get { return _value; }
			set
			{
				if (_value == null && value != null)
				{
					_value = value;
					TriggerValueChangedEvent();
				}
				else if (!_value.Equals(value))
				{
					_value = value;
					TriggerValueChangedEvent();
				}
			}
		}

		private EventHandler _valueChanged;
		public event EventHandler ValueChanged
		{
			add
			{
				if (_valueChanged == null || !_valueChanged.GetInvocationList().Contains(value))
				{ _valueChanged += value; }
			}
			remove { _valueChanged -= value; }
		}

		public Observable() : this(default(T)) { }

		public Observable(T initialValue)
		{
			Value = initialValue;
		}

		private void TriggerValueChangedEvent()
		{
			_valueChanged?.Invoke(this, null);
		}
	}
}
