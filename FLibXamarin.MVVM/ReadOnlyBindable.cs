using System;
using System.Linq;
using System.ComponentModel;

namespace FLibXamarin.MVVM
{
	public class ReadOnlyBindable<T>
	{
		private Bindable<T> _bindable;

		public T Value => _bindable.Value;

		private PropertyChangedEventHandler _propertyChanged;
		public event PropertyChangedEventHandler PropertyChanged
		{
			add
			{
				if (_propertyChanged == null || !_propertyChanged.GetInvocationList().Contains(value))
				{
					_propertyChanged += value;
					if (_propertyChanged.GetInvocationList().Count() == 1)
					{
						_bindable.PropertyChanged += Bindable_PropertyChanged;
					}
				}
			}
			remove { _propertyChanged -= value; }
		}

		public ReadOnlyBindable(Bindable<T> bindable)
		{
			_bindable = bindable ?? throw new ArgumentNullException(nameof(bindable));
			_bindable.PropertyChanged += Bindable_PropertyChanged;
		}

		private void Bindable_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == nameof(_bindable.Value))
			{ TriggerPropertyChangedEvent(nameof(Value)); }
		}

		public void Refresh()
		{
			TriggerPropertyChangedEvent(nameof(Value));
		}

		private void TriggerPropertyChangedEvent(string propertyName = null)
		{
			_propertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
