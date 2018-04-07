using System;
using System.Linq;
using System.ComponentModel;

namespace FlintLib.MVVM.Internals
{
	internal class TwoWayBindable<T> : IBindable<T>
	{
		private Common.IObservable<T> _observable;

		public T Value
		{
			get { return _observable.Value; }
			set { _observable.Value = value; }
		}
		
		private PropertyChangedEventHandler _propertyChanged;
		public event PropertyChangedEventHandler PropertyChanged
		{
			add
			{
				if (_propertyChanged == null || !_propertyChanged.GetInvocationList().Contains(value))
				{ _propertyChanged += value; }
			}
			remove { _propertyChanged -= value; }
		}

		internal TwoWayBindable(Common.IObservable<T> observable)
		{
			_observable = observable ?? throw new ArgumentNullException(nameof(observable));
			_observable.ValueChanged += _observable_ValueChanged;
		}

		private void _observable_ValueChanged(object sender, EventArgs e)
		{
			_triggerPropertyChangedEvent(nameof(Value));
		}

		private void _triggerPropertyChangedEvent(string propertyName = null)
		{
			_propertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		public void Bump()
		{
			_triggerPropertyChangedEvent(nameof(Value));
		}
	}
}
