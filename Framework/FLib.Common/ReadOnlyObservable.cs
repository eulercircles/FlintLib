#region Using Statements
using System;
using System.Linq;
#endregion // Using Statements

namespace FLib.Common
{
	public class ReadOnlyObservable<T>
	{
		private readonly Observable<T> _observable;
		public T Value => _observable.Value;

		private readonly SafeEvent<EventArgs> _valueChanged;
		public Event<EventArgs> ValueChanged { get; }

		public ReadOnlyObservable(Observable<T> observable)
		{
			_observable = observable ?? throw new ArgumentNullException(nameof(observable));

			_valueChanged = new SafeEvent<EventArgs>();
			ValueChanged = new Event<EventArgs>(_valueChanged);
			_observable.ValueChanged.Subscribe(Observable_ValueChanged);
		}

		private void Observable_ValueChanged(object sender, EventArgs args) => _valueChanged.Invoke(this, null);

		public void Refresh() => _valueChanged.Invoke(this, null);
	}
}
