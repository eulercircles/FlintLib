using System;
using System.Linq;

namespace FLibXamarin.Common
{
	public class Observable<T>
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
						_valueChanged?.Invoke(this, null);
					}
				}
				else
				{
					if (!_value.Equals(value))
					{
						_value = value;
						_valueChanged?.Invoke(this, null);
					}
				}
			}
		}

		private EventHandler _valueChanged;
		public event EventHandler ValueChanged
		{
			add { if (_valueChanged == null || !_valueChanged.GetInvocationList().Contains(value)) { _valueChanged += value; } }
			remove { if (_valueChanged != null && _valueChanged.GetInvocationList().Contains(value)) { _valueChanged -= value; } }
		}

		/// <summary>
		/// 
		/// </summary>
		public Observable() : this(default) { }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="initialValue"></param>
		public Observable(T initialValue) => Value = initialValue;

		/// <summary>
		/// 
		/// </summary>
		public void Refresh() => _valueChanged?.Invoke(this, null);
	}
}
