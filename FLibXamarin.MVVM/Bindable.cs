using System.Linq;
using System.ComponentModel;

namespace FLibXamarin.MVVM.Internals
{
	public class Bindable<T>
	{
		private T _value;
		public T Value
		{
			get { return _value; }
			set
			{
				_value = value;
				TriggerPropertyChangedEvent(nameof(Value));
			}
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

		/// <summary>
		/// Creates an observable property with a default initial value.
		/// </summary>
		internal Bindable() : this(default(T)) { }

		/// <summary>
		/// Creates an observable property with the specified initial value.
		/// </summary>
		/// <param name="initialValue">The value to initialize the observable property to.</param>
		internal Bindable(T initialValue)
		{
			Value = initialValue;
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
