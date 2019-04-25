using System.Linq;
using System.ComponentModel;

namespace FLibXamarin.MVVM
{
	public class Bindable<T>
	{
		private T _value;
		public T Value
		{
			get { return _value; }
			set
			{
				if (_value == null)
				{
					if (value != null)
					{
						_value = value;
						_valueChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Value)));
					}
				}
				else
				{
					if (!_value.Equals(value))
					{
						_value = value;
						_valueChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Value)));
					}
				}
			}
		}

		private PropertyChangedEventHandler _valueChanged;
		public event PropertyChangedEventHandler ValueChanged
		{
			add { if (_valueChanged == null || !_valueChanged.GetInvocationList().Contains(value)) { _valueChanged += value; } }
			remove { if (_valueChanged != null && _valueChanged.GetInvocationList().Contains(value)) { _valueChanged -= value; } }
		}

		/// <summary>
		/// Creates an observable property with a default initial value.
		/// </summary>
		public Bindable() : this(default) { }

		/// <summary>
		/// Creates an observable property with the specified initial value.
		/// </summary>
		/// <param name="initialValue">The value to initialize the observable property to.</param>
		public Bindable(T initialValue) => Value = initialValue;

		/// <summary>
		/// 
		/// </summary>
		public void Refresh() => _valueChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Value)));
	}
}
