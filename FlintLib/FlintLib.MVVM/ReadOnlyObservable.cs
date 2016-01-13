using System;
using System.Linq;

namespace FlintLib.MVVM
{
	public class ReadOnlyObservable<T>
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

		private Observable<T> _observable;
		public T Value { get { return _observable.Value; } }

		public ReadOnlyObservable(Observable<T> observable)
		{
			_observable = observable;
			if (_observable != null)
			{
				_observable.ValueChanged += _observable_ValueChanged;
			}
		}

		private void _observable_ValueChanged(object sender, EventArgs args)
		{
			_triggerValueChangedEvent();
		}

		private void _triggerValueChangedEvent()
		{
			if (_valueChanged != null) { _valueChanged(this, null); }
		}
	}
}
