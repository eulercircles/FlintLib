using System;

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
				if (!_value.Equals(value))
				{
					_value = value;
					TriggerValueChangedEvent();
				}
			}
		}

		private readonly SingleSubscriptionEventHandler<EventArgs> _valueChanged;
		public SingleSubscriptionEvent<EventArgs> ValueChanged { get; private set; }

		public Observable() : this(default(T)) { }

		public Observable(T initialValue)
		{
			ValueChanged = new SingleSubscriptionEvent<EventArgs>(_valueChanged);
			Value = initialValue;
		}

		private void TriggerValueChangedEvent()
		{
			_valueChanged?.Invoke(this, null);
		}
	}
}
