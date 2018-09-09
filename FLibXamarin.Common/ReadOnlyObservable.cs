using System;

namespace FLibXamarin.Common
{
	public class ReadOnlyObservable<T>
	{
		private readonly Observable<T> _observable;
		public T Value => _observable.Value;

		private readonly SingleSubscriptionEventHandler<EventArgs> _valueChanged;
		public SingleSubscriptionEvent<EventArgs> ValueChanged { get; private set; }

		public ReadOnlyObservable(Observable<T> observable)
		{
			_observable = observable ?? throw new ArgumentNullException(nameof(observable));

			ValueChanged = new SingleSubscriptionEvent<EventArgs>(_valueChanged);

			_observable.ValueChanged.Event += ValueChanged_Event;
		}

		private void ValueChanged_Event(object sender, EventArgs args)
		{
			_valueChanged?.Invoke(this, null);
		}
	}
}
