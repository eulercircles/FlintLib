﻿#region Using Statements
using System;
using System.Linq;
using System.ComponentModel;
#endregion // Using Statements

namespace FlintLib.MVVM
{
	internal class Bindable<T> : IBindable<T>
	{
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
		
		private T _backingField;
		public T Value
		{
			get { return _backingField; }
			set
			{
				_backingField = value;
				_triggerPropertyChangedEvent(nameof(Value));
			}
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

		private void _triggerPropertyChangedEvent(string propertyName = null)
		{
            _propertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
	}
}
