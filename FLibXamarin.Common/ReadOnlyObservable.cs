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
			add { if (_valueChanged == null || !_valueChanged.GetInvocationList().Contains(value)) { _valueChanged += value; } }
			remove { if (_valueChanged != null && _valueChanged.GetInvocationList().Contains(value)) { _valueChanged -= value; } }
		}

		public ReadOnlyObservable(Observable<T> observable)
		{
			_observable = observable ?? throw new ArgumentNullException(nameof(observable));
			_observable.ValueChanged += Observable_ValueChanged;
		}

		private void Observable_ValueChanged(object sender, EventArgs args) => _valueChanged?.Invoke(this, null);

		public void Refresh() => _valueChanged?.Invoke(this, null);
	}
}
