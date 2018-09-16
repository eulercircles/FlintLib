using System;
using System.Linq;

namespace FLibXamarin.Common
{
	public class ReadOnlyObservable<T>
	{
		private readonly Observable<T> _observable;
		public T Value => _observable.Value;

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

		public ReadOnlyObservable(Observable<T> observable)
		{
			_observable = observable ?? throw new ArgumentNullException(nameof(observable));
			
			_observable.ValueChanged += ValueChanged_Event;
		}

		private void ValueChanged_Event(object sender, EventArgs args)
		{
			_valueChanged?.Invoke(this, null);
		}
	}
}
