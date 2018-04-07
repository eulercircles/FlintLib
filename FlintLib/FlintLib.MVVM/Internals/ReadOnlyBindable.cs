using System;
using System.Linq;
using System.ComponentModel;

namespace FlintLib.MVVM.Internals
{
	internal class ReadOnlyBindable<T> : IReadOnlyBindable<T>
	{
		private IBindable<T> _bindable;

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
						_bindable.PropertyChanged += _bindable_PropertyChanged;
					}
				}
			}
			remove { _propertyChanged -= value; }
		}

		public T Value
		{
			get { return _bindable.Value; }
		}

		internal ReadOnlyBindable(IBindable<T> bindable)
		{
			_bindable = bindable ?? throw new ArgumentNullException(nameof(bindable));

			_bindable.PropertyChanged += _bindable_PropertyChanged;
		}

		private void _bindable_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == nameof(_bindable.Value))
			{ _triggerPropertyChangedEvent(nameof(Value)); }
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
