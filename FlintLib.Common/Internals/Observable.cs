using System;
using System.Linq;

namespace FlintLib.Common
{
	internal class Observable<T> : IObservable<T>
	{
		private EventHandler _valueChanged;
		public event EventHandler ValueChanged
		{
			add
			{
				if (_valueChanged == null || !_valueChanged.GetInvocationList().Contains(value))
				{
					_valueChanged += value;
				}
			}
			remove { _valueChanged -= value; }
		}

		private T _backingField;
		public T Value
		{
			get { return _backingField; }
			set
			{
				_backingField = value;
				TriggerValueChangedEvent();
			}
		}

		internal Observable() : this(default(T)) { }

		internal Observable(T initialValue)
		{
			Value = initialValue;
		}

		private void TriggerValueChangedEvent()
		{
			_valueChanged?.Invoke(this, null);
		}
	}
}
