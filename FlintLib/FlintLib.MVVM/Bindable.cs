#region Using Statements
#endregion // Using Statements

namespace FlintLib.MVVM
{
	public class Bindable<T> : PropertyChangedNotifier
	{
		private T _backingField;
		public T Value
		{
			get { return _backingField; }
			set
			{
				_backingField = value;
				_triggerPropertyChangedEvent();
			}
		}

		/// <summary>
		/// Creates an observable property with a default initial value.
		/// </summary>
		public Bindable() : this(default(T)) { }

		/// <summary>
		/// Creates an observable property with the specified initial value.
		/// </summary>
		/// <param name="initialValue">The value to initialize the observable property to.</param>
		public Bindable(T initialValue)
		{
			Value = initialValue;
		}
	}
}
