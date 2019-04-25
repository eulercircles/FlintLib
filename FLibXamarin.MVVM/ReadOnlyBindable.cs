using System;
using System.Linq;
using System.ComponentModel;

namespace FLibXamarin.MVVM
{
	public class ReadOnlyBindable<T>
	{
		private readonly Bindable<T> _bindable;
		public T Value => _bindable.Value;

		private PropertyChangedEventHandler _valueChanged;
		public event PropertyChangedEventHandler ValueChanged
		{
			add { if (_valueChanged == null || !_valueChanged.GetInvocationList().Contains(value)) { _valueChanged += value; } }
			remove { if (_valueChanged != null && _valueChanged.GetInvocationList().Contains(value)) { _valueChanged -= value; } }
		}

		public ReadOnlyBindable(Bindable<T> bindable)
		{
			_bindable = bindable ?? throw new ArgumentNullException(nameof(bindable));
			_bindable.ValueChanged += Bindable_ValueChanged;
		}

		private void Bindable_ValueChanged(object sender, PropertyChangedEventArgs args) => _valueChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Value)));

		public void Refresh() => _valueChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Value)));

	}
}
