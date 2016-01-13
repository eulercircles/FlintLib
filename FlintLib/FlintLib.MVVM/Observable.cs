using System;
using System.Linq;

namespace FlintLib.MVVM
{
	public class Observable<T>
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
				_triggerValueChangedEvent();
			}
		}

		public Observable() : this(default(T)) { }

		public Observable(T initialValue)
		{
			Value = initialValue;
		}

		private void _triggerValueChangedEvent()
		{
			if (_valueChanged != null) { _valueChanged(this, null); }
		}
	}
}
