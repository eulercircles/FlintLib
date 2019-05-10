#region Using Statements
using System;
using System.Linq;
using System.ComponentModel;
#endregion // Using Statements

namespace FLib.MVVM
{
	public class Bindable<T> : PropertyChangedNotifier
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

		/// <summary>
		/// Creates an observable property with a default initial value.
		/// </summary>
		public Bindable() : this(default) { }

		/// <summary>
		/// Creates an observable property with the specified initial value.
		/// </summary>
		/// <param name="initialValue">The value to initialize the observable property to.</param>
		public Bindable(T initialValue) => Value = initialValue;

		public void Refresh() => TriggerPropertyChangedEvent(nameof(Value));
	}
}
